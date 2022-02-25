using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using Newtonsoft.Json;
using Sunny.UI;

namespace _7DaysToDieUtils.View
{
    public partial class PropDetailForm : UIForm
    {
        private readonly int PropId = -1;

        public PropDetailForm(int id)
        {
            InitializeComponent();
            PropId = id;
            InitZombieInfo();
        }

        private void InitZombieInfo()
        {
            var req = new GetZombieInfoReq
            {
                id = PropId,
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<PropInfoEntity>(ApiConst.API_PROP_INFO, json);
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

        private void SetZombieInfo(PropInfoEntity entity)
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
            DialogUtils.ShowMessageDialog("获取道具信息失败!");
        }
    }
}
