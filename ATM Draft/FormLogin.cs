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
                if (numOfTries <= 0)
                {
                    await DisableAccount();
                }
                else
                {
                    MessageBox.Show("WRONG PASSWORD TRY AGAIN! " + numOfTries + " left!");
                }
                
                mtxtPIN.Clear();
            }
        }
        private async Task DisableAccount()
        {
            

            try
            {
                var database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "UPDATE tblAccounts SET STATUS = @STATUS WHERE ID = @ID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@STATUS", "BLOCKED");

                        await command.ExecuteNonQueryAsync();

                        MessageBox.Show("YOUR ACCOUNT IS CURRENTLY BLOCKED");

                        var frmWelcome = new FormWelcome();
                        frmWelcome.Show();

                        this.Hide();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        command.Parameters.AddWithValue("@PASSWORD", mtxtPIN.Text);
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

        private void mtxtPIN_Enter(object sender, EventArgs e)
        {
            mtxtPIN.SelectionStart = 0;
        }

        private void mtxtPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Submit();
            }
        }
    }
}
