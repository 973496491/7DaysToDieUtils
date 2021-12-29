﻿using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Model;
using _7DaysToDieUtils.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using static COSXML.Model.Tag.ListBucket;

namespace _7DaysToDieUtils.View
{
    public partial class JiuriModsListForm : UIForm
    {
        private readonly SynchronizationContext _SyncContext = null;
        private readonly List<ModEntity> SelectMods = new List<ModEntity>();
        private readonly ConfigEntity _ConfigEntity = new ConfigEntity();

        private readonly JiuRiModsListModel Model;

        private List<ModEntity> ModList = new List<ModEntity>();
        private WebClient DownloadClient;
        private bool IsFastDownload = false;

        public JiuriModsListForm()
        {
            InitializeComponent();

            _ConfigEntity = DataUtils.LoadConfig();
            _SyncContext = SynchronizationContext.Current;
            Model = new JiuRiModsListModel(this);

            CheckIsFastDownload();
        }

        private void ShowLoading(object obj)
        {
            StartInstall_Btn.Enabled = false;
            Loading_Progress.Visible = true;
            StatusText_Label.Text = obj.ToString();
        }

        private void HideLoading(object obj)
        {
            StartInstall_Btn.Enabled = true;
            Loading_Progress.Visible = false;
            StatusText_Label.Text = "Waiting......";
        }

        private async void CheckIsFastDownload()
        {
            _SyncContext.Post(ShowLoading, "获取配置文件中...");

            var list = QCloudCosUtils.GetInstance().GetObjectList("Mod_Config");
            string configDownloadPath = Directory.GetCurrentDirectory() + "\\Config\\";

            if (!Directory.Exists(configDownloadPath))
            {
                Directory.CreateDirectory(configDownloadPath);
            }

            var contentList = list.contentsList;

            if (contentList.Count <= 2)
            {
                _SyncContext.Post(HideLoading, null);
                return;
            }

            var content = contentList[2];

            string key = content.key;
            string modName = Path.GetFileNameWithoutExtension(content.key);
            string fileName = Path.GetFileName(key);

            await QCloudCosUtils.GetInstance().DownloadObjectAsync(
                    key, configDownloadPath, fileName,
                    (progress) => _SyncContext.Post(ShowLoading, "获取配置文件中...")
                );

            string defaultConfigPath = Directory.GetCurrentDirectory() + "\\Config\\defaultConfig.json";
            if (!File.Exists(defaultConfigPath))
            {
                IsFastDownload = false;
            }
            else
            {
                StreamReader sr = new StreamReader(defaultConfigPath, false);
                string configStr = sr.ReadToEnd();
                sr.Close();
                File.Delete(defaultConfigPath);

                JObject jsonObj = JsonConvert.DeserializeObject<JObject>(configStr);
                IsFastDownload = (bool)jsonObj["IsFastDownload"];
            }

            _SyncContext.Post(HideLoading, null);

            GetModList();
        }

        /// <summary>
        /// 获取Mod列表
        /// </summary>
        private async void GetModList()
        {
            _SyncContext.Post(ShowLoading, "获取Mod列表中...");

            try
            {
                // 判断是高速流量还是低速
                if (UserInfo.GetInstance().FastDownloadCount > 0 || IsFastDownload)
                {
                    var list = QCloudCosUtils.GetInstance().GetObjectList("Mod_Test");
                    TrasfromListToMods(list.contentsList);

                    _SyncContext.Post(HideLoading, null);
                }
                else
                {
                    var list = QCloudCosUtils.GetInstance().GetObjectList("Mod_Config");
                    string configDownloadPath = Directory.GetCurrentDirectory() + "\\Config\\";
                    if (!Directory.Exists(configDownloadPath))
                    {
                        Directory.CreateDirectory(configDownloadPath);
                    }

                    var contentList = list.contentsList;

                    if (contentList.Count <= 1)
                    {
                        _SyncContext.Post(HideLoading, null);
                        return;
                    }

                    var content = contentList[1];

                    string key = content.key;
                    string size = FileUtils.GetFileSize(content.size);
                    string modName = Path.GetFileNameWithoutExtension(content.key);
                    string fileName = Path.GetFileName(key);

                    await QCloudCosUtils.GetInstance().DownloadObjectAsync(
                            key, configDownloadPath, fileName,
                            (progress) => _SyncContext.Post(
                                ShowLoading,
                                "正在下载 [" + modName + "] 中(" + progress + ")..."
                            )
                        );

                    TrasfromConfigJsonToMods();

                    _SyncContext.Post(HideLoading, null);
                }
            }
            catch (Exception ex)
            {
                _SyncContext.Post(HideLoading, null);
                DialogUtils.ShowErrorDialog(ex);
            }
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

        /// <summary>
        /// 模型转换
        /// </summary>
        private void TrasfromConfigJsonToMods()
        {
            try
            {
                string configPath = Directory.GetCurrentDirectory() + "\\Config\\config.json";
                if (!File.Exists(configPath))
                {
                    return;
                }

                StreamReader sr = new StreamReader(configPath, false);
                string configStr = sr.ReadToEnd();
                sr.Close();

                File.Delete(configPath);

                ModList = JsonConvert.DeserializeObject<List<ModEntity>>(configStr);
                if (ModList == null || ModList.Count == 0)
                {
                    return;
                }

                SetTabData();
            }
            catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex);
            }
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

            Thread thread;
            if (UserInfo.GetInstance().FastDownloadCount > 0 || IsFastDownload)
            {
                thread = new Thread(() => DownloadMods(SelectMods[0]));
            }
            else
            {
                thread = new Thread(() => DownloadModByLink(SelectMods[0]));
            }
            thread.Start();
        }

        /// <summary>
        /// 下载Mod
        /// </summary>
        /// <param name="cosPath"></param>
        private async void DownloadMods(ModEntity mod)
        {
            _SyncContext.Post(ShowLoading, "开始下载Mod...");

            string downloadPath = Directory.GetCurrentDirectory() + "\\Mods\\";
            if (Directory.Exists(downloadPath))
            {
                FileUtils.DeleteDirectory(downloadPath);
            }
            Directory.CreateDirectory(downloadPath);

            _SyncContext.Post(ShowLoading, "正在下载 [" + mod.ModName + "] 中...");
            string fileName = Path.GetFileName(mod.FileName);
            string downloadModPath = downloadPath + mod.FileName;

            await QCloudCosUtils.GetInstance().DownloadObjectAsync(
                mod.Key, downloadPath, fileName,
                (progress) => _SyncContext.Post(
                    ShowLoading,
                    "正在下载 [" + mod.ModName + " ]中(" + progress + ")..."
                )
            );

            InstallMod(downloadModPath, mod.ModName);

            _SyncContext.Post(HideLoading, null);
        }

        /// <summary>
        /// 下载Mod
        /// </summary>
        /// <param name="cosPath"></param>
        private void DownloadModByLink(ModEntity mod)
        {
            _SyncContext.Post(ShowLoading, "开始下载Mod...");

            string downloadPath = Directory.GetCurrentDirectory() + "\\Mods\\";
            if (Directory.Exists(downloadPath))
            {
                FileUtils.DeleteDirectory(downloadPath);
            }
            Directory.CreateDirectory(downloadPath);

            _SyncContext.Post(ShowLoading, "正在下载 [" + mod.ModName + "] 中...");
            string fileName = Path.GetFileName(mod.FileName);
            string downloadModPath = downloadPath + mod.FileName;

            DownloadClient = FileUtils.DownloadFile(
                this,
                mod.Key,
                downloadModPath,
                (int progress) =>
                {
                    _SyncContext.Post(ShowLoading, "正在下载 [" + mod.ModName + "]" + "中(" + progress + "%)...");
                },
                () =>
                {
                    InstallMod(downloadModPath, mod.ModName);
                }
            );
        }

        private void InstallMod(string modPath, string modName)
        {
            var thread = new Thread(() => InstallMod_Impl(modPath, modName));
            thread.Start();
        }

        /// <summary>
        /// 安装旧日
        /// </summary>
        /// <param name="modPath"></param>
        /// <param name="modName"></param>
        private void InstallMod_Impl(string modPath, string modName)
        {
            try
            {
                Debug.WriteLine("modPath: " + modPath + " || modName: " + modName);
                Debug.WriteLine(
                    "Thread.CurrentThread: " + Thread.CurrentThread + "|" + "Thread.CurrentContext: " + Thread.CurrentContext
                );
                _SyncContext.Post(ShowLoading, "安装 [" + modName + "] 中...");

                var canNext = UIMessageDialog.ShowMessageDialog(
                    this, "安装之前需要删除Mods文件夹以及地图文件夹, 是否继续 ?", "提示", true, UIStyle.Blue
                );

                if (!canNext)
                {
                    UIMessageDialog.ShowMessageDialog(
                        this, "安装终止 !", "提示", false, UIStyle.Blue
                    );
                    return;
                }

                // 删除Mods
                string gamePath = _ConfigEntity.GamePath;
                string gameModPath = gamePath + "\\Mods";
                if (Directory.Exists(gameModPath))
                {
                    FileUtils.DeleteDirectory(gameModPath);
                }

                // 删除地图
                string gameWorldPath = gamePath + "\\Data\\Worlds";
                if (Directory.Exists(gameWorldPath))
                {
                    FileUtils.DeleteDirectory(gameWorldPath);
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
                _SyncContext.Post(ShowLoading, "安装 [Assemble-CSharp.dll] 中...");

                FileUtils.CopyDirectory(unzipPath + "\\7DaysToDie_Data", gamePath);

                // 复制Data
                _SyncContext.Post(ShowLoading, "安装 [Data] 中...");
                FileUtils.CopyDirectory(unzipPath + "\\Data", gamePath);


                // 复制Mods
                _SyncContext.Post(ShowLoading, "安装 [Mods] 中...");
                FileUtils.CopyDirectory(unzipPath + "\\Mods", gamePath);

                string downloadPath = Directory.GetCurrentDirectory() + "\\Mods\\";
                FileUtils.DeleteDirectory(downloadPath);

                UserInfo.GetInstance().FastDownloadCount--;

                Model.UploadDownloadCount((_) =>
                {
                    _SyncContext.Post(HideLoading, null);
                    InstallFinish();
                });
            }
            catch (Exception ex)
            {
                UIMessageDialog.ShowMessageDialog(
                    this, "软件异常, 请联系QQ: 973496491 \n" + ex.Message, "提示", false, UIStyle.Blue
                );
            }
        }

        private void InstallFinish()
        {
            UIMessageDialog.ShowMessageDialog(this, "安装结束...", "提示", false, UIStyle.Blue);
            Close();
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
                if (isOk)
                {
                    _SyncContext.Post(ShowLoading, "清理安装残留数据中, 请稍候...");

                    if (DownloadClient != null && DownloadClient.IsBusy)
                    {
                        DownloadClient.CancelAsync();
                        DownloadClient.Dispose();
                    }

                    int tryTimes = 0;
                    while (tryTimes < 5)
                    {
                        Thread.Sleep(100);
                        try
                        {
                            var modsPath = Directory.GetCurrentDirectory() + "\\Mods";
                            if (Directory.Exists(modsPath))
                            {
                                FileUtils.DeleteDirectory(modsPath);
                            }

                            var configPath = Directory.GetCurrentDirectory() + "\\Config";
                            if (Directory.Exists(configPath))
                            {
                                FileUtils.DeleteDirectory(configPath);
                            }

                            _SyncContext.Post(HideLoading, null);
                            break;
                        }
                        catch
                        {
                            Trace.WriteLine("delete error " + tryTimes.ToString());
                        }
                        finally
                        {
                            tryTimes++;
                        }
                    }
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
