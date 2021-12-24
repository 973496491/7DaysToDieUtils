using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Threading;

namespace _7DaysToDieUtils.Model
{
    public class LoginModel
    {

        private readonly LoginForm Form;

        public LoginModel(LoginForm form)
        {
            this.Form = form;
        }

        /// <summary>
        ///  登录
        /// </summary>
        public void Login(string account, string password, Action<object> progress)
        {
            if (account.IsNullOrEmpty())
            {
                DialogUtils.ShowMessageDialog("账号不能为空!");
                Form.Invoke(progress, new object());
                return;
            }
            if (password.IsNullOrEmpty())
            {
                DialogUtils.ShowMessageDialog("密码不能为空!");
                Form.Invoke(progress, new object());
                return;
            }

            var thread = new Thread(() => PostLogin(account, password, progress));
            thread.Start();
        }

        /// <summary>
        /// 请求登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="loginProgress"></param>
        private void PostLogin(string account, string password, Action<object> progress)
        {
            var req = new LoginReq
            {
                userName = account,
                password = password
            };
            var body = JsonConvert.SerializeObject(req);

            BaseEntity<UserTokenResp> resp = HttpApi.Request<UserTokenResp>(ApiConst.API_LOGIN, body);

            if (resp == null)
            {
                DialogUtils.ShowMessageDialog("登录失败!");
                Form.Invoke(progress, new object());
                return;
            }
            if (resp.Code != 0)
            {
                DialogUtils.ShowMessageDialog(resp.Message);
                Form.Invoke(progress, new object());
                return;
            }

            if (resp.Data != null)
            {
                Config.TOKEN = resp.Data.Token;
                Form.Invoke(progress, resp.Data);
            }
            else
            {
                Form.Invoke(progress, new object());
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public void GetUserInfo(Action<object> progress)
        {
            var req = new GetUserInfoEntity
            {
                token = Config.TOKEN,
            };
            var body = JsonConvert.SerializeObject(req);
            BaseEntity<UserInfoEntity> resp = HttpApi.Request<UserInfoEntity>(ApiConst.API_USER_INFO, body);

            if (resp == null)
            {
                DialogUtils.ShowMessageDialog("获取用户信息失败!");
                Form.Invoke(progress, new object());
                return;
            }
            if (resp.Code != 0)
            {
                DialogUtils.ShowMessageDialog(resp.Message);
                Form.Invoke(progress, new object());
                return;
            }

            if (resp.Data == null)
            {
                DialogUtils.ShowMessageDialog("获取用户信息失败!");
                Form.Invoke(progress, new object());
                return;
            }

            DialogUtils.ShowMessageDialog("登录成功!");
            Form.Invoke(progress, resp.Data);
        }

        public void SaveUserInfo(UserInfoEntity entity)
        {
            UserInfo userInfo = UserInfo.GetInstance();
            userInfo.GamePath = entity.GamePath;
            userInfo.UserName = entity.UserName;
            userInfo.FastDownloadCount = entity.FastDownloadCount;
        }
    }
}
