using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using Newtonsoft.Json;
using Sunny.UI;

namespace _7DaysToDieUtils.View
{
    public partial class ZombieDetailForm : UIForm
    {
        private readonly int ZombieId = -1;

        public ZombieDetailForm(int id)
        {
            InitializeComponent();
            ZombieId = id;
            InitZombieInfo();
        }

        private void InitZombieInfo()
        {
            var req = new GetZombieInfoReq
            {
                id = ZombieId,
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
            Icon_Image.LoadAsync(Config.DEFAULT_IMAGE_HEAD + entity.imageKey);

            Type_TextBox.ReadOnly = true;
            Type_TextBox.Text = entity.type;

            Content_RichText.ReadOnly = true;
            Content_RichText.Text = entity.content;

            Text = entity.name;
        }

        private void ShowNothingDialog()
        {
            DialogUtils.ShowMessageDialog("获取古神信息失败!");
        }
    }
}
