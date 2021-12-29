using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using System;

namespace _7DaysToDieUtils.Model
{
    internal class HelperModel
    {
        private readonly HelperForm Form;

        public HelperModel(HelperForm form)
        {
            Form = form;
        }

        /// <summary>
        /// 请求图鉴信息
        /// </summary>
        /// <param name="complete"></param>
        public void RequestMenuInfo(Action<object> complete)
        {
            var result = HttpApi.Request<MenuInfoEntity>(ApiConst.API_GET_ILLUSTRATED_INFO, "", "GET");
            if (result == null)
            {
                DialogUtils.ShowMessageDialog("获取图鉴信息失败");
                Form.Invoke(complete, new object());
                return;
            }
            if (result.Code != 0)
            {
                DialogUtils.ShowMessageDialog(result.Message);
                Form.Invoke(complete, new object());
                return;
            }
            if (result.Data == null)
            {
                DialogUtils.ShowMessageDialog("获取图鉴信息失败");
                Form.Invoke(complete, new object());
                return;
            }
            Form.Invoke(complete, result.Data);
        }
    }
}
