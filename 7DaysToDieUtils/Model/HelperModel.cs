using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace _7DaysToDieUtils.Model
{
    internal class HelperModel
    {
        private readonly HelperForm Form;

        private readonly IDictionary<string, Guid> PageGuid;

        public HelperModel(HelperForm form)
        {
            Form = form;
            PageGuid = new Dictionary<string, Guid>();
        }

        /// <summary>
        /// 请求图鉴信息
        /// </summary>
        /// <param name="complete"></param>
        public void RequestMenuInfo(GetAllMapInfo req, Action<object> complete)
        {
            var body = JsonConvert.SerializeObject(req);
            var result = HttpApi.Request<MenuInfoEntity>(ApiConst.API_GET_ILLUSTRATED_INFO, body);
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

        public Guid GetGuid(string name)
        {
            if (PageGuid.ContainsKey(name))
            {
                return PageGuid[name];
            }
            else
            {
                return Guid.NewGuid();
            }
        }
    }
}
