using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Draft
{
    public partial class FormMenu : Form
    {
        private string id { get; set; }
        public FormMenu(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            label2.Text = id;
        }

        private void OpenForm(Form form)
        {
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(form, mainForm.pnlChildForm);
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            OpenForm(new FormSource(id, "BALANCE"));   
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            OpenForm(new FormSource(id, "WITHDRAW"));
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            OpenForm(new FormSource(id, "TRANSFER"));
        }
        
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            OpenForm(new FormSource(id, "DEPOSIT"));
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            OpenForm(new FormSource(id, "PAYMENTS"));
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            OpenForm(new FormChangePass(id));
        }

        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using BCASH! Press okay to exit. ");

            var frmWelcome = new FormWelcome();
            frmWelcome.Show();

            var frmMain = (FormMain)this.ParentForm;
            frmMain.Hide();
        }

        
    }
}
