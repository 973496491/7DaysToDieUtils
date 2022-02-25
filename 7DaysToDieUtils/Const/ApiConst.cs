namespace _7DaysToDieUtils.Const
{
    public class ApiConst
    {
        /// <summary>
        /// 登录
        /// </summary>
        public static readonly string API_LOGIN = "/api/users/login";

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static readonly string API_USER_INFO = "/api/users/getUserInfo";

        /// <summary>
        /// 获取DLL列表
        /// </summary>
        public static readonly string API_DLL_LIST = "/api/file/dllList";

        /// <summary>
        /// 获取古神列表
        /// </summary>
        public static readonly string API_ZOMBIE_LIST = "/api/illustratedInfo/getAllZombieList";

        /// <summary>
        /// 获取古神详情
        /// </summary>
        public static readonly string API_ZOMBIE_INFO = "/api/illustratedInfo/getZombieInfo";

        /// <summary>
        /// 添加一条古神信息
        /// </summary>
        public static readonly string API_ADD_ZOMBIE_INFO = "/api/illustratedInfo/insertZombieInfo";

        /// <summary>
        /// 获取道具列表
        /// </summary>
        public static readonly string API_PROP_LIST = "/api/illustratedInfo/getAllPropList";

        /// <summary>
        /// 获取道具详情
        /// </summary>
        public static readonly string API_PROP_INFO = "/api/illustratedInfo/getPropInfo";

        /// <summary>
        /// 扣除下载次数
        /// </summary>
        public static readonly string API_SUBTRACT_DOWNLOADCOUNT = "/api/users/subtractDownloadCount";

        /// <summary>
        /// 获取图鉴信息
        /// </summary>
        public static readonly string API_GET_ILLUSTRATED_INFO = "/api/illustratedInfo/getAllInfo";

        /// <summary>
        /// 上传图鉴信息
        /// </summary>
        public static readonly string API_UPLOAD_ILLUSTRATED_INFO = "/api/illustratedInfo/uploadInfo";

        /// <summary>
        /// 删除图鉴信息
        /// </summary>
        public static readonly string API_DELETE_ILLUSTRATED_INFO = "/api/illustratedInfo/deleteInfo";

        /// <summary>
        /// 上传图片
        /// </summary>
        public static readonly string API_UPLOAD_IMAGE = "/api/file/uploadImage";
    }
}
