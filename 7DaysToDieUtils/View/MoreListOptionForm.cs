using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
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
            Init_BtnStatus();
        }

        private void Init_BtnStatus()
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
            if (CanEdit)
            {
                Form.Invoke(AddAction, null);
                Close();
            } else
            {
                DialogUtils.ShowMessageDialog("权限被拒: 您的账户权限不足, 无法进行添加.");
            }
        }

        private void Edit_Btn_Click(object sender, EventArgs e)
        {
            if (CanEdit)
            {
                Form.Invoke(EditAction, _Id);
                Close();
            }
            else
            {
                DialogUtils.ShowMessageDialog("权限被拒: 您的账户权限不足, 无法进行编辑.");
            }
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            if (CanEdit)
            {
                Form.Invoke(DeleteAction, _Id);
                Close();
            }
            else
            {
                DialogUtils.ShowMessageDialog("权限被拒: 您的账户权限不足, 无法进行删除.");
            }
        }
    }
}
