using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Entity.req;
using _7DaysToDieUtils.Utils;
using Newtonsoft.Json;
using Sunny.UI;
using System.Drawing.Imaging;
using System.IO;

namespace _7DaysToDieUtils.View
{
    public partial class ZombieEditForm : UIForm
    {
        private string ImageKey = "add.png";

        public ZombieEditForm(int id)
        {
            InitializeComponent();

            if (id == -1)
            {
                InitDefaultInfo();
            }
            else
            {
                InitZombieInfo(id);
            }
        }

        private void InitDefaultInfo()
        {
            Submit_Btn.Visible = true;
            Icon_Image.LoadAsync(Config.DEFAULT_IMAGE_HEAD + ImageKey);
        }

        private void InitZombieInfo(int id)
        {
            var req = new GetZombieInfoReq
            {
                id = id,
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<ZombieInfoEntity>(ApiConst.API_ZOMBIE_INFO, json);
            if (result == null)
            {
                ShowNothingDialog();
                return;
            }
            if (result.Data == null)
            {
                ShowNothingDialog();
                return;
            }
            SetZombieInfo(result.Data);
        }

        private void SetZombieInfo(ZombieInfoEntity entity)
        {
            Name_Text.Text = entity.type;
            Type_Text.Text = entity.name;
            Content_RichText.Text = entity.content;
            Icon_Image.LoadAsync(Config.DEFAULT_IMAGE_HEAD + entity.imageKey);
        }

        private void ShowNothingDialog()
        {
            DialogUtils.ShowMessageDialog("获取古神信息失败!");
        }

        private void Submit_Btn_Click(object sender, System.EventArgs e)
        {
            var req = new AddZombieInfoReq
            {
                name = Name_Text.Text,
                type = Type_Text.Text,
                imageKey = ImageKey,
                content = Content_RichText.Text,
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<object>(ApiConst.API_ADD_ZOMBIE_INFO, json);
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("古神信息上传失败");
                return;
            }
            if (result.Code != 0)
            {
                DialogUtils.ShowMessageDialog(result.Message);
                return;
            }
            DialogUtils.ShowMessageDialog("古神图鉴上传成功!");
        }

        private void Icon_Image_Click(object sender, System.EventArgs e)
        {
            UploadImage();
        }

        public void UploadImage()
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
                return;
            }
            if (result.Code != 0)
            {
                DialogUtils.ShowMessageDialog(result.Message);
                return;
            }
            ImageKey = Path.GetFileName(imagePath);
            Icon_Image.Load(imagePath);
        }
    }
}
