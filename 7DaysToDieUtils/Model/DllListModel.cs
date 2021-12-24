using _7DaysToDieUtils.Cons;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _7DaysToDieUtils.Model
{
    internal class DllListModel
    {
        private readonly DllListForm Form;

        public List<DllEntity> dllList = new List<DllEntity>();

        public DllListModel(DllListForm form)
        {
            Form = form;
        }

        public void InitDllList(Action<object> complete)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    var result = HttpApi.Request<List<DllEntity>>(ApiConst.API_DLL_LIST, "");
                    var data = result.Data;
                    if (data is List<DllEntity>)
                    {
                        dllList = data;
                    }
                }
                catch (Exception ex)
                {
                    DialogUtils.ShowErrorDialog(ex);
                }
                finally
                {
                    Form.Invoke(complete, new object());
                }
            });
            thread.Start();
        }

        public async Task RollbackDllAsync(int selectIndex, Action<string> downloadProgress)
        {
            try
            {
                DllEntity entity = dllList[selectIndex];
                string downloadDir = Directory.GetCurrentDirectory() + "\\DLL";
                var downloadDllPath = downloadDir + "\\" + entity.Name;
                if (File.Exists(downloadDllPath))
                {
                    File.Delete(downloadDllPath);
                }
                if (!Directory.Exists(downloadDir))
                {
                    Directory.CreateDirectory(downloadDir);
                }
                await QCloudCosUtils.GetInstance().DownloadObjectAsync(
                            entity.Key, downloadDir, entity.Name,
                            (progress) =>
                            {
                                Form.Invoke(downloadProgress, progress);
                            }
                        );

                var config = DataUtils.LoadConfig();
                var dllDir = config.GamePath + "\\7DaysToDie_Data\\Managed";
                var dllPath = dllDir + "\\" + CommonConst.DLL_NAME;
                if (File.Exists(dllPath))
                {
                    File.Delete(dllPath);
                }
                if (File.Exists(downloadDllPath))
                {
                    var dllBytes = File.ReadAllBytes(downloadDllPath);
                    File.WriteAllBytes(dllPath, dllBytes);
                }
                Form.Close();
            }
            catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex);
            }
        }
    }
}
