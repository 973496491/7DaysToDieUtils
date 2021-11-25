
namespace _7DaysToDieUtils
{
    partial class Init
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
            this.label1 = new System.Windows.Forms.Label();
            this.GameStatus_Label = new System.Windows.Forms.Label();
            this.InitGame_Btn = new System.Windows.Forms.Button();
            this.GoRoot_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前工具状态: ";
            // 
            // GameStatus_Label
            // 
            this.GameStatus_Label.AutoSize = true;
            this.GameStatus_Label.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GameStatus_Label.Location = new System.Drawing.Point(153, 22);
            this.GameStatus_Label.Name = "GameStatus_Label";
            this.GameStatus_Label.Size = new System.Drawing.Size(71, 16);
            this.GameStatus_Label.TabIndex = 1;
            this.GameStatus_Label.Text = "未初始化";
            // 
            // InitGame_Btn
            // 
            this.InitGame_Btn.Location = new System.Drawing.Point(14, 57);
            this.InitGame_Btn.Name = "InitGame_Btn";
            this.InitGame_Btn.Size = new System.Drawing.Size(90, 35);
            this.InitGame_Btn.TabIndex = 2;
            this.InitGame_Btn.Text = "初始化工具";
            this.InitGame_Btn.UseVisualStyleBackColor = true;
            this.InitGame_Btn.Click += new System.EventHandler(this.InitGame_Btn_Click);
            // 
            // GoRoot_Btn
            // 
            this.GoRoot_Btn.Location = new System.Drawing.Point(180, 57);
            this.GoRoot_Btn.Name = "GoRoot_Btn";
            this.GoRoot_Btn.Size = new System.Drawing.Size(90, 35);
            this.GoRoot_Btn.TabIndex = 3;
            this.GoRoot_Btn.Text = "进入主界面";
            this.GoRoot_Btn.UseVisualStyleBackColor = true;
            this.GoRoot_Btn.Click += new System.EventHandler(this.GoRoot_Btn_Click);
            // 
            // Init
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 106);
            this.Controls.Add(this.GoRoot_Btn);
            this.Controls.Add(this.InitGame_Btn);
            this.Controls.Add(this.GameStatus_Label);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Init";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GameStatus_Label;
        private System.Windows.Forms.Button InitGame_Btn;
        private System.Windows.Forms.Button GoRoot_Btn;
    }
}