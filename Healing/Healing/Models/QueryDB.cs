using System;
using System.Data.SqlClient;

namespace Healing.Models
{
    public class QueryDB
    {
        public string CS { get; set; }

        public QueryDB()
        {
            CS = "Server=localhost;Database=Healing;User Id=SA;Password=myPassw0rd;";
        }

        public void AddNoteToDB(Note note)
        {
            using(SqlConnection sqlConnection = new SqlConnection(CS))
            {
                // query
                string query = "";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // open sql connection
                sqlConnection.Open();

                // add note to db
                sqlCommand.ExecuteNonQuery();

                // close sql connection
                sqlConnection.Close();
            }
        }
    }
}
