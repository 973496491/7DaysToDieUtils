using _7DaysToDieUtils.Entity;
using _7DaysToDieUtils.Utils;
using Sunny.UI;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _7DaysToDieUtils
{
    public partial class Init : UIForm
    {
        private ConfigEntity _ConfigEntity = new ConfigEntity();

        public Init()
        {
            InitializeComponent();
            DataUtils.InitConfig();
            CheckedGameIsInit();
            QCloudCosUtils.GetInstance().Init();
        }

        /// <summary>
        /// 进入主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoRoot_Btn_Click(object sender, EventArgs e)
        {
            var root = new Root();
            root.Show();
            this.Hide();
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitGame_Btn_Click(object sender, EventArgs e)
        {
            string path = FileUtils.GetSelectFolderPath(
                desc: "请选择七日杀安装目录~~"    
            );
            if (!Directory.Exists(path))
            {
                return;
            }
            if (!File.Exists(path + "\\7DaysToDie.exe"))
            {
                MessageBox.Show("未找到可执行文件, 请检查安装目录!");
                return;
            }
            _ConfigEntity.GamePath = path;
            _ConfigEntity.IsInit = true;
            DataUtils.EditConfig(_ConfigEntity);
            CheckedGameIsInit();
        }

        /// <summary>
        /// 检查是否初始化成功
        /// </summary>
        private void CheckedGameIsInit()
        {
            _ConfigEntity = DataUtils.LoadConfig();
            var path = _ConfigEntity.GamePath;
            if (!Directory.Exists(path))
            {
                GameStatus_Label.Text = "未初始化";
                GameStatus_Label.ForeColor = Color.Red;
                GoRoot_Btn.Enabled = _ConfigEntity.IsInit;
                DataUtils.DeleteConfigFile();
                DataUtils.InitConfig();
                return;
            }

            GoRoot_Btn.Enabled = _ConfigEntity.IsInit;
            if (_ConfigEntity.IsInit)
            {
                GameStatus_Label.Text = "初始化成功";
                GameStatus_Label.ForeColor = Color.Green;
            }
            else
            {
                GameStatus_Label.Text = "未初始化";
                GameStatus_Label.ForeColor = Color.Red;
            }
        }
    }
}
