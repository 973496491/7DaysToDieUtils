using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using System;
using System.IO;
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

        public void UninstallMods(string path, Action<object> progress)
        {
            var thread = new Thread(() => Uninstall(path, progress));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

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
    }
}
