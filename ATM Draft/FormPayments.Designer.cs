namespace ATM_Draft
{
    partial class FormPayments
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
            this.dvgPayments = new System.Windows.Forms.DataGridView();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INFORMATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSACTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgPayments
            // 
            this.dvgPayments.AllowUserToAddRows = false;
            this.dvgPayments.AllowUserToDeleteRows = false;
            this.dvgPayments.AllowUserToResizeColumns = false;
            this.dvgPayments.AllowUserToResizeRows = false;
            this.dvgPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgPayments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dvgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DATE,
            this.INFORMATION,
            this.TRANSACTION,
            this.BALANCE});
            this.dvgPayments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dvgPayments.EnableHeadersVisualStyles = false;
            this.dvgPayments.Location = new System.Drawing.Point(57, 55);
            this.dvgPayments.Name = "dvgPayments";
            this.dvgPayments.ReadOnly = true;
            this.dvgPayments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dvgPayments.RowHeadersVisible = false;
            this.dvgPayments.Size = new System.Drawing.Size(738, 382);
            this.dvgPayments.TabIndex = 0;
            // 
            // DATE
            // 
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            // 
            // INFORMATION
            // 
            this.INFORMATION.HeaderText = "INFORMATION";
            this.INFORMATION.Name = "INFORMATION";
            this.INFORMATION.ReadOnly = true;
            // 
            // TRANSACTION
            // 
            this.TRANSACTION.HeaderText = "TRANSACTION";
            this.TRANSACTION.Name = "TRANSACTION";
            this.TRANSACTION.ReadOnly = true;
            // 
            // BALANCE
            // 
            this.BALANCE.HeaderText = "BALANCE";
            this.BALANCE.Name = "BALANCE";
            this.BALANCE.ReadOnly = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(692, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(340, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "LAST 30 HISTORY";
            // 
            // FormPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 517);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dvgPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPayments";
            this.Text = "FormHistory";
            this.Load += new System.EventHandler(this.FormPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INFORMATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSACTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
    }
}