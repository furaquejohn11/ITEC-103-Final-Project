﻿using System;
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
        public FormWithdraw(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormWithdraw_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frmMenu = new FormMenu(id);
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(frmMenu, mainForm.pnlChildForm);
        }
    }
}