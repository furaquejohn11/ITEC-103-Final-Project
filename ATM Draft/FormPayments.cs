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
    public partial class FormPayments : Form
    {
        private string id { get; set; }
        private string source { get; set; }
        public FormPayments(string id, string source)
        {
            InitializeComponent();
            this.id = id;
            this.source = source;
        }

        private async void FormPayments_Load(object sender, EventArgs e)
        {
            await CheckBalance();
        }

        private async Task CheckBalance()
        {
            try
            {
                Database database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM tblHistory WHERE ID = @ID AND SOURCE = @SOURCE ORDER BY DATE_TIME DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@SOURCE", source);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            
                            while (reader.Read()) 
                            {
                                double transact = Convert.ToDouble(reader["TRANSACT"]);
                                double balance = Convert.ToDouble(reader["BALANCE"]);
                                dvgPayments.Rows.Add(reader["DATE_TIME"], reader["STATUS"], 
                                                    "₱ " + transact.ToString("N2"), "₱ " + balance.ToString("N2"));
                            }
                        }
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
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(new FormMenu(id), mainForm.pnlChildForm);
        }
    }
}
