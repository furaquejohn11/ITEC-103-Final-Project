using System;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace HistoryLibrary
{
    public class Payments
    {

        /* Payments library is a library that I created to handle
         * different history logs from the user.
         * I ended up to this idea because I noticed that I used
         * some sql line codes repeatedly.       
         
         
         * transaction containes what are the changes to the account
         * mode will contain if it is DEDUCTED or ADDED
        */

        private string id { get; set; }
        SQLiteConnection connection { get; set; }
        public Payments(string id, SQLiteConnection connection)
        {
            this.id = id;
            this.connection = connection;
        }
        public async Task UpdateSavings(string transaction, string status)
        {
            try
            {
                string query = "UPDATE tblHistory SET SOURCE = @SOURCE, DATE_TIME = @DATETIME, STATUS = @STATUS TRANSACTION = @TRANSACTION WHERE ID = @ID";
                                
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@SOURCE","SAVINGS");
                    command.Parameters.AddWithValue("@DATE_TIME",DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@STATUS", status);
                    command.Parameters.AddWithValue("@TRANSACTION", transaction);

                    await command.ExecuteNonQueryAsync();
                   

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
        /*
        public async Task UpdateCheckings(string updateInfo)
        {

        }
        */
        
    }
}