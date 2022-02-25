using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Entity;
using Sunny.UI;
using System;

namespace _7DaysToDieUtils.View
{
    public partial class MoreListOptionForm : UIForm
    {
        private readonly UIForm Form;
        private readonly Action<GetAllMapInfo> SearchAction;
        private readonly Action AddAction;
        private readonly Action<int> EditAction;
        private readonly Action<int> DeleteAction;

        private readonly bool CanEdit = UserInfo.GetInstance().IsAdmin;

        private readonly int _Id = -1;

        public MoreListOptionForm(
            UIForm form,
            int id,
            Action<GetAllMapInfo> searchAction,
            Action addAction,
            Action<int> editAction,
            Action<int> deleteAction
        )
        {
            InitializeComponent();
            Form = form;
            _Id = id;
            SearchAction = searchAction;
            AddAction = addAction;
            EditAction = editAction;
            DeleteAction = deleteAction;
            InitButtonStatus();
        }

        private void InitButtonStatus()
        {
            Add_Btn.Enabled = CanEdit;
            Edit_Btn.Enabled = CanEdit;
            Delete_Btn.Enabled = CanEdit;
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchListForm(this, (filterObj) =>
            {
                Form.Invoke(SearchAction, filterObj);
            });
            searchForm.ShowDialog();
            Close();
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            Form.Invoke(AddAction, null);
            Close();
        }

        private void Edit_Btn_Click(object sender, EventArgs e)
        {
            Form.Invoke(EditAction, _Id);
            Close();
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            Form.Invoke(DeleteAction, _Id);
            Close();
        }
    }
}
