using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ATM_Draft
{
    public class HistoryRecord : Form
    {
        private string id { get;set; }
        SQLiteConnection connection { get; set; }   
        public HistoryRecord(string id, SQLiteConnection connection)
        {
            this.id = id;
            this.connection = connection;
        }
     
        public async Task UpdateSavings(double transaction, string status, double balance)
        {
            try
            {
                string query = "INSERT INTO tblHistory (ID, SOURCE, DATE_TIME, STATUS, TRANSACT, BALANCE) VALUES (@ID, @SOURCE, @DATE_TIME, @STATUS, @TRANSACT, @BALANCE)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@SOURCE", "SAVINGS");
                    command.Parameters.AddWithValue("@DATE_TIME", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@STATUS", status);
                    command.Parameters.AddWithValue("@TRANSACT", transaction);
                    command.Parameters.AddWithValue("@BALANCE",balance);

                    //MessageBox.Show("SUCCESS");

                    await command.ExecuteNonQueryAsync();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        
        public async Task UpdateCheckings(double transaction, string status, double balance)
        {
            try
            {
                string query = "INSERT INTO tblHistory (ID, SOURCE, DATE_TIME, STATUS, TRANSACT, BALANCE) VALUES (@ID, @SOURCE, @DATE_TIME, @STATUS, @TRANSACT, @BALANCE)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@SOURCE", "CHECKINGS");
                    command.Parameters.AddWithValue("@DATE_TIME", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@STATUS", status);
                    command.Parameters.AddWithValue("@TRANSACT", transaction);
                    command.Parameters.AddWithValue("@BALANCE", balance);

                    //MessageBox.Show("SUCCESS");

                    await command.ExecuteNonQueryAsync();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        
    }
}
