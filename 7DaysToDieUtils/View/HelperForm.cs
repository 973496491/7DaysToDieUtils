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
            RequestMenuInfo(new GetAllMapInfo());
        }

        private void ShowLoading(object obj)
        {
            Loading_Progress.Visible = true;
        }

        private void HideLoading(object obj)
        {
            Loading_Progress.Visible = false;
        }

        private void RequestMenuInfo(GetAllMapInfo req)
        {
            _SyncContext.Post(ShowLoading, null);
            var thread = new Thread((_) => Model.RequestMenuInfo(req, (object result) =>
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

            Aside.ClearAll();

            int pageIndex = 999;

            foreach (var menu in list)
            {
                var parent = Aside.CreateNode(menu.MenuName, 61415, 24, ++pageIndex);
                if (UserInfo.GetInstance().IsAdmin)
                {
                    CreateEditPage(parent, menu.Id, menu.MenuName);
                };
                foreach (var nodeData in menu.ItemNode)
                {
                    CreateNodePage(parent, nodeData, menu.Id);
                }
                Aside.SelectPage(1000);
            }
        }

        private void CreateEditPage(TreeNode parent, int parentId, string menuName)
        {
            var node = new ItemNode
            {
                Content = "请添加" + menuName,
                ImageKey = "add.png",
                Name = "请添加" + menuName,
                Type = "请添加" + menuName
            };
            CreateNodePage(parent, node, parentId);
        }

        private void CreateNodePage(TreeNode parent, ItemNode nodeData, int parentId)
        {
            var page = new ItemNodePage(this, nodeData, parentId, (req) =>
            {
                RequestMenuInfo(req);
            });
            var guid = Model.GetGuid(nodeData.Name);
            var nodePage = Aside.CreateChildNode(parent, AddPage(page, guid));
            nodePage.Text = nodeData.Name;
        }
    }
}
