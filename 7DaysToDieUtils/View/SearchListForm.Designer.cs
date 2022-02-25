namespace _7DaysToDieUtils.View
{
    partial class SearchListForm
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
            this.Filter_Btn = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.Name_Label = new Sunny.UI.UITextBox();
            this.Type_Label = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // Filter_Btn
            // 
            this.Filter_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Filter_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Filter_Btn.IsScaled = false;
            this.Filter_Btn.Location = new System.Drawing.Point(17, 281);
            this.Filter_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Filter_Btn.Name = "Filter_Btn";
            this.Filter_Btn.Size = new System.Drawing.Size(220, 35);
            this.Filter_Btn.TabIndex = 0;
            this.Filter_Btn.Text = "筛选";
            this.Filter_Btn.Click += new System.EventHandler(this.Filter_Btn_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(13, 50);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "名称";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(13, 139);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "类型";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.uiLabel3.Location = new System.Drawing.Point(13, 216);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(224, 52);
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "*注: 所有条件皆支持模糊查询与组合查询, 都传空则为查全部";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Name_Label
            // 
            this.Name_Label.ButtonSymbol = 61761;
            this.Name_Label.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name_Label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name_Label.IsScaled = false;
            this.Name_Label.Location = new System.Drawing.Point(17, 89);
            this.Name_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Name_Label.Maximum = 2147483647D;
            this.Name_Label.Minimum = -2147483648D;
            this.Name_Label.MinimumSize = new System.Drawing.Size(1, 16);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Name_Label.Size = new System.Drawing.Size(220, 35);
            this.Name_Label.TabIndex = 4;
            this.Name_Label.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Type_Label
            // 
            this.Type_Label.ButtonSymbol = 61761;
            this.Type_Label.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Type_Label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Type_Label.IsScaled = false;
            this.Type_Label.Location = new System.Drawing.Point(17, 176);
            this.Type_Label.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Type_Label.Maximum = 2147483647D;
            this.Type_Label.Minimum = -2147483648D;
            this.Type_Label.MinimumSize = new System.Drawing.Size(1, 16);
            this.Type_Label.Name = "Type_Label";
            this.Type_Label.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Type_Label.Size = new System.Drawing.Size(220, 35);
            this.Type_Label.TabIndex = 5;
            this.Type_Label.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterMapInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 329);
            this.Controls.Add(this.Type_Label);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.Filter_Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterMapInfoForm";
            this.Padding = new System.Windows.Forms.Padding(0, 45, 0, 0);
            this.Text = "筛选";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Filter_Btn;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox Name_Label;
        private Sunny.UI.UITextBox Type_Label;
    }
}