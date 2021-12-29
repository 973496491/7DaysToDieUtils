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
