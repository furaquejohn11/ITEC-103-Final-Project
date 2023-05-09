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
    public partial class FormSource : Form
    {
        private string id { get; set; }
        public FormSource(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void OpenForm(Form form)
        {
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(form, mainForm.pnlChildForm);
        }

        private void btnSavings_Click(object sender, EventArgs e)
        {
            OpenForm(new FormWithdraw(id, "SAVINGS"));
        }

        private void btnCheckings_Click(object sender, EventArgs e)
        {
            OpenForm(new FormWithdraw(id, "CHECKINGS"));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OpenForm(new FormMenu(id));
        }

        
    }
}