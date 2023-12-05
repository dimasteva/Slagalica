using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slagalica_
{
    public partial class Scoreboard : Form
    {
        string connectionString = Home.connectionString;
        public Scoreboard()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {

            /*string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construct the path to the SQLite database file
            string dbFilePath = Path.Combine(appDirectory, "slagalicaLite.sqlite");

            // Check if the database file exists
            if (File.Exists(dbFilePath))
            {
                // Display a message box with the connection string
                string connectionString = $"Data Source={dbFilePath};Version=3;";
                MessageBox.Show($"The connection string is:\n{connectionString}", "Connection String", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Display a message box if the database file doesn't exist
                MessageBox.Show($"The SQLite database file does not exist in the application directory.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show(connectionString);
            */
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQLite query to select all data from MainTable
                    string selectQuery = "SELECT * FROM maintable ORDER BY finalResults DESC";

                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Set the DataTable as the DataSource for the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
