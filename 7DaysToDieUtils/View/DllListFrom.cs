using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Model;
using _7DaysToDieUtils.Utils;
using Sunny.UI;
using System.Collections.Generic;
using System.Threading;

namespace _7DaysToDieUtils.View
{
    public partial class DllListForm : UIForm
    {
        private readonly SynchronizationContext _SyncContext = null;
        private DllListModel Model;

        private int SelectIndex = 0;

        public DllListForm()
        {
            InitializeComponent();
            _SyncContext = SynchronizationContext.Current;
            Model = new DllListModel(this);
            InitList();
        }

        private void ShowLoading(object obj)
        {
            Rollback_Btn.Enabled = false;
            Loading_Progress.Visible = true;
            StatusText_Label.Text = obj.ToString();
        }

        private void HideLoading(object obj)
        {
            Rollback_Btn.Enabled = true;
            Loading_Progress.Visible = false;
            StatusText_Label.Text = "Waiting......";
        }

        private void InitList()
        {
            ShowLoading("更新 Assemble_CSharp.dll 中");
            Model.InitDllList((object _) =>
            {
                HideLoading(null);
                SetTabData();
            });
        }

        private void SetTabData()
        {
            foreach (DllEntity entity in Model.dllList)
            {
                int index = DLLs_GridView.Rows.Add();
                DLLs_GridView.Rows[index].ReadOnly = false;
                DLLs_GridView.Rows[index].Cells[0].Value = entity.Name;
                DLLs_GridView.Rows[index].Cells[1].Value = FileUtils.GetFileSize(entity.Size);
                DLLs_GridView.Rows[index].Cells[2].Value = index == SelectIndex;
            }
        }

        /// <summary>
        /// 回滚补丁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rollback_Btn_Click(object sender, System.EventArgs e)
        {
            System.Threading.Tasks.Task task = Model.RollbackDllAsync(SelectIndex, (progress) =>
            {
                _SyncContext.Post(ShowLoading, "正在下载补丁中. (" + progress+ ")");
            });
        }

        private void DLLs_GridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DLLs_GridView.Rows[SelectIndex].Cells[2].Value = false;
            DLLs_GridView.Rows[e.RowIndex].Cells[2].Value = true;
            SelectIndex = e.RowIndex;
        }
    }
}
