namespace _7DaysToDieUtils.View
{
    partial class HelperItemForm
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
            this.Zombie_Btn = new Sunny.UI.UIButton();
            this.Prop_Btn = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // Zombie_Btn
            // 
            this.Zombie_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Zombie_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Zombie_Btn.IsScaled = false;
            this.Zombie_Btn.Location = new System.Drawing.Point(25, 60);
            this.Zombie_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Zombie_Btn.Name = "Zombie_Btn";
            this.Zombie_Btn.Size = new System.Drawing.Size(200, 40);
            this.Zombie_Btn.TabIndex = 0;
            this.Zombie_Btn.Text = "古神图鉴";
            this.Zombie_Btn.Click += new System.EventHandler(this.Zombie_Btn_Click);
            // 
            // Prop_Btn
            // 
            this.Prop_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Prop_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Prop_Btn.IsScaled = false;
            this.Prop_Btn.Location = new System.Drawing.Point(25, 130);
            this.Prop_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Prop_Btn.Name = "Prop_Btn";
            this.Prop_Btn.Size = new System.Drawing.Size(200, 40);
            this.Prop_Btn.TabIndex = 1;
            this.Prop_Btn.Text = "道具图鉴";
            this.Prop_Btn.Click += new System.EventHandler(this.Prop_Btn_Click);
            // 
            // HelperItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 193);
            this.Controls.Add(this.Prop_Btn);
            this.Controls.Add(this.Zombie_Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelperItemForm";
            this.Text = "帮助中心";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Zombie_Btn;
        private Sunny.UI.UIButton Prop_Btn;
    }
}