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
    public partial class ZombieListForm : UIForm
    {
        private readonly SynchronizationContext _SyncContext = null;

        private int PageIndex = 1;
        private readonly int PageSize = 20;
        private bool HasNextPage = true;
        private string _Type = null;
        private string _Name = null;

        public ZombieListForm()
        {
            InitializeComponent();
            _SyncContext = SynchronizationContext.Current;
            Zombie_GridView.RegistScrollToEndEvent(DataGrid_OnScrollToEnd);
            Zombie_GridView.RowTemplate.Height = 45;
            ShowHintDialog();
            GetZombieList();
        }

        private void ShowHintDialog()
        {
            var configEntity = DataUtils.LoadConfig();
            if (!configEntity.IsShowZombieHintDialog)
            {
                DialogUtils.ShowMessageDialog("温馨提示: 右键点击古神图鉴列表可以解锁更多功能哦~~");
                configEntity.IsShowZombieHintDialog = true;
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

        private void GetZombieList()
        {
            _SyncContext.Post(ShowLoading, "");
            var req = new GetZombieListReq
            {
                pageIndex = PageIndex,
                pageSize = PageSize,
                type = _Type,
                name = _Name,
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<List<ZombieInfoEntity>>(ApiConst.API_ZOMBIE_LIST, json);
            _SyncContext.Post(HideLoading, "");
            if (result == null)
            {
                HasNextPage = false;
                return;
            }
            if (!(result.Data is List<ZombieInfoEntity>))
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

        private void SetTabData(List<ZombieInfoEntity> list)
        {
            foreach (var entity in list)
            {
                int index = Zombie_GridView.Rows.Add();
                Zombie_GridView.Rows[index].Tag = entity.id;
                Zombie_GridView.Rows[index].ReadOnly = false;
                Zombie_GridView.Rows[index].Cells[1].Value = entity.name;
                Zombie_GridView.Rows[index].Cells[2].Value = entity.type;
            }
        }

        private void DataGrid_OnScrollToEnd(object sender, EventArgs e)
        {
            if (HasNextPage)
            {
                PageIndex++;
                GetZombieList();
            }
        }

        private void Zombie_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = e.RowIndex;
                var tag = Zombie_GridView.Rows[index].Tag;
                var form = new ZombieDetailForm((int)tag);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                DialogUtils.ShowErrorDialog(ex);
            }
        }

        private void Zombie_GridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;
                var zombieId = Zombie_GridView.Rows[e.RowIndex].Tag;
                var optionForm = new MoreListOptionForm(
                    this,
                    (int)zombieId,
                    (req) => SearchZombie(req),
                    () => AddZombie(),
                    (id) => EditZombie(id),
                    (id) => DeleteZombie(id)
                )
                {
                    Left = MousePosition.X,
                    Top = MousePosition.Y
                };

                optionForm.ShowDialog();
            }
        }

        private void SearchZombie(GetAllMapInfo info)
        {
            Zombie_GridView.ClearRows();
            _Type = info.type;
            _Name = info.name;
            PageIndex = 1;
            HasNextPage = true;
            GetZombieList();
        }

        private void AddZombie()
        {
            var form = new ZombieEditForm(this, -1, () =>
            {
                PageIndex = 1;
                HasNextPage = true;
                Zombie_GridView.ClearRows();
                GetZombieList();
            });
            form.ShowDialog();
        }

        private void EditZombie(int id)
        {
            var form = new ZombieEditForm(this, id, () => { });
            form.ShowDialog();
        }

        private void DeleteZombie(int id)
        {
            _SyncContext.Post(ShowLoading, "");
            var req = new DeleteZombieReq
            {
                id = id
            };
            var json = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<object>(ApiConst.API_DELETE_ZOMBIE, json);
            _SyncContext.Post(HideLoading, "");
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("删除失败!");
                return;
            }
            DialogUtils.ShowMessageDialog(result.Message);
            Zombie_GridView.ClearRows();
            PageIndex = 1;
            HasNextPage = true;
            GetZombieList();
        }
    }
}
