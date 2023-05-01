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
    public partial class FormMain : Form
    {
        private string id { get; set; }
        public FormMain(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            label2.Text = id;
            openChildForm(new FormMenu(id));
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Display other forms in the panel
        public static Form currentForm = null;
        public void openChildForm(Form childForm)
        {
            try
            {
                // Check if there's a form in panel
                if (currentForm != null) currentForm.Close();

                // Setting up the panel
                currentForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnlChildForm.Controls.Add(childForm);
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        public static void ShowFormInPanel(Form form, Panel panel)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;      
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Show();
        }



    }
}
