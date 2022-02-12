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

        private bool IsValid()
        {
            bool state = false;

            List<string> sqlInjections = new List<string>();

            sqlInjections.Add("-");
            sqlInjections.Add("--");
            sqlInjections.Add("LIKE");
            sqlInjections.Add(";");
            sqlInjections.Add("SELECT");
            sqlInjections.Add("*");
            sqlInjections.Add("FROM");

            return state;
        }

        public Note GetNote(int id)
        {
            Note note = new Note();
            // establish sql connection
            using(SqlConnection sqlConnection = new SqlConnection(CS))
            {
                // query
                string query = "SELECT * FROM Note"
                    + $" WHERE ID = {id};";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // open sql connection
                sqlConnection.Open();

                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // cast string to DateTime
                        DateTime dateTime = DateTime.Parse((string)reader[1],
                          System.Globalization.CultureInfo.InvariantCulture);

                        note = new Note((int)reader[0], dateTime, (double)reader[2],
                            (double)reader[3], (double)reader[4], (double)reader[5], (double)reader[6],
                            (string)reader[7]);
                    }
                }

                // close sql connection
                sqlConnection.Close();
            }

            return note;
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
                        // cast string to DateTime
                        DateTime dateTime = DateTime.Parse((string)reader[1],
                          System.Globalization.CultureInfo.InvariantCulture);

                        notes.Add(new Note((int)reader[0], dateTime,(double)reader[2], (double)reader[3],
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

            string query = "";
            if(note.DateString != null)
            {
                // query
                query = "INSERT INTO Note"
                    + " VALUES"
                    + $" ('{note.DateString}',"
                    + $" {note.Anxiety}, {note.Uneasyness}, {note.Heavyness},"
                    + $" {note.Happyness}, {note.Excitement}, "
                    + $" '{note.Expression}'); ";
            } else
            {
                // query
                query = "INSERT INTO Note"
                    + " VALUES"
                    + $" ('{note.DateTime.ToString("f")}',"
                    + $" {note.Anxiety}, {note.Uneasyness}, {note.Heavyness},"
                    + $" {note.Happyness}, {note.Excitement}, "
                    + $" '{note.Expression}'); ";
            }

            using (SqlConnection sqlConnection = new SqlConnection(CS))
            {               
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // open sql connection
                sqlConnection.Open();

                // add note to db
                sqlCommand.ExecuteNonQuery();

                // close sql connection
                sqlConnection.Close();
            }
        }

        public void EditNote(Note note)
        {
            // establish sql connection
            using(SqlConnection sqlConnection = new SqlConnection(CS))
            {
                note.CleanUpApostrophe();
                // query
                string query = "UPDATE Note"
                    + $" SET DateTimeStamp = '{note.DateString}', Anxiety = {note.Anxiety}, Uneasyness = {note.Uneasyness},"
                    + $" Happyness = {note.Happyness}, Excited = {note.Excitement}, Expression = '{note.Expression}'"
                    + $" WHERE ID = {note.ID};";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // open sql connection
                sqlConnection.Open();

                // update db
                sqlCommand.ExecuteNonQuery();

                // close sql connection
                sqlConnection.Close();
            }
        }
    }
}
