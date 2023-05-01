using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ATM_Draft
{
    public partial class FormWelcome : Form
    {
        private string id { get; set; }
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void FormWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = await CheckID();

            if (isValid)
            {
                id = txtBoxID.Text;
                var frmLogin = new FormLogin(id);
                frmLogin.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("ID NOT AVAILABLE!");
            }
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

        
    }
}
