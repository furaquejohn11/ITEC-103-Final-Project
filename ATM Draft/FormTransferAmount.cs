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
    public partial class FormTransferAmount : Form
    {
        private string id { get; set; }
        private string receiverID { get; set; }
        private string source { get; set; }
        public FormTransferAmount(string id, string receiverID, string source)
        {
            InitializeComponent();
            this.id = id;
            this.receiverID = receiverID;
            this.source = source;
        }
        private async void btnYes_Click(object sender, EventArgs e)
        {
            if (CheckValidAmount(Convert.ToDouble(txtAmount.Text)))
            {
                await DeductOnOwnAccount();
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
        private void btnNo_Click(object sender, EventArgs e)
        {

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

        private async Task DeductOnOwnAccount()
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
                                    await UpdateOwnAccount(newBalance, connection);


                                    double receiverNewBalance = await GetReceiverBalance(connection) + amount;
                                    await TransferMoney(receiverNewBalance, connection);


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
        
        private async Task<double> GetReceiverBalance(SQLiteConnection connection)
        {
            try
            {
                Database database = new Database();
                                 
                string query = "SELECT * FROM tblAccounts WHERE ID = @ID";


                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", receiverID);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        reader.Read();                    
                        return Convert.ToDouble(reader[source]);      
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Receiver Balance " + ex.Message);
                return 0;
            }
        }
        private async Task UpdateOwnAccount(double newBalance, SQLiteConnection connection)
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
                        command.Parameters.AddWithValue("@SAVINGS", newBalance);
                    else
                        command.Parameters.AddWithValue("@CHECKINGS", newBalance);

                    await command.ExecuteNonQueryAsync();       
                  
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Update Balance " + ex.Message);
            }
        }
        private async Task TransferMoney(double receiverNewBalance, SQLiteConnection connection)
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
                    command.Parameters.AddWithValue("@ID", receiverID);


                    if (source == "SAVINGS")
                        command.Parameters.AddWithValue("@SAVINGS", receiverNewBalance);
                    else
                        command.Parameters.AddWithValue("@CHECKINGS", receiverNewBalance);

                    await command.ExecuteNonQueryAsync();

                    double amount = double.Parse(txtAmount.Text);
                    MessageBox.Show("You successfully sent PHP " + amount.ToString("N2"));

                    var frmWelcome = new FormWelcome();
                    frmWelcome.Show();

                    var frmMain = (FormMain)this.ParentForm;
                    frmMain.Hide();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Update Balance " + ex.Message);
            }
        }


    }
}
