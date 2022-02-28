using _7DaysToDieUtils.Entity;
using Sunny.UI;
using System;

namespace _7DaysToDieUtils.Utils
{
    class DialogUtils
    {
        public static void ShowMessageDialog(string message)
        {
            UIMessageDialog.ShowMessageDialog(
                message,
                "提示",
                false,
                UIStyle.Blue,
                showMask: false,
                topMost: true
            );
        }

        public static bool ShowAskDialog(string message)
        {
            bool isOK = UIMessageDialog.ShowMessageDialog(
                message,
                "提示",
                true,
                UIStyle.Blue,
                showMask: false,
                topMost: true
            );
            return isOK;
        }

        public static void ShowErrorDialog(Exception ex)
        {
            UIMessageDialog.ShowMessageDialog(
                "软件异常, 请联系QQ: 973496491 \n" + ex.Message,
                "提示",
                false,
                UIStyle.Blue,
                showMask: false,
                topMost: true
            );
        }

        public static void ShowNetErrorDialog<T>(BaseEntity<T> entity)
        {
            if (entity == null)
            {
                ShowMessageDialog("服务器异常");
                return;
            }
            var message = "错误码: " + entity.Code + "\n" + "错误信息: " + entity.Message;
            UIMessageDialog.ShowMessageDialog(
                message,
                "提示",
                false,
                UIStyle.Blue,
                showMask: false,
                topMost: true
            );
        }
    }
}
