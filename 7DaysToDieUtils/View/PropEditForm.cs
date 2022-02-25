using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using Newtonsoft.Json;
using Sunny.UI;

namespace _7DaysToDieUtils.View
{
    public partial class PropEditForm : UIForm
    {
        public PropEditForm(int id)
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
            Icon_Image.LoadAsync(Config.DEFAULT_IMAGE_HEAD + "add.png");
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
    }
}
