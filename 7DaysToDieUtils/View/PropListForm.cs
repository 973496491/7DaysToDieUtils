using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Entity.req;
using _7DaysToDieUtils.Utils;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace _7DaysToDieUtils.View
{
    public partial class PropListForm : UIForm
    {
        private readonly SynchronizationContext _SyncContext = null;

        private int PageIndex = 1;
        private readonly int PageSize = 20;
        private bool HasNextPage = true;
        private string _Type = null;
        private string _Name = null;

        public PropListForm()
        {
            InitializeComponent();
            _SyncContext = SynchronizationContext.Current;
            Prop_GridView.RegistScrollToEndEvent(DataGrid_OnScrollToEnd);
            Prop_GridView.RowTemplate.Height = 45;
            ShowHintDialog();
            GetPropList();
        }

        private void ShowHintDialog()
        {
            var configEntity = DataUtils.LoadConfig();
            if (!configEntity.IsShowPropHintDialog)
            {
                DialogUtils.ShowMessageDialog("温馨提示: 右键点击道具图鉴列表可以解锁更多功能哦~~");
                configEntity.IsShowPropHintDialog = true;
                DataUtils.EditConfig(configEntity);
            }
        }

        private void ShowLoading(object obj)
        {
            Loading_Progress.Visible = true;
        }

        private void HideLoading(object obj)
        {
            Loading_Progress.Visible = false;
        }

        private void GetPropList()
        {
            _SyncContext.Post(ShowLoading, "");
            var req = new GetPropListReq
            {
                pageIndex = PageIndex,
                pageSize = PageSize,
                type = _Type,
                name = _Name,
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<List<PropInfoEntity>>(ApiConst.API_PROP_LIST, json);
            _SyncContext.Post(HideLoading, "");
            if (result == null)
            {
                HasNextPage = false;
                return;
            }
            if (!(result.Data is List<PropInfoEntity>))
            {
                HasNextPage = false;
                return;
            }
            if (result.Data.Count < PageSize)
            {
                HasNextPage = false;
            }
            SetTabData(result.Data);
        }

        private void SetTabData(List<PropInfoEntity> list)
        {
            foreach (var entity in list)
            {
                int index = Prop_GridView.Rows.Add();
                Prop_GridView.Rows[index].Tag = entity.id;
                Prop_GridView.Rows[index].ReadOnly = false;
                Prop_GridView.Rows[index].Cells[1].Value = entity.name;
                Prop_GridView.Rows[index].Cells[2].Value = entity.type;
            }
        }

        private void DataGrid_OnScrollToEnd(object sender, EventArgs e)
        {
            if (HasNextPage)
            {
                PageIndex++;
                GetPropList();
            }
        }

        private void Prop_GridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = e.RowIndex;
                var tag = Prop_GridView.Rows[index].Tag;
                var form = new PropDetailForm((int)tag);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex);
            }
        }

        private void Prop_GridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var propId = Prop_GridView.Rows[e.RowIndex].Tag;
                var optionForm = new MoreListOptionForm(
                    this,
                    (int)propId,
                    (req) => SearchProp(req),
                    () => AddProp(),
                    (id) => EditProp(id),
                    (id) => DeleteProp(id)
                )
                {
                    Left = MousePosition.X,
                    Top = MousePosition.Y
                };

                optionForm.ShowDialog();
            }
        }

        private void SearchProp(GetAllMapInfo info)
        {
            Prop_GridView.ClearRows();
            _Type = info.type;
            _Name = info.name;
            PageIndex = 1;
            HasNextPage = true;
            GetPropList();
        }

        private void AddProp()
        {
            var form = new PropEditForm(this, -1, () =>
            {
                PageIndex = 1;
                HasNextPage = true;
                Prop_GridView.ClearRows();
                GetPropList();
            });
            form.ShowDialog();
        }

        private void EditProp(int id)
        {
            var form = new PropEditForm(this, id, () => { });
            form.ShowDialog();
        }

        private void DeleteProp(int id)
        {
            _SyncContext.Post(ShowLoading, "");
            var req = new DeletePropReq
            {
                id = id
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<object>(ApiConst.API_DELETE_PROP, json);
            _SyncContext.Post(HideLoading, "");
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("删除失败!");
                return;
            }
            DialogUtils.ShowMessageDialog(result.Message);
            Prop_GridView.ClearRows();
            PageIndex = 1;
            HasNextPage = true;
            GetPropList();
        }
    }
}
