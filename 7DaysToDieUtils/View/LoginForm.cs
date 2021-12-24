using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Model;
using _7DaysToDieUtils.Utils;
using Sunny.UI;
using System.Threading;
using System.Windows.Forms;

namespace _7DaysToDieUtils.View
{
    public partial class LoginForm : UIForm
    {

        private readonly SynchronizationContext _SyncContext = null;
        private readonly LoginModel LoginModel;

        public LoginForm()
        {
            InitializeComponent();

            LoginModel = new LoginModel(this);
            _SyncContext = SynchronizationContext.Current;
        }

        private void ShowLoading(object obj)
        {
            Login_Btn.Enabled = false;
            Loading_Progress.Visible = true;
        }

        private void HideLoading(object obj)
        {
            Login_Btn.Enabled = true;
            Loading_Progress.Visible = false;
        }

        private void Login_Btn_Click(object sender, System.EventArgs e)
        {
            Login();
        }

        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Login()
        {
            _SyncContext.Post(ShowLoading, null);
            LoginModel.Login(Account_Text.Text, Password_Text.Text, (object _) =>
            {
                _SyncContext.Post(HideLoading, null);
                GetUserInfo();
            });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        private void GetUserInfo()
        {
            if (Config.TOKEN.IsNullOrEmpty()) return;
            _SyncContext.Post(ShowLoading, null);
            LoginModel.GetUserInfo((object obj) =>
            {
                _SyncContext.Post(HideLoading, null);
                if (obj is UserInfoEntity)
                {
                    LoginModel.SaveUserInfo((UserInfoEntity)obj);
                    Close();
                }
            });
        }
    }
}
