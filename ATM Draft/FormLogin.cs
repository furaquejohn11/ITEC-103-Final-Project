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
    public partial class FormLogin : Form
    {
        private string id;
        private int numOfTries = 3;
        public FormLogin(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            label2.Text = id;
        }


        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Submit();
        }
        private async void Submit()
        {
            bool isValid = await CheckAccount();
            if (isValid)
            {
                var frmMain = new FormMain(id);
                frmMain.Show();
                this.Hide();

            }
            else
            {
                numOfTries--;
                MessageBox.Show("WRONG PASSWORD TRY AGAIN! " + numOfTries + " left!");
                mtxtPIN.Text = "";
            }
        }
        private async Task<bool> CheckAccount()
        {
            try
            {
                Database database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM tblAccounts WHERE ID = @ID AND PASSWORD = @PASSWORD";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@PASSWORD", mtxtPIN.ValidateText());
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
