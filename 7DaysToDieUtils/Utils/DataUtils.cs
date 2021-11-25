using _7DaysToDieUtils.Entity;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace _7DaysToDieUtils.Utils
{
    class DataUtils
    {

        private readonly static string CONFIG_FILE_NAME = "config.ini";

        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFilePath()
        {
            return Application.StartupPath + "\\" + CONFIG_FILE_NAME;
        }

        /// <summary>
        /// 删除配置文件
        /// </summary>
        public static void DeleteConfigFile()
        {
            var path = GetConfigFilePath();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 获取七日杀存档根目录
        /// </summary>
        /// <returns></returns>
        public static string GetGameSaveBasePath()
        {
            string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return AppDataPath + "\\7DaysToDie\\Saves\\";
        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void InitConfig()
        {
            string path = GetConfigFilePath();

            if (File.Exists(path))
            {
                return;
            }
            var configEntity = new ConfigEntity
            {
                GamePath = ""
            };

            WriteConfigFile(configEntity, path);
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static ConfigEntity LoadConfig()
        {
            string configPath = GetConfigFilePath();
            if (File.Exists(configPath))
            {
                StreamReader sr = new StreamReader(configPath, false);
                string configStr = sr.ReadToEnd();
                sr.Close();
                return JsonConvert.DeserializeObject<ConfigEntity>(configStr);
            }
            return new ConfigEntity();
        }

        /// <summary>
        /// 编辑配置文件
        /// </summary>
        /// <param name="entity"></param>
        public static void EditConfig(ConfigEntity entity)
        {
            WriteConfigFile(entity, GetConfigFilePath());
        }

        /// <summary>
        /// 写配置文件
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="filePath"></param>
        private static void WriteConfigFile(ConfigEntity entity, string filePath)
        {
            var configJson = JsonConvert.SerializeObject(entity);

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.WriteLine(configJson);
            sw.Close();
        }
    }
}
