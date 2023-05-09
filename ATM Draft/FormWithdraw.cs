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

        private async void btnYes_Click(object sender, EventArgs e)
        {
            if (CheckValidAmount(Convert.ToDouble(txtAmount.Text)))
            {
                await CheckAccount();
            }
            else
            {
                MessageBox.Show("INVALID AMOUNT!");
            }
        }
        private bool CheckValidAmount(double amount)
        {
            if (amount % 100 == 0)
            {
                return true;
            }
            return false;
        }
        private async Task CheckAccount()
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
                        command.Parameters.AddWithValue("@ID", id);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                           
                                double balance = Convert.ToDouble(reader[source]);
                                double amount = Convert.ToDouble(txtAmount.Text);
              
                                if (CheckEnoughBalance(balance, amount))
                                {
                                    double newBalance = balance - amount;                    
                                    await UpdateBalance(newBalance, connection);
                                }
                                else
                                {
                                    MessageBox.Show("Not Enough Balance!");
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check Account " + ex.Message);
            }
        }
        private bool CheckEnoughBalance(double balance, double withdraw)
        {
            if (balance <= 500)
            {
                return false;
            }

            if (balance - withdraw <= 500)
            {
                return false;
            }

            return true;
        }
        private async Task UpdateBalance(double newBalance, SQLiteConnection connection)
        {
            try
            {
                Database database = new Database();
                
                string query;
                if (source == "SAVINGS")
                    query = "UPDATE tblAccounts SET SAVINGS = @SAVINGS WHERE ID = @ID";
                else
                    query = "UPDATE tblAccounts SET CHECKINGS = @CHECKINGS WHERE ID = @ID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);


                    if (source == "SAVINGS")
                        command.Parameters.AddWithValue("@SAVINGS",newBalance);
                    else
                        command.Parameters.AddWithValue("@CHECKINGS", newBalance);

                    await command.ExecuteNonQueryAsync();

                    MessageBox.Show("YOUR NEW BALANCE IS " + newBalance);
                        
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Update Balance " + ex.Message);
            }
        }
    }
}
