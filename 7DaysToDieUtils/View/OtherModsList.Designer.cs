
namespace _7DaysToDieUtils.View
{
    partial class Status_Label
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mods_GridView = new Sunny.UI.UIDataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StartInstall_Btn = new Sunny.UI.UIButton();
            this.Loading_Progress = new Sunny.UI.UIProgressIndicator();
            this.StatusText_Label = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.Mods_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Mods_GridView
            // 
            this.Mods_GridView.AllowUserToAddRows = false;
            this.Mods_GridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Mods_GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.Mods_GridView.BackgroundColor = System.Drawing.Color.White;
            this.Mods_GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mods_GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Mods_GridView.ColumnHeadersHeight = 32;
            this.Mods_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Mods_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.size,
            this.select});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mods_GridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.Mods_GridView.EnableHeadersVisualStyles = false;
            this.Mods_GridView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mods_GridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Mods_GridView.Location = new System.Drawing.Point(3, 38);
            this.Mods_GridView.Name = "Mods_GridView";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mods_GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.Mods_GridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.Mods_GridView.RowTemplate.Height = 23;
            this.Mods_GridView.SelectedIndex = -1;
            this.Mods_GridView.ShowGridLine = true;
            this.Mods_GridView.Size = new System.Drawing.Size(794, 409);
            this.Mods_GridView.TabIndex = 1;
            this.Mods_GridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mods_GridView_CellValueChanged);
            this.Mods_GridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.Mods_GridView_CurrentCellDirtyStateChanged);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.size.DefaultCellStyle = dataGridViewCellStyle9;
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
            this.select.HeaderText = "选择";
            this.select.Name = "select";
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StartInstall_Btn
            // 
            this.StartInstall_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartInstall_Btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartInstall_Btn.IsScaled = false;
            this.StartInstall_Btn.Location = new System.Drawing.Point(697, 471);
            this.StartInstall_Btn.MinimumSize = new System.Drawing.Size(1, 1);
            this.StartInstall_Btn.Name = "StartInstall_Btn";
            this.StartInstall_Btn.Size = new System.Drawing.Size(100, 35);
            this.StartInstall_Btn.TabIndex = 101;
            this.StartInstall_Btn.Text = "开始安装";
            this.StartInstall_Btn.Click += new System.EventHandler(this.StartInstall_Btn_Click);
            // 
            // Loading_Progress
            // 
            this.Loading_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Loading_Progress.BackColor = System.Drawing.Color.Transparent;
            this.Loading_Progress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Loading_Progress.IsScaled = false;
            this.Loading_Progress.Location = new System.Drawing.Point(-1, 459);
            this.Loading_Progress.MinimumSize = new System.Drawing.Size(1, 1);
            this.Loading_Progress.Name = "Loading_Progress";
            this.Loading_Progress.Size = new System.Drawing.Size(55, 55);
            this.Loading_Progress.TabIndex = 102;
            this.Loading_Progress.Text = "uiProgressIndicator1";
            // 
            // StatusText_Label
            // 
            this.StatusText_Label.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.StatusText_Label.Location = new System.Drawing.Point(65, 471);
            this.StatusText_Label.Name = "StatusText_Label";
            this.StatusText_Label.Size = new System.Drawing.Size(583, 35);
            this.StatusText_Label.TabIndex = 103;
            this.StatusText_Label.Text = "Waiting......";
            this.StatusText_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status_Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 528);
            this.Controls.Add(this.StatusText_Label);
            this.Controls.Add(this.Loading_Progress);
            this.Controls.Add(this.StartInstall_Btn);
            this.Controls.Add(this.Mods_GridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Status_Label";
            this.Text = "Mod列表";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Status_Label_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Mods_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Sunny.UI.UIDataGridView Mods_GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private Sunny.UI.UIButton StartInstall_Btn;
        private Sunny.UI.UIProgressIndicator Loading_Progress;
        private Sunny.UI.UILabel StatusText_Label;
    }
}