using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using static COSXML.Model.Tag.ListBucket;

namespace _7DaysToDieUtils.View
{
    public partial class JiuriModsList : UIForm
    {
        private readonly SynchronizationContext _SyncContext = null;
        private readonly HashSet<ModEntity> SelectMods = new HashSet<ModEntity>();
        private readonly List<ModEntity> ModList = new List<ModEntity>();
        private readonly List<(string, string)> DownloadInfo = new List<(string, string)>();
        private readonly ConfigEntity _ConfigEntity = new ConfigEntity();

        public JiuriModsList()
        {
            InitializeComponent();

            _ConfigEntity = DataUtils.LoadConfig();
            _SyncContext = SynchronizationContext.Current;

            GetModList();
        }

        private void ShowDialog(object obj)
        {
            StartInstall_Btn.Enabled = false;
            Loading_Progress.Visible = true;
            StatusText_Label.Text = obj.ToString();
        }

        private void HideDialog(object obj)
        {
            StartInstall_Btn.Enabled = true;
            Loading_Progress.Visible = false;
            StatusText_Label.Text = "Waiting......";
        }

        /// <summary>
        /// 获取Mod列表
        /// </summary>
        private void GetModList()
        {
            _SyncContext.Post(ShowDialog, "获取Mod列表中...");

            var list = QCloudCosUtils.GetInstance().GetObjectList("Mod_JiuRi");
            TrasfromListToMods(list.contentsList);

            _SyncContext.Post(HideDialog, null);
        }

        /// <summary>
        /// 模型转换
        /// </summary>
        /// <param name="contents"></param>
        private void TrasfromListToMods(List<Contents> contents)
        {
            if (contents == null)
            {
                return;
            }
            foreach (Contents content in contents)
            {

                if (content.size > 0)
                {
                    var entity = new ModEntity
                    {
                        Key = content.key,
                        Size = FileUtils.GetFileSize(content.size),
                        ModName = Path.GetFileNameWithoutExtension(content.key),
                        FileName = Path.GetFileName(content.key)
                    };
                    ModList.Add(entity);
                }
            }
            SetTabData();
        }

        private void SetTabData()
        {
            foreach (ModEntity entity in ModList)
            {
                int index = Mods_GridView.Rows.Add();
                Mods_GridView.Rows[index].ReadOnly = false;
                Mods_GridView.Rows[index].Cells[0].Value = entity.ModName;
                Mods_GridView.Rows[index].Cells[1].Value = entity.Size;
                Mods_GridView.Rows[index].Cells[2].Value = false;

            }
        }

        private void Mods_GridView_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            // 有未提交的更改
            if (Mods_GridView.IsCurrentCellDirty)
            {
                Mods_GridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Mods_GridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Mods_GridView.Columns[e.ColumnIndex].Name.Equals("select"))
            {
                var cell = Mods_GridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                bool isSelect = (bool)cell.Value;
                ModEntity mod = ModList[e.RowIndex];
                if (isSelect)
                {
                    SelectMods.Add(mod);
                }
                else
                {
                    SelectMods.Remove(mod);
                }
            }
        }

        /// <summary>
        /// 开始安装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartInstall_Btn_Click(object sender, System.EventArgs e)
        {
            if (SelectMods.Count == 0)
            {
                UIMessageDialog.ShowMessageDialog(
                    this, "未选择Mod!", "提示", false, UIStyle.Blue
                );
                return;
            }

            if (SelectMods.Count > 1)
            {
                UIMessageDialog.ShowMessageDialog(
                    this, "一次只允许安装一个版本!", "提示", false, UIStyle.Blue
                );
                return;
            }

            var thread = new Thread(() => DownloadMods());
            thread.Start();
        }

        /// <summary>
        /// 下载Mod
        /// </summary>
        /// <param name="cosPath"></param>
        private async void DownloadMods()
        {
            _SyncContext.Post(ShowDialog, "开始下载Mod...");

            string downloadPath = Directory.GetCurrentDirectory() + "\\Mods\\";
            if (Directory.Exists(downloadPath))
            {
                FileUtils.DeleteDirectory(downloadPath);
            }
            Directory.CreateDirectory(downloadPath);

            foreach (ModEntity mod in SelectMods)
            {
                _SyncContext.Post(ShowDialog, "正在下载 [" + mod.ModName + "] 中...");
                string fileName = Path.GetFileName(mod.FileName);
                string downloadModPath = downloadPath + mod.FileName;
                DownloadInfo.Add((downloadModPath, mod.ModName));

                await QCloudCosUtils.GetInstance().DownloadObjectAsync(
                    mod.Key, downloadPath, fileName,
                    (progress) => _SyncContext.Post(
                        ShowDialog,
                        "正在下载 [" + mod.ModName + "] 中(" + progress + ")..."
                    )
                );
            }

            foreach ((string, string) path in DownloadInfo)
            {
                InstallMod(path.Item1, path.Item2);
            }

            DownloadInfo.Clear();
            _SyncContext.Post(HideDialog, null);
            UIMessageDialog.ShowMessageDialog(this, "安装结束...", "提示", false, UIStyle.Blue);
        }

        /// <summary>
        /// 安装旧日
        /// </summary>
        /// <param name="modPath"></param>
        /// <param name="modName"></param>
        private void InstallMod(string modPath, string modName)
        {
           try
            {
                Debug.WriteLine("modPath: " + modPath + " || modName: " + modName);
                _SyncContext.Post(ShowDialog, "安装 [" + modName + "] 中...");

                var canNext = UIMessageDialog.ShowMessageDialog(
                    this, "安装之前需要删除Mods文件夹, 是否继续 ?", "提示", true, UIStyle.Blue
                );

                if (!canNext)
                {
                    UIMessageDialog.ShowMessageDialog(
                        this, "安装终止 !", "提示", false, UIStyle.Blue
                    );
                    return;
                }

                string gamePath = _ConfigEntity.GamePath;
                string gameModPath = gamePath + "\\Mods";
                if (Directory.Exists(gameModPath))
                {
                    FileUtils.DeleteDirectory(gameModPath);
                }

                Directory.CreateDirectory(gameModPath);

                string unzipPath = Path.GetDirectoryName(modPath);
                ZipFile.ExtractToDirectory(modPath, unzipPath);
                // 删除压缩包
                File.Delete(modPath);

                string[] childs = Directory.GetDirectories(unzipPath);
                if (childs.Length != 1)
                {
                    UIMessageDialog.ShowMessageDialog(
                        this, "安装文件异常, 安装终止, 请联系QQ: 973496491 ?", "提示", false, UIStyle.Blue
                    );
                    return;
                }

                unzipPath = Directory.GetDirectories(unzipPath)[0];

                // 复制Dll
                _SyncContext.Post(ShowDialog, "安装 [Assemble-CSharp.dll] 中...");

                FileUtils.CopyDirectory(unzipPath + "\\7DaysToDie_Data", gamePath);

                // 复制Data
                _SyncContext.Post(ShowDialog, "安装 [Data] 中...");
                FileUtils.CopyDirectory(unzipPath + "\\Data", gamePath);


                // 复制Mods
                _SyncContext.Post(ShowDialog, "安装 [Mods] 中...");
                FileUtils.CopyDirectory(unzipPath + "\\Mods", gamePath);

                string downloadPath = Directory.GetCurrentDirectory() + "\\Mods\\";
                FileUtils.DeleteDirectory(downloadPath);
            } catch (Exception ex)
            {
                UIMessageDialog.ShowMessageDialog(
                    this, "软件异常, 请联系QQ: 973496491 \n" + ex.Message, "提示", false, UIStyle.Blue
                );
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Status_Label_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Loading_Progress.Visible)
            {
                var isOk = UIMessageDialog.ShowAskDialog(this, "有任务正在进行中, 是否关闭 ?");
                e.Cancel = !isOk;
            }
        }

        private void Mods_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
