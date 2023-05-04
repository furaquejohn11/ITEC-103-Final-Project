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
            OpenForm(new FormBalance(id));   
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            OpenForm(new FormWithdraw(id));
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            OpenForm(new FormChangePass(id));
        }
    }
}
