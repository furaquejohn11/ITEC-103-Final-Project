using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Draft
{
    public partial class FormBalance : Form
    {
        private string id { get; set; }
        public FormBalance(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void FormBalance_Load(object sender, EventArgs e)
        {
            label2.Text = id;
            await CheckBalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmMenu = new FormMenu(id);
            var mainForm = (FormMain)this.ParentForm;
            FormMain.ShowFormInPanel(frmMenu, mainForm.pnlChildForm);


        }
        private async Task CheckBalance()
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
                                double current = Convert.ToDouble(reader["SAVINGS"]);
                                double available = Convert.ToDouble(reader["SAVINGS"].ToString());

                                lblCurrent.Text = "₱ " + current.ToString("N2");
                                lblAvailable.Text = "₱ " + available.ToString("N2");


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

        private void button2_Click(object sender, EventArgs e)
        {
            var frmWelcome = new FormWelcome();
            frmWelcome.Show();

            var frmMain = (FormMain)this.ParentForm;
            frmMain.Hide();
        }
    }
}
