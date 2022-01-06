using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using Sunny.UI;
using System;

namespace _7DaysToDieUtils.View
{
    public partial class FilterMapInfoForm : UIForm
    {
        private readonly ItemNodePage ItemNodePage;
        private readonly Action<GetAllMapInfo> FilterAction;

        public FilterMapInfoForm(ItemNodePage page, Action<GetAllMapInfo> filterAction)
        {
            InitializeComponent();
            ItemNodePage = page;
            FilterAction = filterAction;
        }

        private void Filter_Btn_Click(object sender, System.EventArgs e)
        {
            var isFindAll = true;
            var nameStr = Name_Label.Text;
            if (nameStr.IsNullOrEmpty())
            {
                nameStr = "全部";
            }
            else
            {
                isFindAll = false;
            }

            var typeStr = Type_Label.Text;
            if (typeStr.IsNullOrEmpty())
            {
                typeStr = "全部";
            }
            else
            {
                isFindAll = false;
            }

            var message = "";
            if (isFindAll)
            {
                message = "是否查询全部?";
            } else
            {
                message = "当前筛选条件 -> \n" + "名称: " + nameStr + "\n类型: " + typeStr + "\n是否查询?";
            }

            var isOk = DialogUtils.ShowAskDialog(message);
            if (isOk)
            {
                ItemNodePage.Invoke(FilterAction, new GetAllMapInfo
                {
                    name = Name_Label.Text,
                    type = Type_Label.Text,
                });
                Close();
            }
        }
    }
}
