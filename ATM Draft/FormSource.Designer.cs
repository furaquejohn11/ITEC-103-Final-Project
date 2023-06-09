﻿namespace ATM_Draft
{
    partial class FormSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSource));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavings = new System.Windows.Forms.Button();
            this.pbSaving = new System.Windows.Forms.PictureBox();
            this.pbCheck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(56)))), ((int)(((byte)(107)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(225)))));
            this.btnCancel.Location = new System.Drawing.Point(587, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(211, 55);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckings
            // 
            this.btnCheckings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(56)))), ((int)(((byte)(107)))));
            this.btnCheckings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckings.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.btnCheckings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(225)))));
            this.btnCheckings.Location = new System.Drawing.Point(587, 309);
            this.btnCheckings.Name = "btnCheckings";
            this.btnCheckings.Size = new System.Drawing.Size(211, 55);
            this.btnCheckings.TabIndex = 10;
            this.btnCheckings.Text = "CHECKINGS (CA)";
            this.btnCheckings.UseVisualStyleBackColor = false;
            this.btnCheckings.Click += new System.EventHandler(this.btnCheckings_Click);
            this.btnCheckings.MouseLeave += new System.EventHandler(this.btnCheckings_MouseLeave);
            this.btnCheckings.MouseHover += new System.EventHandler(this.btnCheckings_MouseHover);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(56)))), ((int)(((byte)(107)))));
            this.label1.Location = new System.Drawing.Point(99, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 92);
            this.label1.TabIndex = 8;
            this.label1.Text = "PLEASE PRESS THE PROPER KEY  FOR YOUR DESIRED SOURCE OF ACCOUNT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSavings
            // 
            this.btnSavings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(56)))), ((int)(((byte)(107)))));
            this.btnSavings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavings.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold);
            this.btnSavings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(225)))));
            this.btnSavings.Location = new System.Drawing.Point(587, 234);
            this.btnSavings.Name = "btnSavings";
            this.btnSavings.Size = new System.Drawing.Size(211, 55);
            this.btnSavings.TabIndex = 12;
            this.btnSavings.Text = "SAVINGS";
            this.btnSavings.UseVisualStyleBackColor = false;
            this.btnSavings.Click += new System.EventHandler(this.btnSavings_Click);
            this.btnSavings.MouseLeave += new System.EventHandler(this.btnSavings_MouseLeave);
            this.btnSavings.MouseHover += new System.EventHandler(this.btnSavings_MouseHover);
            // 
            // pbSaving
            // 
            this.pbSaving.BackColor = System.Drawing.Color.Transparent;
            this.pbSaving.Image = ((System.Drawing.Image)(resources.GetObject("pbSaving.Image")));
            this.pbSaving.Location = new System.Drawing.Point(106, 189);
            this.pbSaving.Name = "pbSaving";
            this.pbSaving.Size = new System.Drawing.Size(299, 280);
            this.pbSaving.TabIndex = 13;
            this.pbSaving.TabStop = false;
            this.pbSaving.Visible = false;
            // 
            // pbCheck
            // 
            this.pbCheck.BackColor = System.Drawing.Color.Transparent;
            this.pbCheck.Image = ((System.Drawing.Image)(resources.GetObject("pbCheck.Image")));
            this.pbCheck.Location = new System.Drawing.Point(136, 187);
            this.pbCheck.Name = "pbCheck";
            this.pbCheck.Size = new System.Drawing.Size(241, 282);
            this.pbCheck.TabIndex = 14;
            this.pbCheck.TabStop = false;
            this.pbCheck.Visible = false;
            // 
            // FormSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.pbCheck);
            this.Controls.Add(this.pbSaving);
            this.Controls.Add(this.btnSavings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckings);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSource";
            this.Text = "FormSource";
            ((System.ComponentModel.ISupportInitialize)(this.pbSaving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheckings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSavings;
        private System.Windows.Forms.PictureBox pbSaving;
        private System.Windows.Forms.PictureBox pbCheck;
    }
}