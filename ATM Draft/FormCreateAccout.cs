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
using System.Windows.Forms.VisualStyles;

namespace ATM_Draft
{
    public partial class FormCreateAccout : Form
    {
        public FormCreateAccout()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool usernameExist = await CheckUsername();

            if (!usernameExist)
            {
                await SubmitInfo();
            }
            else
            {
                MessageBox.Show("USERNAME NOT AVAILABLE");
            }
        }
        private async Task SubmitInfo()
        {
            try
            {
                if (PasswordMatched())
                {
                    var database = new Database();
                    using (var connection = new SQLiteConnection(database.strConnection))
                    {
                        await connection.OpenAsync();

                        string query = "INSERT INTO tblAccounts (ID, STATUS, PASSWORD, FIRST_NAME, LAST_NAME, SAVINGS, CHECKINGS) VALUES (@ID, @STATUS, @PASSWORD, @FIRST_NAME, @LAST_NAME, @SAVINGS, @CHECKINGS)";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID",txtUsername.Text);
                            command.Parameters.AddWithValue("@STATUS","ACTIVE");
                            command.Parameters.AddWithValue("@PASSWORD",txtPassword.Text);
                            command.Parameters.AddWithValue("@FIRST_NAME",txtFirstName.Text);
                            command.Parameters.AddWithValue("@LAST_NAME",txtLastName.Text);
                            command.Parameters.AddWithValue("@SAVINGS", 500);
                            command.Parameters.AddWithValue("@CHECKINGS", 500);

                            command.ExecuteNonQuery();

                            MessageBox.Show("YOU SUCCESSFULLY CREATED YOUR ACCOUNT");
                            this.Close();
                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Not Matched");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private bool PasswordMatched()
        {
            return txtPassword.Text == txtConfirm.Text;
        }
        private async Task<bool> CheckUsername()
        {
            try
            {
                var database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM tblAccounts WHERE ID = @ID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtUsername.Text);

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
