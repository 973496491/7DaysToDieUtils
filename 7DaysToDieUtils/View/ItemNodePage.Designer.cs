namespace _7DaysToDieUtils.View
{
    partial class ItemNodePage
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
            this.Content_Panel = new Sunny.UI.UITitlePanel();
            this.Title_TextBox = new Sunny.UI.UITextBox();
            this.Type_TextBox = new Sunny.UI.UITextBox();
            this.Submit_Btn = new Sunny.UI.UIButton();
            this.Content_RichText = new Sunny.UI.UIRichTextBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.Icon_Image = new System.Windows.Forms.PictureBox();
            this.Delete_Btn = new Sunny.UI.UIButton();
            this.Content_Panel.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Content_Panel
            // 
            this.Content_Panel.Controls.Add(this.Delete_Btn);
            this.Content_Panel.Controls.Add(this.Title_TextBox);
            this.Content_Panel.Controls.Add(this.Type_TextBox);
            this.Content_Panel.Controls.Add(this.Submit_Btn);
            this.Content_Panel.Controls.Add(this.Content_RichText);
            this.Content_Panel.Controls.Add(this.uiPanel1);
            this.Content_Panel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Content_Panel.IsScaled = false;
            this.Content_Panel.Location = new System.Drawing.Point(10, 10);
            this.Content_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Content_Panel.MinimumSize = new System.Drawing.Size(1, 1);
            this.Content_Panel.Name = "Content_Panel";
            this.Content_Panel.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.Content_Panel.Size = new System.Drawing.Size(700, 510);
            this.Content_Panel.TabIndex = 4;
            this.Content_Panel.Text = "--";
            this.Content_Panel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Title_TextBox
            // 
            this.Title_TextBox.ButtonSymbol = 61761;
            this.Title_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Title_TextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title_TextBox.IsScaled = false;
            this.Title_TextBox.Location = new System.Drawing.Point(0, 0);
            this.Title_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Title_TextBox.Maximum = 2147483647D;
            this.Title_TextBox.Minimum = -2147483648D;
            this.Title_TextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.Title_TextBox.Name = "Title_TextBox";
            this.Title_TextBox.Size = new System.Drawing.Size(700, 35);
            this.Title_TextBox.TabIndex = 9;
            this.Title_TextBox.Text = "请添加";
            this.Title_TextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Type_TextBox
            // 
            this.Type_TextBox.ButtonSymbol = 61761;
            this.Type_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Type_TextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Type_TextBox.IsScaled = false;
            this.Type_TextBox.Location = new System.Drawing.Point(11, 322);
            this.Type_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Type_TextBox.Maximum = 2147483647D;
            this.Type_TextBox.Minimum = -2147483648D;
            this.Type_TextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.Type_TextBox.Name = "Type_TextBox";
            this.Type_TextBox.Size = new System.Drawing.Size(160, 40);
            this.Type_TextBox.TabIndex = 8;
            this.Type_TextBox.Text = "--";
            this.Type_TextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Submit_Btn
            // 
            this.Submit_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Submit_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Submit_Btn.IsScaled = false;
            this.Submit_Btn.Location = new System.Drawing.Point(9, 383);
            this.Submit_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Submit_Btn.Name = "Submit_Btn";
            this.Submit_Btn.Size = new System.Drawing.Size(160, 39);
            this.Submit_Btn.TabIndex = 7;
            this.Submit_Btn.Text = "上传";
            this.Submit_Btn.Click += new System.EventHandler(this.Submit_Btn_Click);
            // 
            // Content_RichText
            // 
            this.Content_RichText.AutoWordSelection = true;
            this.Content_RichText.BackColor = System.Drawing.Color.White;
            this.Content_RichText.FillColor = System.Drawing.Color.White;
            this.Content_RichText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Content_RichText.IsScaled = false;
            this.Content_RichText.Location = new System.Drawing.Point(179, 51);
            this.Content_RichText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Content_RichText.MinimumSize = new System.Drawing.Size(1, 1);
            this.Content_RichText.Name = "Content_RichText";
            this.Content_RichText.Padding = new System.Windows.Forms.Padding(2);
            this.Content_RichText.Size = new System.Drawing.Size(510, 450);
            this.Content_RichText.TabIndex = 6;
            this.Content_RichText.Text = "-----------";
            this.Content_RichText.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Content_RichText.WordWrap = true;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.Icon_Image);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.IsScaled = false;
            this.uiPanel1.Location = new System.Drawing.Point(10, 50);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(160, 250);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = "uiPanel1";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Icon_Image
            // 
            this.Icon_Image.Location = new System.Drawing.Point(1, 1);
            this.Icon_Image.Margin = new System.Windows.Forms.Padding(0);
            this.Icon_Image.Name = "Icon_Image";
            this.Icon_Image.Size = new System.Drawing.Size(158, 248);
            this.Icon_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon_Image.TabIndex = 0;
            this.Icon_Image.TabStop = false;
            this.Icon_Image.Click += new System.EventHandler(this.Icon_Image_Click);
            // 
            // Delete_Btn
            // 
            this.Delete_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Delete_Btn.IsScaled = false;
            this.Delete_Btn.Location = new System.Drawing.Point(10, 442);
            this.Delete_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Delete_Btn.Name = "Delete_Btn";
            this.Delete_Btn.Size = new System.Drawing.Size(160, 39);
            this.Delete_Btn.TabIndex = 10;
            this.Delete_Btn.Text = "删除";
            this.Delete_Btn.Click += new System.EventHandler(this.Delete_Btn_Click);
            // 
            // ItemNodePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 530);
            this.Controls.Add(this.Content_Panel);
            this.Name = "ItemNodePage";
            this.Symbol = 61447;
            this.Text = "ItemNodePage";
            this.Content_Panel.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITitlePanel Content_Panel;
        private Sunny.UI.UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox Icon_Image;
        private Sunny.UI.UIRichTextBox Content_RichText;
        private Sunny.UI.UIButton Submit_Btn;
        private Sunny.UI.UITextBox Type_TextBox;
        private Sunny.UI.UITextBox Title_TextBox;
        private Sunny.UI.UIButton Delete_Btn;
    }
}