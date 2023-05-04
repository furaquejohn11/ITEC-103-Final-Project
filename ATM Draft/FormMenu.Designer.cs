namespace ATM_Draft
{
    partial class FormMenu
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
            this.btnBalance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnPrepaid = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnFastCash = new System.Windows.Forms.Button();
            this.btnCredit = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBalance
            // 
            this.btnBalance.Location = new System.Drawing.Point(114, 100);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(211, 55);
            this.btnBalance.TabIndex = 3;
            this.btnBalance.Text = "BALANCE INQUIRY";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(788, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "PLEASE PRESS THE PROPER KEY FOR YOUR DESIRED TRANSACTION";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(114, 179);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(211, 55);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "TRANSFER";
            this.btnTransfer.UseVisualStyleBackColor = true;
            // 
            // btnPrepaid
            // 
            this.btnPrepaid.Location = new System.Drawing.Point(114, 257);
            this.btnPrepaid.Name = "btnPrepaid";
            this.btnPrepaid.Size = new System.Drawing.Size(211, 55);
            this.btnPrepaid.TabIndex = 5;
            this.btnPrepaid.Text = "PREPAID AUTO RELOAD";
            this.btnPrepaid.UseVisualStyleBackColor = true;
            // 
            // btnPayments
            // 
            this.btnPayments.Location = new System.Drawing.Point(114, 333);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(211, 55);
            this.btnPayments.TabIndex = 6;
            this.btnPayments.Text = "PAYMENTS";
            this.btnPayments.UseVisualStyleBackColor = true;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(545, 100);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(211, 55);
            this.btnWithdraw.TabIndex = 7;
            this.btnWithdraw.Text = "WITHDRAW CASH";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnFastCash
            // 
            this.btnFastCash.Location = new System.Drawing.Point(545, 179);
            this.btnFastCash.Name = "btnFastCash";
            this.btnFastCash.Size = new System.Drawing.Size(211, 55);
            this.btnFastCash.TabIndex = 8;
            this.btnFastCash.Text = "FAST CASH";
            this.btnFastCash.UseVisualStyleBackColor = true;
            // 
            // btnCredit
            // 
            this.btnCredit.Location = new System.Drawing.Point(545, 257);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(211, 55);
            this.btnCredit.TabIndex = 9;
            this.btnCredit.Text = "CREDIT CARD CASH ADVANCE";
            this.btnCredit.UseVisualStyleBackColor = true;
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(545, 333);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(211, 55);
            this.btnChangePass.TabIndex = 10;
            this.btnChangePass.Text = "CHANGE PASSWORD";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.btnFastCash);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnPrepaid);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnPrepaid;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnFastCash;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Label label2;
    }
}