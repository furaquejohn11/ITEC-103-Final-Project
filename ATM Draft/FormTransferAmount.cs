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
            double amount;

            if (Double.TryParse(txtAmount.Text, out amount))
            {
                if (CheckValidAmount(amount))
                {
                    await DeductOnOwnAccount();
                }
                else
                {
                    MessageBox.Show("INVALID AMOUNT!");
                }
            }
            else
            {
                MessageBox.Show("AMOUNT MUST NOT BE EMPTY!");
            }
        }
        private bool CheckValidAmount(double amount)
        {
            if (amount % 100 == 0 && amount != 0 && amount == 10000)
            {
                return true;
            }
            return false;
        }

        private void OpenForm(Form form)
        {
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(form, mainForm.pnlChildForm);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            OpenForm(new FormMenu(id));
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
                                    // UPDATE SENDER ACCOUNT
                                    double newBalance = balance - amount;
                                    await UpdateOwnAccount(newBalance, connection);
                                    var historyRecord = new HistoryRecord(id, connection);
                                    if (source == "SAVINGS")
                                    {
                                        await historyRecord.UpdateSavings(amount, "SENT TO " + receiverID , newBalance);
                                    }
                                    else
                                    {
                                        await historyRecord.UpdateCheckings(amount, "SENT TO " + receiverID, newBalance);
                                    }


                                    // UPDATE RECEIVER ACCOUNT
                                    double receiverNewBalance = await GetReceiverBalance(connection) + amount;
                                    await TransferMoney(receiverNewBalance, connection);

                                    var receiverHistoryRecord = new HistoryRecord(receiverID, connection);
                                    if (source == "SAVINGS")
                                    {
                                        await receiverHistoryRecord.UpdateSavings(amount, "RECEIVED FROM " + id, receiverNewBalance);
                                    }
                                    else
                                    {
                                        await receiverHistoryRecord.UpdateCheckings(amount, "RECEIVED FROM " + id, receiverNewBalance);
                                    }


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
