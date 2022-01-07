using System;
using System.Collections.Generic;
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

        public List<Note> GetNotes()
        {
            List<Note> notes = new List<Note>();

            // establish sql connection
            using(SqlConnection sqlConnection = new SqlConnection(CS))
            {
                // query
                string query = "SELECT * FROM Note;";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // open sql connection
                sqlConnection.Open();

                // get notes from db
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        notes.Add(new Note((int)reader[0], (string)reader[1],(double)reader[2], (double)reader[3],
                            (double)reader[4], (double)reader[5], (double)reader[6], (string)reader[7]));
                    }
                }

                // close sql connection
                sqlConnection.Close();
            }

            return notes;
        }

        public void AddNoteToDB(Note note)
        {
            /* 
             * clean up apostrophe's in expression
             * to add to DB without any errors
             */
            note.CleanUpApostrophe();

            using (SqlConnection sqlConnection = new SqlConnection(CS))
            {
                // query
                string query = "INSERT INTO Note"
                    + " VALUES"
                    + $" ('{note.DateTime.ToString("f")}',"
                    + $" {note.Anxiety}, {note.Uneasyness}, {note.Heavyness},"
                    + $" {note.Happyness}, {note.Excitement}, "
                    + $" '{note.Expression}'); ";
                Console.WriteLine($"Query: {query}");
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
