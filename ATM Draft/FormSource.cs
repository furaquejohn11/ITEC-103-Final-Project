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
    public partial class FormSource : Form
    {
        private string id { get; set; }
        private string option { get; set; }
        public FormSource(string id, string option)
        {
            InitializeComponent();
            this.id = id;
            this.option = option;
        }

        private void OpenForm(Form form)
        {
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(form, mainForm.pnlChildForm);
        }

        private void OpenFormOption(string source)
        {
            switch (option)
            {
                case "BALANCE":
                    OpenForm(new FormBalance(id, source));
                    break;
                case "WITHDRAW":
                    OpenForm(new FormWithdraw(id, source));
                    break;
                case "TRANSFER":
                    OpenForm(new FormTransfer(id, source));
                    break;
                default:
                    break;
            }
        }

        private void btnSavings_Click(object sender, EventArgs e)
        {
            OpenFormOption("SAVINGS");
        }

        private void btnCheckings_Click(object sender, EventArgs e)
        {
            OpenFormOption("CHECKINGS");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OpenForm(new FormMenu(id));
        }

        
    }
}
