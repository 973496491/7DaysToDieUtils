using COSXML;
using COSXML.Auth;
using COSXML.Model.Bucket;
using COSXML.Model.Object;
using COSXML.Model.Tag;
using COSXML.Transfer;
using System;
using System.Threading.Tasks;
using static COSXML.Transfer.COSXMLDownloadTask;

namespace _7DaysToDieUtils.Utils
{
    /// <summary>
    /// 腾讯云对象储存工具文件
    /// </summary>
    class QCloudCosUtils
    {

        private static QCloudCosUtils _QCloudCosUtils;

        // 设置一个默认的存储桶地域
        private static readonly string REGION = "ap-shanghai"; 
        // "云 API 密钥 ";
        private static readonly string SECRET_ID = "AKIDJRJvHMAhyyh9KErCI7gyzkERN3RYOyHI";
        // "云 API 密钥";
        private static readonly string SECRET_KEY = "lFaeQvAeroUt1sSmpa4IFvKSJtCEzThe";
        // 每次请求签名有效时长，单位为秒
        private static readonly long DURATION_SECOND = 6000;  

        // 储存空间名
        private static readonly string WORKSPACE_NAME = "jiurizhipeizhe";
        // 账户标识
        private static readonly string APPID = "1300866055";
        // 储存桶
        private static readonly string BUCKET = WORKSPACE_NAME + "-" + APPID;

        private CosXml CosXml;

        private QCloudCosUtils() { }

        public static QCloudCosUtils GetInstance()
        {
            if (_QCloudCosUtils == null)
            {
                _QCloudCosUtils = new QCloudCosUtils();
            }
            return _QCloudCosUtils;
        }

        public void Init()
        {
            CosXml = new CosXmlServer(
                InitCosXmlConfig(),
                InitPrivateKey()
            );
        }

        /// <summary>
        /// 初始化 CosXmlConfig 
        /// </summary>
        /// <returns></returns>
        private CosXmlConfig InitCosXmlConfig()
        {
            return new CosXmlConfig.Builder()
             .IsHttps(true)  //设置默认 HTTPS 请求
             .SetRegion(REGION)  //设置一个默认的存储桶地域
             .SetDebugLog(true)  //显示日志
             .Build();  //创建 CosXmlConfig 对象
        }

        /// <summary>
        /// 初始化密钥
        /// </summary>
        private DefaultQCloudCredentialProvider InitPrivateKey()
        {
            return new DefaultQCloudCredentialProvider(
              SECRET_ID,
              SECRET_KEY,
              DURATION_SECOND
            );
        }

        /// <summary>
        /// 查询储存列表
        /// </summary>
        public ListBucket GetObjectList(string dir)
        {
            try
            {
                GetBucketRequest request = new GetBucketRequest(BUCKET);
                request.SetPrefix(dir);
                //执行请求
                GetBucketResult result = CosXml.GetBucket(request);
                //bucket的相关信息
                ListBucket info = result.listBucket;
                return info;
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                Console.WriteLine("CosClientException: " + clientEx);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
            return null;
        }

        /// <summary>
        /// 下载对象
        /// </summary>
        /// <param name="cosPath">对象在存储桶中的位置标识符，即称对象键</param>
        /// <param name="savePath">本地存储路径</param>
        public async Task DownloadObjectAsync(
            string cosPath,
            string savePath,
            string fileName,
            Action<string> process
        )
        {
            // 初始化 TransferConfig
            TransferConfig transferConfig = new TransferConfig();
            // 初始化 TransferManager
            TransferManager transferManager = new TransferManager(CosXml, transferConfig);
            // 下载对象
            COSXMLDownloadTask downloadTask = new COSXMLDownloadTask(
                BUCKET, cosPath, savePath, fileName
            )
            {
                progressCallback = delegate (long completed, long total)
                {
                    process((int)(completed * 100.0 / total) + "%");
                }
            };

            try
            {
                DownloadTaskResult result = await transferManager.DownloadAsync(downloadTask);
                Console.WriteLine(result.GetResultInfo());
                string eTag = result.eTag;
            }
            catch (Exception e)
            {
                Console.WriteLine("CosException: " + e);
            }
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="key">对象键</param>
        /// <returns>是否成功</returns>
        public bool DeleteObject(string key)
        {
            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest(BUCKET, key);
                //执行请求
                DeleteObjectResult result = CosXml.DeleteObject(request);
                Console.WriteLine(result.GetResultInfo());
                return true;
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                Console.WriteLine("CosClientException: " + clientEx);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }
            return false;
        }
    }
}
