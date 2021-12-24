using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace _7DaysToDieUtils
{
    class FileUtils
    {
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="url"></param>
        /// <param name="savefile"></param>
        /// <param name="downloadProgressChanged">下载进度</param>
        /// <param name="downloadFileCompleted">下载完成</param>
        public static WebClient DownloadFile(
            Form form,
            string url,
            string savefile,
            Action<int> downloadProgressChanged,
            Action downloadFileCompleted
        )
        {
            WebClient client = new WebClient();
            if (downloadProgressChanged != null)
            {
                client.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e)
                {
                    if (client.IsBusy)
                    {
                        try
                        {
                            form.Invoke(downloadProgressChanged, e.ProgressPercentage);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                };
            }
            if (downloadFileCompleted != null)
            {
                client.DownloadFileCompleted += delegate (object sender, AsyncCompletedEventArgs e)
                {
                    try
                    {
                        form.Invoke(downloadFileCompleted);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                };
            }
            client.DownloadFileAsync(new Uri(url), savefile);
            return client;
        }

        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="size">初始文件大小</param>
        /// <returns></returns>
        public static string GetFileSize(long size)
        {
            var num = 1024.00; //byte

            if (size < num)
                return size + "B";
            if (size < Math.Pow(num, 2))
                return (size / num).ToString("f2") + "K"; //kb
            if (size < Math.Pow(num, 3))
                return (size / Math.Pow(num, 2)).ToString("f2") + "M"; //M
            if (size < Math.Pow(num, 4))
                return (size / Math.Pow(num, 3)).ToString("f2") + "G"; //G
            return (size / Math.Pow(num, 4)).ToString("f2") + "T"; //T
        }

        /// <summary>
        /// 获取指定文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetSelectFilePath(
            string filter = "压缩包 (*.*)|*.zip;*.7z;*.rar",
            string title = ""
        )
        {

            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = title,
                Filter = filter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }

        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        public static string GetSelectFolderPath(
            string desc = null,
            string selectPath = null,
            Environment.SpecialFolder rootFolder = Environment.SpecialFolder.Desktop
        )
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = rootFolder
            };
            if (desc != null && !desc.Equals(""))
            {
                dialog.Description = desc;
            }
            if (selectPath != null && !selectPath.Equals(""))
            {
                dialog.SelectedPath = selectPath;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return "";
        }

        /// <summary>
        /// 复制指定文件夹
        /// </summary>
        public static void CopyDirectory(string sourcePath, string destPath)
        {
            string floderName = Path.GetFileName(sourcePath);
            DirectoryInfo di = Directory.CreateDirectory(Path.Combine(destPath, floderName));
            string[] files = Directory.GetFileSystemEntries(sourcePath);

            foreach (string file in files)
            {
                if (Directory.Exists(file))
                {
                    CopyDirectory(file, di.FullName);
                }
                else
                {
                    File.Copy(file, Path.Combine(di.FullName, Path.GetFileName(file)), true);
                }
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                DirectoryInfo[] childs = dir.GetDirectories();
                foreach (DirectoryInfo child in childs)
                {
                    child.Delete(true);
                }
                dir.Delete(true);
            }
        }

        /// <summary>
        /// 打开文件夹并选中指定文件
        /// </summary>
        public static void OpenFolderAndSelectFile(string fileName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe")
            {
                Arguments = "/e,/select," + fileName
            };
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public static void WriteLog(Exception ex, string LogAddress = "")
        {
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (LogAddress == "")
            {
                LogAddress = Environment.CurrentDirectory + '\\' +
                    DateTime.Now.Year + '-' +
                    DateTime.Now.Month + '-' +
                    DateTime.Now.Day + "_Log.log";
            }

            //把异常信息输出到文件
            StreamWriter sw = new StreamWriter(LogAddress, true);
            sw.WriteLine("当前时间：" + DateTime.Now.ToString());
            sw.WriteLine("异常信息：" + ex.Message);
            sw.WriteLine("异常对象：" + ex.Source);
            sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            sw.WriteLine("触发方法：" + ex.TargetSite);
            sw.WriteLine();
            sw.Close();
        }
    }
}
