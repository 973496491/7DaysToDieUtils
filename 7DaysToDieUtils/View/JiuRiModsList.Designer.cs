
namespace _7DaysToDieUtils.View
{
    partial class JiuriModsList
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mods_GridView = new Sunny.UI.UIDataGridView();
            this.StartInstall_Btn = new Sunny.UI.UIButton();
            this.Loading_Progress = new Sunny.UI.UIProgressIndicator();
            this.StatusText_Label = new Sunny.UI.UILabel();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Mods_GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Mods_GridView.BackgroundColor = System.Drawing.Color.White;
            this.Mods_GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mods_GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Mods_GridView.ColumnHeadersHeight = 32;
            this.Mods_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Mods_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Mods_GridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.Mods_GridView.EnableHeadersVisualStyles = false;
            this.Mods_GridView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mods_GridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Mods_GridView.Location = new System.Drawing.Point(3, 38);
            this.Mods_GridView.Name = "Mods_GridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mods_GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.Mods_GridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Mods_GridView.RowTemplate.Height = 23;
            this.Mods_GridView.SelectedIndex = -1;
            this.Mods_GridView.ShowGridLine = true;
            this.Mods_GridView.Size = new System.Drawing.Size(794, 409);
            this.Mods_GridView.TabIndex = 1;
            this.Mods_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mods_GridView_CellContentClick);
            this.Mods_GridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mods_GridView_CellValueChanged);
            this.Mods_GridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.Mods_GridView_CurrentCellDirtyStateChanged);
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
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // JiuriModsList
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
            this.Name = "JiuriModsList";
            this.Text = "Mod列表";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Status_Label_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Mods_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Sunny.UI.UIDataGridView Mods_GridView;
        private Sunny.UI.UIButton StartInstall_Btn;
        private Sunny.UI.UIProgressIndicator Loading_Progress;
        private Sunny.UI.UILabel StatusText_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
    }
}