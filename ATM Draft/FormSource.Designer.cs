namespace ATM_Draft
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(587, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(211, 55);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckings
            // 
            this.btnCheckings.Location = new System.Drawing.Point(587, 309);
            this.btnCheckings.Name = "btnCheckings";
            this.btnCheckings.Size = new System.Drawing.Size(211, 55);
            this.btnCheckings.TabIndex = 10;
            this.btnCheckings.Text = "CHECKINGS (CA)";
            this.btnCheckings.UseVisualStyleBackColor = true;
            this.btnCheckings.Click += new System.EventHandler(this.btnCheckings_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 67);
            this.label1.TabIndex = 8;
            this.label1.Text = "PLEASE PRESS THE PROPER KEY  FOR YOUR DESIRED SOURCE OF ACCOUNT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSavings
            // 
            this.btnSavings.Location = new System.Drawing.Point(587, 234);
            this.btnSavings.Name = "btnSavings";
            this.btnSavings.Size = new System.Drawing.Size(211, 55);
            this.btnSavings.TabIndex = 12;
            this.btnSavings.Text = "SAVINGS";
            this.btnSavings.UseVisualStyleBackColor = true;
            this.btnSavings.Click += new System.EventHandler(this.btnSavings_Click);
            // 
            // FormSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.btnSavings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckings);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSource";
            this.Text = "FormSource";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheckings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSavings;
    }
}