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
    public partial class FormDeposit : Form
    {
        private string id { get; set; }
        private string source { get; set; }
        public FormDeposit(string id, string source)
        {
            InitializeComponent();
            this.id = id;
            this.source = source;
        }

        private void FormDeposit_Load(object sender, EventArgs e)
        {

        }

        private async void btnYes_Click(object sender, EventArgs e)
        {
            double amount;

            if (Double.TryParse(txtAmount.Text, out amount ))
            {
                if (CheckValidAmount(amount))
                {
                    await CheckAccount();
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
            if (amount % 100 == 0 && amount != 0)
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

                                double newBalance = balance + amount;
                                await UpdateBalance(newBalance, connection);

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
                        command.Parameters.AddWithValue("@SAVINGS", newBalance);
                    else
                        command.Parameters.AddWithValue("@CHECKINGS", newBalance);

                    await command.ExecuteNonQueryAsync();

                    double amount = double.Parse(txtAmount.Text);
                    MessageBox.Show("You successfully deposit PHP " + amount.ToString("N2"));

                    var historyRecord = new HistoryRecord(id, connection);
                    if (source == "SAVINGS")
                    {
                        await historyRecord.UpdateSavings(amount, "DEPOSIT", newBalance);
                    }
                    else
                    {
                        await historyRecord.UpdateCheckings(amount, "DEPOSIT", newBalance);
                    }

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
        private void OpenForm(Form form)
        {
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(form, mainForm.pnlChildForm);
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            OpenForm(new FormMenu(id));
        }
    }
}
