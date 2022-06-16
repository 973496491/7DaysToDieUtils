using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace _7DaysToDieUtils.Model
{
    public class RootModel
    {
        private readonly RootForm Form;

        public RootModel(RootForm form)
        {
            Form = form;
        }

        /// <summary>
        /// 卸载Mod
        /// </summary>
        /// <param name="path"></param>
        /// <param name="progress"></param>
        public void UninstallMods(string path, Action<object> progress)
        {
            var thread = new Thread(() => Uninstall(path, progress));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// 卸载Mod
        /// </summary>
        /// <param name="path"></param>
        /// <param name="progress"></param>
        private void Uninstall(string path, Action<object> progress)
        {
            // 删除Mods
            var modPath = path + "\\Mods";
            if (Directory.Exists(modPath))
            {
                FileUtils.DeleteDirectory(modPath);
            }
            // 删除地图文件
            var worldPath = path + "\\Data\\Worlds";
            if (Directory.Exists(worldPath))
            {
                var isDelete = DialogUtils.ShowAskDialog("是否删除地图文件?");
                if (isDelete)
                {
                    FileUtils.DeleteDirectory(worldPath);
                }
            }
            // 替换白名单
            var dataPath = path + "\\7DaysToDie_Data\\Managed";
            if (Directory.Exists(dataPath))
            {
                var form = new DllListForm();
                form.ShowDialog();
            }
            DialogUtils.ShowMessageDialog("卸载成功~!");
            Form.Invoke(progress, new object());
        }

        /// <summary>
        /// 安装本地Mod
        /// </summary>
        public void Install_LocalMod(
            Action<string> installEnd
        )
        {
            var zipModPath = FileUtils.GetSelectFilePath(filter: "压缩包 (*.zip)|*.zip");
            if (!File.Exists(zipModPath))
            {
                DialogUtils.ShowMessageDialog("路径错误");
                return;
            }
            var modPath = Path.GetDirectoryName(zipModPath);
            var modName = Path.GetFileNameWithoutExtension(zipModPath);
            var unzipModPath = modPath + "\\" + modName;
            if (Directory.Exists(unzipModPath))
            {
                DialogUtils.ShowMessageDialog("当前模组目录已存在, 请删除之后再进行安装, 安装结束.");
                Form.Invoke(installEnd, "安装结束");
                return;
            }
            Directory.CreateDirectory(modPath);
            ZipFile.ExtractToDirectory(zipModPath, modPath);

            var isOk = DialogUtils.ShowAskDialog("模组解压结束即将开始安装, 此操作会删除Mods目录、地图目录, 是否继续?");
            if (isOk)
            {
                var configEntity = DataUtils.LoadConfig();
                FileUtils.DeleteDirectory(configEntity.GamePath + "\\Mods");
                FileUtils.DeleteDirectory(configEntity.GamePath + "\\Data\\Worlds");
                File.Delete(configEntity.GamePath + "\\7DaysToDie_Data\\Managed\\Assembly-CSharp.dll");

                FileUtils.CopyDirectoryNoHasRoot(unzipModPath, configEntity.GamePath);
            }
            Directory.Delete(unzipModPath, true);
            DialogUtils.ShowMessageDialog("安装结束.");
            Form.Invoke(installEnd, "安装结束");
        }
    }
}
