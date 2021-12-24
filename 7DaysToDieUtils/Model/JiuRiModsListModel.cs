using _7DaysToDieUtils.Cache;
using _7DaysToDieUtils.Const;
using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using _7DaysToDieUtils.View;
using Newtonsoft.Json;
using System;

namespace _7DaysToDieUtils.Model
{
    internal class JiuRiModsListModel
    {
        private readonly JiuriModsListForm Form;

        public JiuRiModsListModel(JiuriModsListForm form)
        {
            Form = form;
        }

        public void UploadDownloadCount(Action<object> complete)
        {
            var req = new SubtractDownloadCountEntity
            {
                token = Config.TOKEN,
            };
            var json = JsonConvert.SerializeObject(req);
            HttpApi.Request<object>(ApiConst.API_SUBTRACT_DOWNLOADCOUNT, json);
            Form.Invoke(complete, new object());
        }
    }
}
