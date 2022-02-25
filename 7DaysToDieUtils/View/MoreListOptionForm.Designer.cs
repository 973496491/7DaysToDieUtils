namespace _7DaysToDieUtils.View
{
    partial class MoreListOptionForm
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
            this.Search_Btn = new Sunny.UI.UIButton();
            this.Add_Btn = new Sunny.UI.UIButton();
            this.Edit_Btn = new Sunny.UI.UIButton();
            this.Delete_Btn = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // Search_Btn
            // 
            this.Search_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Search_Btn.IsScaled = false;
            this.Search_Btn.Location = new System.Drawing.Point(15, 50);
            this.Search_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(170, 40);
            this.Search_Btn.TabIndex = 0;
            this.Search_Btn.Text = "搜索";
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // Add_Btn
            // 
            this.Add_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add_Btn.IsScaled = false;
            this.Add_Btn.Location = new System.Drawing.Point(15, 105);
            this.Add_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Add_Btn.Name = "Add_Btn";
            this.Add_Btn.Size = new System.Drawing.Size(170, 40);
            this.Add_Btn.TabIndex = 1;
            this.Add_Btn.Text = "添加";
            this.Add_Btn.Click += new System.EventHandler(this.Add_Btn_Click);
            // 
            // Edit_Btn
            // 
            this.Edit_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Edit_Btn.IsScaled = false;
            this.Edit_Btn.Location = new System.Drawing.Point(15, 160);
            this.Edit_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Edit_Btn.Name = "Edit_Btn";
            this.Edit_Btn.Size = new System.Drawing.Size(170, 40);
            this.Edit_Btn.TabIndex = 2;
            this.Edit_Btn.Text = "编辑";
            this.Edit_Btn.Click += new System.EventHandler(this.Edit_Btn_Click);
            // 
            // Delete_Btn
            // 
            this.Delete_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Delete_Btn.IsScaled = false;
            this.Delete_Btn.Location = new System.Drawing.Point(15, 215);
            this.Delete_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Delete_Btn.Name = "Delete_Btn";
            this.Delete_Btn.Size = new System.Drawing.Size(170, 40);
            this.Delete_Btn.TabIndex = 3;
            this.Delete_Btn.Text = "删除";
            this.Delete_Btn.Click += new System.EventHandler(this.Delete_Btn_Click);
            // 
            // MoreListOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 270);
            this.Controls.Add(this.Delete_Btn);
            this.Controls.Add(this.Edit_Btn);
            this.Controls.Add(this.Add_Btn);
            this.Controls.Add(this.Search_Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoreListOptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "更多";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Search_Btn;
        private Sunny.UI.UIButton Add_Btn;
        private Sunny.UI.UIButton Edit_Btn;
        private Sunny.UI.UIButton Delete_Btn;
    }
}