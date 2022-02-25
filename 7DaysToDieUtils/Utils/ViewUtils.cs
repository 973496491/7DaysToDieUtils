using System;
using System.Windows.Forms;

namespace _7DaysToDieUtils.Utils
{
    public static class ViewExt
    {

        /// <summary>
        /// 注册滚动条滚功到末尾时的处理事件
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="onScrollToEnd"></param>
        public static void RegistScrollToEndEvent(this DataGridView grid, EventHandler onScrollToEnd)
        {
            grid.Scroll += new ScrollEventHandler((sender, e) =>
            {
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                {
                    if (e.NewValue + grid.DisplayedRowCount(false) == grid.Rows.Count)
                    {
                        if (onScrollToEnd != null)
                        {
                            onScrollToEnd(grid, null);
                        }
                    }
                }
            });
        }
    }
}
