using _7DaysToDieUtils.Cons;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Utils;
using Sunny.UI;

namespace _7DaysToDieUtils.View
{
    public partial class QQRoomsForm : UIForm
    {
        public QQRoomsForm()
        {
            InitializeComponent();
            InitQQRooms();
        }

        private void InitQQRooms()
        {
            foreach ((string, string) item in CommonConst.QQ_ROOMS)
            {
                int index = Rooms_GridView.Rows.Add();
                Rooms_GridView.Rows[index].ReadOnly = false;
                Rooms_GridView.Rows[index].Cells[0].Value = item.Item1;
            }
        }

        private void Rooms_GridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            var name = CommonConst.QQ_ROOMS[e.RowIndex].Item1;
            var url = CommonConst.QQ_ROOMS[e.RowIndex].Item2;
            var isOk = DialogUtils.ShowAskDialog("确定加入[" + name + "]吗?");
            if (isOk)
            {
                System.Diagnostics.Process.Start(url);
            }
        }
    }
}
