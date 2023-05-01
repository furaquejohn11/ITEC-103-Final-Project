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

        private void btnBalance_Click(object sender, EventArgs e)
        {
            var frmBalance = new FormBalance(id);
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(frmBalance, mainForm.pnlChildForm);
            



        }

        
    }
}
