using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Model;
using _7DaysToDieUtils.Utils;
using Sunny.UI;
using System.Threading;
using System.Windows.Forms;

namespace _7DaysToDieUtils.View
{
    public partial class HelperForm : UIHeaderAsideMainFrame
    {
        private readonly SynchronizationContext _SyncContext;
        private readonly HelperModel Model;

        public HelperForm()
        {
            InitializeComponent();
            _SyncContext = SynchronizationContext.Current;
            Model = new HelperModel(this);
            Header.Hide();
            RequestMenuInfo();
        }

        private void ShowLoading(object obj)
        {
            Loading_Progress.Visible = true;
        }

        private void HideLoading(object obj)
        {
            Loading_Progress.Visible = false;
        }

        private void RequestMenuInfo()
        {
            _SyncContext.Post(ShowLoading, null);
            var thread = new Thread((_) => Model.RequestMenuInfo((object result) =>
            {
                _SyncContext.Post(HideLoading, null);
                if (result is MenuInfoEntity)
                {
                    InitTab(result as MenuInfoEntity);
                }
            }));
            thread.Start();
        }

        private void InitTab(MenuInfoEntity entity)
        {
            var list = entity.List;
            if (list.IsNullOrEmpty())
            {
                DialogUtils.ShowMessageDialog("获取图鉴信息失败");
                return;
            }

            int pageIndex = 999;

            foreach (var menu in list)
            {
                var parent = Aside.CreateNode(menu.MenuName, 61415, 24, ++pageIndex);
                if (UserInfo.GetInstance().IsAdmin)
                {
                    CreateEditPage(parent, ++pageIndex, menu.Id);

                };
                foreach (var nodeData in menu.ItemNode)
                {
                    CreateNodePage(parent, nodeData, ++pageIndex, menu.Id);
                }
                Aside.SelectPage(1000);
            }
        }

        private void CreateEditPage(TreeNode parent, int pageIndex, int parentId)
        {
            var node = new ItemNode
            {
                Content = "请添加",
                ImageKey = "add.png",
                Name = "请添加",
                Type = "请添加"
            };
            CreateNodePage(parent, node, pageIndex, parentId);
        }

        private void CreateNodePage(TreeNode parent, ItemNode nodeData, int pageIndex, int parentId)
        {
            var page = new ItemNodePage(nodeData, parentId);
            var nodePage = Aside.CreateChildNode(parent, AddPage(page, pageIndex));
            nodePage.Text = nodeData.Name;
        }
    }
}
