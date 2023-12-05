using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Slagalica_
{
    public partial class Asocijacije : Form
    {
        Home home;
        string connectionString = Home.connectionString;
        
        bool finished = false;

        int time = 90;

        bool isButtonClickFromCode = false;

        string[] columnA = new string[5];
        string[] columnB = new string[5];
        string[] columnC = new string[5];
        string[] columnD = new string[5];

        string mainColumn = string.Empty;

        int points = 30;
        int pointsA = 0, pointsB = 0, pointsC = 0, pointsD = 0;

        int solvedA = 0, solvedB = 0, solvedC = 0, solvedD = 0;


        public Asocijacije(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void Asocijacije_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                RoundedButton roundedButton = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                roundedButton.Click += Button_Click;
            }

            for (int i = 1; i <= 4; i++)
            {
                TextBox textBox = (TextBox)Controls.Find("textBox" + i, true)[0];
                textBox.KeyPress += textBox_KeyPress;
                textBox.Enter += TextBox_Enter;
            }

            textBox5.Enter += TextBox_Enter;

            RetrieveDataFromDatabase(connectionString, GetRandomTargetID(connectionString), columnA, columnB, columnC, columnD, ref mainColumn);

        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
            textBox.Clear();
        }

        static int GetRandomTargetID(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Query to get the total number of rows in the table
                string countQuery = "SELECT COUNT(*) FROM Asocijacije";

                using (SQLiteCommand countCommand = new SQLiteCommand(countQuery, connection))
                {
                    int rowCount = Convert.ToInt32(countCommand.ExecuteScalar());

                    // Use a random number generator to generate a random targetID
                    Random random = new Random();
                    int randomIndex = random.Next(1, rowCount + 1);

                    return randomIndex;
                }
            }
        }

        static void RetrieveDataFromDatabase(string connectionString, int targetID, string[] columnA, string[] columnB, string[] columnC, string[] columnD, ref string additionalString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ColumnA1, ColumnA2, ColumnA3, ColumnA4, ColumnA5, ColumnB1, ColumnB2, ColumnB3, ColumnB4, ColumnB5, ColumnC1, ColumnC2, ColumnC3, ColumnC4, ColumnC5, ColumnD1, ColumnD2, ColumnD3, ColumnD4, ColumnD5, MainColumn FROM Asocijacije WHERE ID = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", targetID);

                    try
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate arrays
                                PopulateArray(reader, "ColumnA", columnA);
                                PopulateArray(reader, "ColumnB", columnB);
                                PopulateArray(reader, "ColumnC", columnC);
                                PopulateArray(reader, "ColumnD", columnD);

                                // Populate additional string
                                additionalString = reader["MainColumn"].ToString();
                            }
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        // Handle the exception or log the error
                        Console.WriteLine($"SQLite Exception: {ex.Message}");
                        // Optionally rethrow the exception if needed
                        throw;
                    }
                }
            }
        }


        static void PopulateArray(SQLiteDataReader reader, string columnNamePrefix, string[] array)
        {
            for (int i = 1; i <= array.Length; i++)
            {
                // Adjust column name by removing spaces
                string columnName = $"{columnNamePrefix}{i}".Replace(" ", "");
                array[i - 1] = reader[columnName].ToString();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            RoundedButton button = (RoundedButton)sender;

            int buttonIndex;
            if (int.TryParse(button.Name.Replace("roundedButton", ""), out buttonIndex))
            {
                if (!isButtonClickFromCode)
                    points--;
                button.Enabled = false;
                // Determine the array and index based on the button's name
                int arrayIndex = (buttonIndex - 1) / 4;
                int elementIndex = (buttonIndex - 1) % 4;// Calculate the element index based on the button's position

                string[] selectedArray = null;

                switch (arrayIndex)
                {
                    case 0:
                        selectedArray = columnA;
                        if (solvedA == 0)
                        {
                            textBox1.Enabled = true;
                            solvedA++;
                        }
                        break;
                    case 1:
                        selectedArray = columnB;
                        if (solvedB == 0)
                        {
                            textBox2.Enabled = true;
                            solvedB++;
                        }
                        break;
                    case 2:
                        selectedArray = columnC;
                        if (solvedC == 0)
                        {
                            textBox3.Enabled = true;
                            solvedC++;
                        }
                        break;
                    case 3:
                        selectedArray = columnD;
                        if (solvedD == 0)
                        {
                            textBox4.Enabled = true;
                            solvedD++;
                        }
                        break;
                    default:
                        MessageBox.Show("Switch Error :O");
                        break;
                }

                // Set the button's text to the corresponding array element
                if (selectedArray != null && elementIndex < selectedArray.Length)
                {
                    ((RoundedButton)sender).Text = selectedArray[elementIndex];
                }
            }
        }

        private void txtCorrect(TextBox textBox, string[][] columns, int txtIndex)
        {
            textBox.Enabled = false;
            textBox.Text = columns[txtIndex][4];
            textBox.BackColor = Color.LightGreen;
            label1.Focus();
            textBox5.Enabled = true;

            for (int i = (txtIndex - 1) * 4 + 1; i <= (txtIndex - 1) * 4 + 4; i++)
            {
                RoundedButton roundedButton = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                //points++; No need because click can not be performed on a disabled button
                if (roundedButton.Enabled == true)
                {
                    switch(txtIndex)
                    {
                        case 1:
                            pointsA++;
                            break;
                        case 2:
                            pointsB++;
                            break;
                        case 3:
                            pointsC++;
                            break;
                        case 4:
                            pointsD++;
                            break;
                    }
                }
                isButtonClickFromCode = true;
                roundedButton.PerformClick();
                isButtonClickFromCode = false;
            }
        }

        private void txtIncorrect(TextBox textBox)
        {
            textBox.BackColor = textBox.BackColor = Color.FromArgb(250, 27, 50);
            label1.Focus();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
            else return;

            TextBox textBox = (TextBox)sender;

            int txtIndex;
            if (int.TryParse(textBox.Name.Replace("textBox", ""), out txtIndex))
            {
                string input = textBox.Text.Trim();
                input = input.ToLower();

                string[][] columns = { null, columnA, columnB, columnC, columnD };

                if (txtIndex >= 1 && txtIndex <= 4)
                {
                    if (input == columns[txtIndex][4].ToLower())
                        txtCorrect(textBox, columns, txtIndex);
                    else
                        txtIncorrect(textBox);
                }

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void roundedButton17_Click(object sender, EventArgs e)
        {
            /*if (textBox5.Text != mainColumn)
            {
                int lostSum = 0;
                if (textBox1.Text == columnA[4])
                    lostSum += pointsA * 2;
                if (textBox2.Text == columnB[4])
                    lostSum += pointsB * 2;
                if (textBox3.Text == columnC[4])
                    lostSum += pointsC * 2;
                if (textBox4.Text == columnD[4])
                    lostSum += pointsD * 2;
                home.asocijacijePoints = lostSum;
            } */
            if (!finished)
                Finished(false);
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowButtonText(RoundedButton button)
        {

        }

        private void Finished(bool got)
        {
            timer1.Stop();
            int lostSum = 0;

            int[] redcolor = { 0, 0, 0, 0 };

            if (!got)
            {
                if (textBox1.Text == columnA[4])
                {
                    lostSum += pointsA * 2;
                    redcolor[0] = 1;
                }
                if (textBox2.Text == columnB[4])
                {
                    lostSum += pointsB * 2;
                    redcolor[1] = 1;
                }
                if (textBox3.Text == columnC[4])
                {
                    lostSum += pointsC * 2;
                    redcolor[2] = 1;
                }
                if (textBox4.Text == columnD[4])
                {
                    lostSum += pointsD * 2;
                    redcolor[3] = 1;
                }
            }
            

            string[][] columns = { null, columnA, columnB, columnC, columnD };
            int[] solvedABCD = {solvedA, solvedB,  solvedC, solvedD };
            for (int i = 1; i <= 4; i++)
            {
                TextBox textBox = (TextBox)Controls.Find("textBox" + i, true)[0];
                txtCorrect(textBox, columns, i);
            }

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            if (redcolor[0] == 0)
                textBox1.BackColor = Color.FromArgb(250, 27, 50);
            if (redcolor[1] == 0)
                textBox2.BackColor = Color.FromArgb(250, 27, 50);
            if (redcolor[2] == 0)
                textBox3.BackColor = Color.FromArgb(250, 27, 50);
            if (redcolor[3] == 0)
                textBox4.BackColor = Color.FromArgb(250, 27, 50);
            if (!got)
            {
                textBox5.BackColor = Color.FromArgb(250, 27, 50);
                textBox5.Text = mainColumn;
                MessageBox.Show("You lost, you earned " + lostSum + " points");
                home.asocijacijePoints += lostSum;
            } else
            {
                textBox1.BackColor = Color.LightGreen;
                textBox2.BackColor = Color.LightGreen;
                textBox3.BackColor = Color.LightGreen;
                textBox4.BackColor = Color.LightGreen;
                textBox5.BackColor = Color.LightGreen;

                home.asocijacijePoints += points;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
            else return;

            string input = textBox5.Text;
            input = input.ToLower();

            if (input == mainColumn.ToLower())
            {
                timer1.Stop();

                textBox5.Text = mainColumn;
                label1.Focus();

                textBox5.Enabled = false;
                textBox5.BackColor = Color.LightGreen;

                finished = true;
               // home.success.Play();
                MessageBox.Show("You got it right, you earned " + points + " points");

                Finished(true);

            }
            else
                txtIncorrect(textBox5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label2.Text = time.ToString();

            if (time == 0)
            {
                finished = true;
                Finished(false);
            }
        }
    }
}
