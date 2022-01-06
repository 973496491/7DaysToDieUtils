using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Drawing.Imaging;
using System.IO;

namespace _7DaysToDieUtils.Model
{
    internal class ItemNodeModel
    {
        private readonly ItemNodePage Page;

        public ItemNodeModel(ItemNodePage page)
        {
            Page = page;
        }

        public void UploadInfo(UploadMapInfoReq node, Action<object> compat)
        {
            var isOk = DialogUtils.ShowAskDialog("是否上传配置?");
            if (!isOk) return;
            var req = JsonConvert.SerializeObject(node);
            var result = HttpApi.Request<object>(ApiConst.API_UPLOAD_ILLUSTRATED_INFO, req);
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("上传失败");
                return;
            }
            if (result.Code != 0)
            {
                DialogUtils.ShowMessageDialog(result.Message);
                return;
            }
            var isRefresh = DialogUtils.ShowAskDialog("上传成功, 是否更新列表? (该操作可能会产生部分卡顿效果)");
            if (isRefresh)
            {
                Page.Invoke(compat, new object());
            }
        }

        public void DeleteInfo(string name, Action<object> compat)
        {
            var isOk = DialogUtils.ShowAskDialog("是否删除配置?");
            if (!isOk) return;
            var req = new DeleteMapInfoReq(name);
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<object>(ApiConst.API_DELETE_ILLUSTRATED_INFO, json);
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("删除失败");
                return;
            }
            if (result.Code != 0)
            {
                DialogUtils.ShowMessageDialog(result.Message);
                return;
            }
            var isRefresh = DialogUtils.ShowAskDialog("上传成功, 是否更新列表? (该操作可能会产生部分卡顿效果)");
            if (isRefresh)
            {
                Page.Invoke(compat, new object());
            }
        }

        public void UploadImage(Action<string> complete)
        {
            if (!UserInfo.GetInstance().IsAdmin) return;
            var imagePath = FileUtils.GetSelectFilePath(filter: "图片 (*.*)|*.png;*.jpg;*.jpeg");
            if (imagePath.IsNullOrEmpty()) return;
            var imageName = Path.GetFileName(imagePath);
            var base64Image = ImageUtils.ImgToBase64String(imagePath, ImageFormat.Png);
            var req = new UploadImageReq
            {
                fileName = imageName,
                fileBase64 = base64Image,
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<object>(ApiConst.API_UPLOAD_IMAGE, json);
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("图片上传失败");
                Page.Invoke(complete, "");
                return;
            }
            if (result.Code != 0)
            {
                DialogUtils.ShowMessageDialog(result.Message);
                Page.Invoke(complete, "");
                return;
            }
            Page.Invoke(complete, imagePath);
        }
    }
}
