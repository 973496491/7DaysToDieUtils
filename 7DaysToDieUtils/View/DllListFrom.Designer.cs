namespace _7DaysToDieUtils.View
{
    partial class DllListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DLLs_GridView = new Sunny.UI.UIDataGridView();
            this.StatusText_Label = new Sunny.UI.UILabel();
            this.Loading_Progress = new Sunny.UI.UIProgressIndicator();
            this.Rollback_Btn = new Sunny.UI.UIButton();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DLLs_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DLLs_GridView
            // 
            this.DLLs_GridView.AllowUserToAddRows = false;
            this.DLLs_GridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DLLs_GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DLLs_GridView.BackgroundColor = System.Drawing.Color.White;
            this.DLLs_GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DLLs_GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DLLs_GridView.ColumnHeadersHeight = 32;
            this.DLLs_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DLLs_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.size,
            this.select});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DLLs_GridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.DLLs_GridView.EnableHeadersVisualStyles = false;
            this.DLLs_GridView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DLLs_GridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DLLs_GridView.Location = new System.Drawing.Point(3, 38);
            this.DLLs_GridView.MultiSelect = false;
            this.DLLs_GridView.Name = "DLLs_GridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DLLs_GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DLLs_GridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DLLs_GridView.RowTemplate.Height = 23;
            this.DLLs_GridView.SelectedIndex = -1;
            this.DLLs_GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DLLs_GridView.ShowGridLine = true;
            this.DLLs_GridView.Size = new System.Drawing.Size(794, 409);
            this.DLLs_GridView.TabIndex = 2;
            this.DLLs_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DLLs_GridView_CellClick);
            // 
            // StatusText_Label
            // 
            this.StatusText_Label.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.StatusText_Label.Location = new System.Drawing.Point(66, 473);
            this.StatusText_Label.Name = "StatusText_Label";
            this.StatusText_Label.Size = new System.Drawing.Size(583, 35);
            this.StatusText_Label.TabIndex = 106;
            this.StatusText_Label.Text = "Waiting......";
            this.StatusText_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Loading_Progress
            // 
            this.Loading_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Loading_Progress.BackColor = System.Drawing.Color.Transparent;
            this.Loading_Progress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Loading_Progress.IsScaled = false;
            this.Loading_Progress.Location = new System.Drawing.Point(0, 461);
            this.Loading_Progress.MinimumSize = new System.Drawing.Size(1, 1);
            this.Loading_Progress.Name = "Loading_Progress";
            this.Loading_Progress.Size = new System.Drawing.Size(53, 57);
            this.Loading_Progress.TabIndex = 105;
            this.Loading_Progress.Text = "uiProgressIndicator1";
            // 
            // Rollback_Btn
            // 
            this.Rollback_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rollback_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rollback_Btn.IsScaled = false;
            this.Rollback_Btn.Location = new System.Drawing.Point(697, 473);
            this.Rollback_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rollback_Btn.Name = "Rollback_Btn";
            this.Rollback_Btn.Size = new System.Drawing.Size(100, 35);
            this.Rollback_Btn.TabIndex = 104;
            this.Rollback_Btn.Text = "回滚补丁";
            this.Rollback_Btn.Click += new System.EventHandler(this.Rollback_Btn_Click);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DividerWidth = 1;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // size
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.size.DefaultCellStyle = dataGridViewCellStyle3;
            this.size.DividerWidth = 1;
            this.size.HeaderText = "大小";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.size.Width = 150;
            // 
            // select
            // 
            this.select.DividerWidth = 1;
            this.select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select.HeaderText = "选择";
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DllListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.StatusText_Label);
            this.Controls.Add(this.Loading_Progress);
            this.Controls.Add(this.Rollback_Btn);
            this.Controls.Add(this.DLLs_GridView);
            this.Name = "DllListForm";
            this.Text = "DllListFrom";
            ((System.ComponentModel.ISupportInitialize)(this.DLLs_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView DLLs_GridView;
        private Sunny.UI.UILabel StatusText_Label;
        private Sunny.UI.UIProgressIndicator Loading_Progress;
        private Sunny.UI.UIButton Rollback_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
    }
}