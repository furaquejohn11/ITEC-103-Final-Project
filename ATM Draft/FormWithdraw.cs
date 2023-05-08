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
    public partial class FormWithdraw : Form
    {
        private string id { get; set; }
        private string source { get; set; }
        public FormWithdraw(string id, string source)
        {
            InitializeComponent();
            this.id = id;
            this.source = source;
        }

        private void FormWithdraw_Load(object sender, EventArgs e)
        {
            label3.Text = source;
        }

        // Cancel button
        private void button3_Click(object sender, EventArgs e)
        {
            var frmMenu = new FormMenu(id);
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(frmMenu, mainForm.pnlChildForm);
        }
    }
}
