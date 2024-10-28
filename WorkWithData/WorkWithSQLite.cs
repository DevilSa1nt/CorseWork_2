using System.Collections.Generic;
using System.Data.SQLite;


namespace Coursework_WinForms_Framework
{
    internal static class WorkWithSQLite
    {
        /// <summary>
        /// Recreate (or create a new) database
        /// </summary>
        public static void ReCreateDB()
        {
            using (var connection = new SQLiteConnection("Data Source=Battlesuits.db"))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connection
                };

                string _command = "CREATE TABLE Battlesuits(";
                _command += "_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, ";
                _command += "Name TEXT NOT NULL, ";
                _command += "BattlesuiteName TEXT NOT NULL, ";
                _command += "Birthday TEXT NOT NULL, ";
                _command += "Origin TEXT NOT NULL, ";
                _command += "Height INT NOT NULL, ";
                _command += "Weight DOUBLE NOT NULL, ";
                _command += "Type TEXT NOT NULL, "; 
                _command += "Element TEXT NOT NULL, ";
                _command += "DMG DOUBLE NOT NULL, ";
                _command += "Burst DOUBLE NOT NULL, ";
                _command += "Survival DOUBLE NOT NULL, ";
                _command += "Support DOUBLE NOT NULL, ";
                _command += "Ease TEXT DOUBLE NULL, ";
                _command += "Control DOUBLE NOT NULL";
                _command += ")";

                command.CommandText = _command;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add data to database
        /// </summary>
        /// <param name="battlesuits">List of new data</param>
        public static void AddData(List<Battlesuite> battlesuits)
        {
            using (var connection = new SQLiteConnection("Data Source=Battlesuits.db"))
            {
                connection.Open();

                SQLiteCommand deelteCommand = new SQLiteCommand
                {
                    Connection = connection,
                    CommandText = "DELETE FROM Battlesuits"
                };

                deelteCommand.ExecuteNonQuery();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;

                List<Battlesuite> _battlesuits = battlesuits;

                foreach (Battlesuite bs in battlesuits)
                {
                    command.CommandText = $"INSERT INTO Battlesuits (Name, BattlesuiteName, Birthday, Origin, Height, Weight, Type, Element, DMG, Burst, Survival, Support, Ease, Control) VALUES (" +

                        $"'{bs[1]}', " +
                        $"'{bs[2]}', " +
                        $"'{bs[3]}', " +
                        $"'{bs[4]}', " +
                        $"'{bs[5]}', " +
                        $"'{bs[6]}', " +
                        $"'{bs[7]}', " +
                        $"'{bs[8]}', " +
                        $"'{bs[9]}', " +
                        $"'{bs[10]}', " +
                        $"'{bs[11]}', " +
                        $"'{bs[12]}', " +
                        $"'{bs[13]}', " +
                        $"'{bs[14]}')";

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
