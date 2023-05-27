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
    public partial class FormChangePass : Form
    {
        private string id { get; set; }
        public FormChangePass(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = await CheckPass();

            if (isValid)
            {
                if (txtNewPass.Text == txtConfirm.Text)
                {
                    await UpdatePassword(txtNewPass.Text);
                }
                else
                {
                    MessageBox.Show("Your New Password and Confirm Password does not match");
                }
            }
            else
            {
                MessageBox.Show("Your Password is incorrect!");
            }
        }
        private async Task<bool> CheckPass()
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
                        command.Parameters.AddWithValue("@PASSWORD", txtCurrentPass.Text);
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
        private async Task UpdatePassword(string newPassword)
        {
            try
            {
                Database database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "UPDATE tblAccounts SET PASSWORD = @PASSWORD WHERE ID = @ID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@PASSWORD", newPassword);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Your Password has been successfully changed!");
                        GotoMenu();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            GotoMenu();
        }
        private void GotoMenu()
        {
            var frmMenu = new FormMenu(id);
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(frmMenu, mainForm.pnlChildForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using BCASH! Press okay to exit. ");

            var frmWelcome = new FormWelcome();
            frmWelcome.Show();

            var frmMain = (FormMain)this.ParentForm;
            frmMain.Hide();
        }
    }
}
