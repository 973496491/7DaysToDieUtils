using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;

namespace _7DaysToDieUtils
{
    public partial class Root : UIForm
    {
        readonly SynchronizationContext SyncContext = null;
        readonly List<Control> AllBtns = new List<Control>();

        private readonly ConfigEntity _ConfigEntity = new ConfigEntity();

        public Root()
        {
            InitializeComponent();
            Init_AllBtnView();

            _ConfigEntity = DataUtils.LoadConfig();
            SyncContext = SynchronizationContext.Current;
        }

        private void Init_AllBtnView()
        {
            AllBtns.Add(SaveAllDataBtn);
            AllBtns.Add(SaveOnlyDataBtn);
            AllBtns.Add(InstallJiuRi_Btn);
            AllBtns.Add(Install_Other);
            AllBtns.Add(UnInstAll_Btn);
        }

        private void ShowDialog(object obj)
        {
            Loading_Progress.Visible = true;
            AllBtns.ForEach(t => t.Enabled = false);
        }

        private void HideDialog(object obj)
        {
            Loading_Progress.Visible = false;
            AllBtns.ForEach(t => t.Enabled = true);
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Root_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        ///  保存单个存档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveOnlyDataBtn_Click(object sender, EventArgs e)
        {
            string savePath = FileUtils.GetSelectFolderPath(
                desc: "请选择Saves目录下的世界名称, 然后选择游戏名称, 然后点击确定!",
                selectPath: DataUtils.GetGameSaveBasePath(),
                rootFolder: Environment.SpecialFolder.ApplicationData
            );
            var thread = new Thread(() => SaveGameWorld(savePath, isOnlySave: true));
            thread.Start();
        }

        /// <summary>
        /// 保存全部存档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllDataBtn_Click(object sender, EventArgs e)
        {
            string basePath = DataUtils.GetGameSaveBasePath();
            var thread = new Thread(() => SaveGameWorld(basePath));
            thread.Start();
        }

        /// <summary>
        /// 保存存档实现
        /// </summary>
        /// <param name="daysDiePath"></param>
        private void SaveGameWorld(string gameSavePath, bool isOnlySave = false)
        {
            try
            {
                if (gameSavePath.Equals(""))
                {
                    MessageBox.Show("未选择文件夹 !");
                    return;
                }

                if (!Directory.Exists(gameSavePath))
                {
                    MessageBox.Show("未找到存档文件 !");
                    return;
                }
                string disktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                // 单个保存, 检查是否是Saves结尾
                string onlySaveName = Path.GetFileNameWithoutExtension(gameSavePath);
                string rootPath = Directory.GetParent(gameSavePath).FullName;
                string rootPathName = Path.GetFileNameWithoutExtension(rootPath);
                string finalPath = Directory.GetParent(rootPath).FullName;
                string finalPathName = Path.GetFileNameWithoutExtension(finalPath);
                string copyPath = disktopPath + "\\" + finalPathName + "\\" + rootPathName;
                if (isOnlySave)
                {
                    if (!finalPathName.Equals("Saves"))
                    {
                        MessageBox.Show("存档文件选择异常, 请选择Saves目录下的世界名称, 之后选择游戏名称, 然后点击确定 !");
                        return;
                    }
                    Directory.CreateDirectory(copyPath);
                    FileUtils.CopyDirectory(gameSavePath, copyPath);
                    gameSavePath = disktopPath + "\\" + finalPathName;
                }

                var currnetDate = DateTime.Now.ToString(("yyyy年MM月dd日hh时mm分ss秒"));
                string savePath = disktopPath + "\\Save-" + currnetDate + ".zip";

                SyncContext.Post(ShowDialog, null);
                if (File.Exists(savePath))
                {
                    if (MessageBox.Show("备份文件已存在, 是否删除并备份? ", "提示: ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        File.Delete(savePath);
                        ZipFile.CreateFromDirectory(gameSavePath, savePath, CompressionLevel.Fastest, true);
                    }
                    else
                    {
                        MessageBox.Show("备份终止 !");
                        SyncContext.Post(HideDialog, null);
                        return;
                    }
                }
                else
                {
                    ZipFile.CreateFromDirectory(gameSavePath, savePath, CompressionLevel.Fastest, true);
                }

                if (isOnlySave)
                {
                    Directory.Delete(gameSavePath, true);
                }

                SyncContext.Post(HideDialog, null);

                bool isCheckDir = DialogUtils.ShowAskDialog("备份成功, 是否查看备份后的存档位置 ?");
                if (isCheckDir)
                {
                    FileUtils.OpenFolderAndSelectFile(savePath);
                }
            } catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex);
                SyncContext.Post(HideDialog, null);
            }
        }

        /// <summary>
        /// 卸载所有Mod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnInstall_Btn_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() => UninstallMods());
            thread.Start();
        }

        /// <summary>
        /// 卸载所有Mod
        /// </summary>
        private void UninstallMods()
        {
            SyncContext.Post(ShowDialog, null);

            string path = _ConfigEntity.GamePath;

            var modPath = path + "\\Mods";
            if (Directory.Exists(modPath))
            {
                var isDelete = UIMessageDialog.ShowAskDialog(
                    this, "是否删除Mods文件夹?"
                );
                if (isDelete)
                {
                    FileUtils.DeleteDirectory(modPath);
                }
            }

            var worldPath = path + "\\Data\\Worlds";
            if (Directory.Exists(worldPath))
            {
                var isDelete = UIMessageDialog.ShowAskDialog(
                    this, "是否删除地图文件?"
                );
                if (isDelete)
                {
                    FileUtils.DeleteDirectory(worldPath);
                }
            }

            var dataPath = path + "\\7DaysToDie_Data\\Managed";
            if (Directory.Exists(dataPath))
            {
                var thread = new Thread(() => ReplaceDll(dataPath));
                thread.Start();
            }
            SyncContext.Post(HideDialog, null);

            UIMessageDialog.ShowMessageDialog(
                this, "卸载成功 !", "提示", false, UIStyle.Blue
            );
        }

        /// <summary>
        /// 替换白名单
        /// </summary>
        private void ReplaceDll(string dataPath)
        {
            SyncContext.Post(ShowDialog, null);
            var dllName = "Assembly-CSharp.dll";
            var dllPath = dataPath + "\\" + dllName;
            if (File.Exists(dllPath))
            {
                File.Delete(dllPath);
            }

            var csharpBytes = Properties.Resources.Assembly_CSharp;
            File.WriteAllBytes(dllPath, csharpBytes);
            SyncContext.Post(HideDialog, null);
        }

        /// <summary>
        /// 安装旧日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstallJiuRi_Btn_Click(object sender, EventArgs e)
        {
            var modList = new JiuriModsList();
            modList.ShowDialog();
        }

        /// <summary>
        /// 安装其他Mod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Install_Other_Click(object sender, EventArgs e)
        {
            var modList = new OtherModsList();
            modList.ShowDialog();
        }

        /// <summary>
        /// 还原全部存档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReductionAllSave_Btn_Click(object sender, EventArgs e)
        {
            DialogUtils.ShowMessageDialog("请选择存档文件 !");

            string saveZipPath = FileUtils.GetSelectFilePath(
                title: "请选择存档文件 !",
                filter: "压缩包 (*.zip)|*.zip"
            );

            if (saveZipPath.Equals(""))
            {
                DialogUtils.ShowMessageDialog("未找到存档文件 !");
                return;
            }

            bool isDeleteOldSave = DialogUtils.ShowAskDialog(
                "是否需要删除旧的存档, 选择 [确定] 将删除旧的存档再还原, 选择 [取消] 将直接覆盖存档。"
            );

            Thread thread = new Thread(() => ReductionAllSaves(saveZipPath, isDeleteOldSave));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// 还原全部存档
        /// </summary>
        private void ReductionAllSaves(string saveZipPath, bool isDeleteOldSave)
        {
            try
            {
                SyncContext.Post(ShowDialog, null);

                // 获取存档根目录
                string gameSavesBasePath = DataUtils.GetGameSaveBasePath();
                if (!Directory.Exists(gameSavesBasePath))
                {
                    // 不存在则创建存档根目录
                    Directory.CreateDirectory(gameSavesBasePath);
                }

                var currentTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                string unzipPath = Path.GetDirectoryName(saveZipPath) + "\\" + currentTimestamp;

                Directory.CreateDirectory(unzipPath);
                ZipFile.ExtractToDirectory(saveZipPath, unzipPath);

                string parentPath = Directory.GetParent(gameSavesBasePath).FullName;

                // 还原存档
                string unzipSavePath = unzipPath + "\\Saves";

                if (!Directory.Exists(unzipSavePath))
                {
                    DialogUtils.ShowMessageDialog("存档文件错误, 未发现Save文件夹, 请选择正确的存档文件 !");
                    SyncContext.Post(HideDialog, null);
                    return;
                }

                foreach (string oldPath in Directory.GetDirectories(unzipSavePath))
                {
                    // 地图名称
                    string worldName = Path.GetFileName(oldPath);
                    foreach (string worldPath in Directory.GetDirectories(unzipSavePath + "\\" + worldName))
                    {
                        // 游戏名称
                        string gameName = Path.GetFileName(worldPath);
                        string oldSavePath = gameSavesBasePath + "\\" + worldName + "\\" + gameName;
                        string gaemSavePath = unzipSavePath + "\\" + worldName + "\\" + gameName;

                        if (isDeleteOldSave && Directory.Exists(oldSavePath))
                        {
                            FileUtils.DeleteDirectory(oldSavePath);
                        }
                        FileUtils.CopyDirectory(gaemSavePath, Path.GetDirectoryName(oldSavePath));
                    }
                }
                // 删除解压出来的文件
                FileUtils.DeleteDirectory(unzipPath);

                SyncContext.Post(HideDialog, null);

                DialogUtils.ShowMessageDialog("还原存档结束 !");
            }
            catch (Exception ex)
            {
                SyncContext.Post(HideDialog, null);
                DialogUtils.ShowErrorDialog(ex);
            }
        }
    }
}
