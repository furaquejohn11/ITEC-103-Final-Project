using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Draft
{
    public partial class FormTransfer : Form
    {
        private string id { get; set; }
        private string source { get; set; }
        public FormTransfer(string id, string source)
        {
            InitializeComponent();
            this.id = id;
            this.source = source;
        }

        private void FormTransfer_Load(object sender, EventArgs e)
        {

        }

        private async Task<bool> CheckID()
        {
            try
            {
                Database database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM tblAccounts WHERE ID = @ID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtBoxID.Text);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            return reader.Read();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void OpenForm(Form form)
        {
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(form, mainForm.pnlChildForm);
        }

        private async void btnYes_Click(object sender, EventArgs e)
        {
            bool isValid = await CheckID();

            if (isValid)
            {
                OpenForm(new FormTransferAmount(id, txtBoxID.Text, source));    

            }
            else
            {
                MessageBox.Show("ID NOT FOUND!");
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            OpenForm(new FormMenu(id));
        }
    }
}
