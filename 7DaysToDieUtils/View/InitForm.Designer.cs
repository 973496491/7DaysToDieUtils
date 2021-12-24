
namespace _7DaysToDieUtils
{
    partial class InitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GoRoot_Btn = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.InitGame_Btn = new Sunny.UI.UIButton();
            this.GameStatus_Label = new Sunny.UI.UILabel();
            this.Login_Btn = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // GoRoot_Btn
            // 
            this.GoRoot_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoRoot_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GoRoot_Btn.IsScaled = false;
            this.GoRoot_Btn.Location = new System.Drawing.Point(151, 97);
            this.GoRoot_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.GoRoot_Btn.Name = "GoRoot_Btn";
            this.GoRoot_Btn.Size = new System.Drawing.Size(100, 35);
            this.GoRoot_Btn.TabIndex = 4;
            this.GoRoot_Btn.Text = "进入主界面";
            this.GoRoot_Btn.Click += new System.EventHandler(this.GoRoot_Btn_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(11, 53);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(106, 21);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "当前工具状态";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InitGame_Btn
            // 
            this.InitGame_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InitGame_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InitGame_Btn.IsScaled = false;
            this.InitGame_Btn.Location = new System.Drawing.Point(15, 97);
            this.InitGame_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.InitGame_Btn.Name = "InitGame_Btn";
            this.InitGame_Btn.Size = new System.Drawing.Size(100, 35);
            this.InitGame_Btn.TabIndex = 6;
            this.InitGame_Btn.Text = "初始化工具";
            this.InitGame_Btn.Click += new System.EventHandler(this.InitGame_Btn_Click);
            // 
            // GameStatus_Label
            // 
            this.GameStatus_Label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GameStatus_Label.Location = new System.Drawing.Point(147, 53);
            this.GameStatus_Label.Margin = new System.Windows.Forms.Padding(0);
            this.GameStatus_Label.Name = "GameStatus_Label";
            this.GameStatus_Label.Size = new System.Drawing.Size(100, 23);
            this.GameStatus_Label.TabIndex = 7;
            this.GameStatus_Label.Text = "未初始化";
            this.GameStatus_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Login_Btn
            // 
            this.Login_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Login_Btn.IsScaled = false;
            this.Login_Btn.Location = new System.Drawing.Point(15, 149);
            this.Login_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(236, 35);
            this.Login_Btn.TabIndex = 8;
            this.Login_Btn.Text = "登录";
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // InitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 199);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.GameStatus_Label);
            this.Controls.Add(this.InitGame_Btn);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.GoRoot_Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitForm";
            this.Text = "初始化";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunny.UI.UIButton GoRoot_Btn;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton InitGame_Btn;
        private Sunny.UI.UILabel GameStatus_Label;
        private Sunny.UI.UIButton Login_Btn;
    }
}