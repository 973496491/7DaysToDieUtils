﻿namespace _7DaysToDieUtils.View
{
    partial class ZombieDetailForm
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
            this.Type_TextBox = new Sunny.UI.UITextBox();
            this.Content_RichText = new Sunny.UI.UIRichTextBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.Icon_Image = new System.Windows.Forms.PictureBox();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Type_TextBox
            // 
            this.Type_TextBox.ButtonSymbol = 61761;
            this.Type_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Type_TextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Type_TextBox.IsScaled = false;
            this.Type_TextBox.Location = new System.Drawing.Point(10, 310);
            this.Type_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Type_TextBox.Maximum = 2147483647D;
            this.Type_TextBox.Minimum = -2147483648D;
            this.Type_TextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.Type_TextBox.Name = "Type_TextBox";
            this.Type_TextBox.Size = new System.Drawing.Size(160, 40);
            this.Type_TextBox.TabIndex = 9;
            this.Type_TextBox.Text = "--";
            this.Type_TextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Content_RichText
            // 
            this.Content_RichText.AutoWordSelection = true;
            this.Content_RichText.BackColor = System.Drawing.Color.White;
            this.Content_RichText.FillColor = System.Drawing.Color.White;
            this.Content_RichText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Content_RichText.IsScaled = false;
            this.Content_RichText.Location = new System.Drawing.Point(180, 45);
            this.Content_RichText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Content_RichText.MinimumSize = new System.Drawing.Size(1, 1);
            this.Content_RichText.Name = "Content_RichText";
            this.Content_RichText.Padding = new System.Windows.Forms.Padding(2);
            this.Content_RichText.Size = new System.Drawing.Size(610, 495);
            this.Content_RichText.TabIndex = 10;
            this.Content_RichText.Text = "-----------";
            this.Content_RichText.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Content_RichText.WordWrap = true;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.Icon_Image);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.IsScaled = false;
            this.uiPanel1.Location = new System.Drawing.Point(10, 45);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(10, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(160, 250);
            this.uiPanel1.TabIndex = 11;
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
            // 
            // ZombieDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.Content_RichText);
            this.Controls.Add(this.Type_TextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZombieDetailForm";
            this.Text = "古神详情";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITextBox Type_TextBox;
        private Sunny.UI.UIRichTextBox Content_RichText;
        private Sunny.UI.UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox Icon_Image;
    }
}