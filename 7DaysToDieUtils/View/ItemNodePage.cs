using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Model;
using Sunny.UI;
using System;
using System.IO;

namespace _7DaysToDieUtils.View
{
    public partial class ItemNodePage : UIPage
    {
        private readonly ItemNode NodeData;
        private readonly ItemNodeModel Model;

        private readonly int ParentId = -1;
        private string ImageKey = "temp.jpg";

        public ItemNodePage(ItemNode data, int parentId)
        {
            InitializeComponent();
            Model = new ItemNodeModel(this);
            NodeData = data;
            ParentId = parentId;
            InitView();
        }

        public void InitView()
        {
            var canEdit = UserInfo.GetInstance().IsAdmin;

            Submit_Btn.Visible = canEdit;
            Delete_Btn.Visible = canEdit;

            Type_TextBox.Text = NodeData.Type;
            Type_TextBox.ReadOnly = !canEdit;

            Content_Panel.Text = NodeData.Name;
            Title_TextBox.Text = NodeData.Name;
            Title_TextBox.Visible = canEdit;

            Content_RichText.Text = NodeData.Content.Replace("\\n", Environment.NewLine);
            Content_RichText.ReadOnly = !canEdit;

            Icon_Image.LoadAsync(Config.DEFAULT_IMAGE_HEAD + NodeData.ImageKey);
        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            var nodeData = new UploadMapInfoReq
            {
                parentId = ParentId,
                name = Title_TextBox.Text,
                type = Type_TextBox.Text,
                content = Content_RichText.Text,
                imageKey = ImageKey
            };
            Model.UploadInfo(nodeData);
        }

        private void Icon_Image_Click(object sender, EventArgs e)
        {
            Model.UploadImage((path) => {
                if (!path.IsNullOrEmpty())
                {
                    ImageKey = Path.GetFileName(path);
                    Icon_Image.Load(path);
                }
            });
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            Model.DeleteInfo(NodeData.Name);
        }
    }
}
