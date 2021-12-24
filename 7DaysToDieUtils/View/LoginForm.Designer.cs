namespace _7DaysToDieUtils.View
{
    partial class LoginForm
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
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.Login_Btn = new Sunny.UI.UIButton();
            this.Password_Text = new Sunny.UI.UITextBox();
            this.Account_Text = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Loading_Progress = new Sunny.UI.UIProgressIndicator();
            this.SuspendLayout();
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.uiLabel3.Location = new System.Drawing.Point(17, 53);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(250, 36);
            this.uiLabel3.TabIndex = 18;
            this.uiLabel3.Text = "七日杀工具";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login_Btn
            // 
            this.Login_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Login_Btn.IsScaled = false;
            this.Login_Btn.Location = new System.Drawing.Point(17, 209);
            this.Login_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(250, 35);
            this.Login_Btn.TabIndex = 17;
            this.Login_Btn.Text = "登录";
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // Password_Text
            // 
            this.Password_Text.ButtonSymbol = 61761;
            this.Password_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password_Text.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Password_Text.IsScaled = false;
            this.Password_Text.Location = new System.Drawing.Point(67, 161);
            this.Password_Text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password_Text.Maximum = 2147483647D;
            this.Password_Text.Minimum = -2147483648D;
            this.Password_Text.MinimumSize = new System.Drawing.Size(1, 16);
            this.Password_Text.Name = "Password_Text";
            this.Password_Text.PasswordChar = '*';
            this.Password_Text.Size = new System.Drawing.Size(200, 29);
            this.Password_Text.TabIndex = 16;
            this.Password_Text.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Password_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_KeyDown);
            // 
            // Account_Text
            // 
            this.Account_Text.ButtonSymbol = 61761;
            this.Account_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Account_Text.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Account_Text.IsScaled = false;
            this.Account_Text.Location = new System.Drawing.Point(67, 109);
            this.Account_Text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Account_Text.Maximum = 2147483647D;
            this.Account_Text.Minimum = -2147483648D;
            this.Account_Text.MinimumSize = new System.Drawing.Size(1, 16);
            this.Account_Text.Name = "Account_Text";
            this.Account_Text.Size = new System.Drawing.Size(200, 29);
            this.Account_Text.TabIndex = 15;
            this.Account_Text.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Account_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_KeyDown);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(13, 165);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(51, 21);
            this.uiLabel2.TabIndex = 14;
            this.uiLabel2.Text = "密码: ";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(13, 113);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(51, 21);
            this.uiLabel1.TabIndex = 13;
            this.uiLabel1.Text = "账号: ";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Loading_Progress
            // 
            this.Loading_Progress.BackColor = System.Drawing.Color.Transparent;
            this.Loading_Progress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Loading_Progress.IsScaled = false;
            this.Loading_Progress.Location = new System.Drawing.Point(110, 100);
            this.Loading_Progress.MinimumSize = new System.Drawing.Size(1, 1);
            this.Loading_Progress.Name = "Loading_Progress";
            this.Loading_Progress.Size = new System.Drawing.Size(60, 60);
            this.Loading_Progress.TabIndex = 19;
            this.Loading_Progress.Text = "uiProgressIndicator1";
            this.Loading_Progress.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 260);
            this.Controls.Add(this.Loading_Progress);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.Password_Text);
            this.Controls.Add(this.Account_Text);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "登录";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton Login_Btn;
        private Sunny.UI.UITextBox Password_Text;
        private Sunny.UI.UITextBox Account_Text;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIProgressIndicator Loading_Progress;
    }
}