using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slagalica_
{
    public partial class Slagalica : Form
    {
        Home home;

        

        string connectionString = Home.connectionString;
        string letterSet = "";

        List<RoundedButton> buttons;
        int index = 0;

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rnd = new Random();

        int time = 90;
        public Slagalica(Home home)
        {
            InitializeComponent();
            this.home = home;
            buttons = new List<RoundedButton> {roundedButton1, roundedButton2, roundedButton3, roundedButton4, roundedButton5, roundedButton6, roundedButton7, roundedButton8, roundedButton9, roundedButton10, roundedButton11, roundedButton12 };
        }
        private void Slagalica_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                RoundedButton button = (RoundedButton)Controls.Find("RoundedButton" + i, true)[0];
                button.Click += Button_Click;
            }
            letterSet = GetRandomLetterSet(connectionString);
            //label1.Text = letterSet;

            bBackSpace.Click += bBackSpace_Click;
            bBackSpace.MouseDown += bBackSpace_MouseDown;
            bBackSpace.MouseUp += bBackSpace_MouseUp;
        }
        static string GetRandomLetterSet(string connectionString)
        {
            string letterSet = "";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Count the number of rows in the LetterSets table
                string countQuery = "SELECT COUNT(*) FROM LetterSets";
                int rowCount;

                using (SQLiteCommand countCommand = new SQLiteCommand(countQuery, connection))
                {
                    rowCount = Convert.ToInt32(countCommand.ExecuteScalar());
                }

                if (rowCount > 0)
                {
                    // Generate a random row number
                    Random random = new Random();
                    int randomRow = random.Next(1, rowCount + 1);

                    // Retrieve the random letter_set
                    string query = $"SELECT letter_set FROM LetterSets WHERE trial_id_1 = {randomRow}";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                letterSet = reader["letter_set"].ToString();
                            }
                        }
                    }
                }
            }

            return letterSet;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (index != 12)
                return;
            
            RoundedButton button = (RoundedButton)sender;
            textBox1.Text += button.Text;

            button.Enabled = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (index < 12)
                buttons[index].Text = letters[rnd.Next(0, 26)].ToString();
        }

        private void roundedButton13_Click(object sender, EventArgs e) //bStop
        {
            if (index < 12)
            {
                buttons[index].Text = letterSet[index].ToString();
                index++;
            }
                
            if (index == 12)
            {
                timer2.Stop();
                timer1.Enabled = true;

                bStop.Visible = false;
                bSubmit.Visible = true;
            }
        }

        private bool isButtonHeld = false;
        private Timer holdTimer;

        private void bBackSpace_Click(object sender, EventArgs e)
        {
            if (index == 100)
                return;
            if (!isButtonHeld)
            {
                // Delete all logic
                for (int i = 1; i <= 12; i++)
                {
                    RoundedButton button = (RoundedButton)Controls.Find("Roundedbutton" + i, true)[0];
                    button.Enabled = true;
                }
                textBox1.Clear();
            }
            else
            {
                // Delete one letter logic
                if (textBox1.Text.Length != 0)
                {
                    char c = textBox1.Text[textBox1.Text.Length - 1];
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    foreach (RoundedButton button in Controls.OfType<RoundedButton>())
                    {
                        if (button.Text == c.ToString() && button.Enabled == false)
                        {
                            button.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        private void bBackSpace_MouseDown(object sender, MouseEventArgs e)
        {
            // Start the timer when the button is pressed
            isButtonHeld = true;

            // Check if the timer is already initialized
            if (holdTimer == null)
            {
                holdTimer = new Timer();
                holdTimer.Interval = 1000; // Set your desired hold duration
                holdTimer.Tick += (s, ev) =>
                {
                    holdTimer.Stop();
                    isButtonHeld = false;

                    // Trigger the click event after the hold duration
                    bBackSpace_Click(sender, EventArgs.Empty);
                };
            }

            holdTimer.Start();
        }

        private void bBackSpace_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop the timer when the button is released
            isButtonHeld = false;
            if (holdTimer != null)
            {
                holdTimer.Stop();
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;

            label1.Text = time.ToString();

            if (time <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Time's up");

                bSubmit.Enabled = false;
                index = 0; //So that Button.Click does not work

            }
        }

        static bool CheckIfStringExistsInWordList(string connectionString, string inputString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM WordList WHERE word = @inputString";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Use SQLiteParameter to avoid SQL injection
                    command.Parameters.AddWithValue("@inputString", inputString);

                    int rowCount = Convert.ToInt32(command.ExecuteScalar());

                    return rowCount > 0;
                }
            }
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            //home.success.Play();

            string guess = textBox1.Text;
            if (CheckIfStringExistsInWordList(connectionString, guess))
            {
                home.slagalicaPoints = 2 * guess.Length;
                MessageBox.Show("Word accepted, you got " + home.slagalicaPoints + " points");
                timer1.Stop();
                bSubmit.Enabled = false;
                index = 100;
            } else
            {
                MessageBox.Show("Not a valid word.");
            }
        }

        private void roundedButton13_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CheckIfStringExistsInWordList(connectionString, textBox1.Text))
            {
                label3.Text = "Word is valid 👍";
                bSubmit.Enabled = true;
            }
            else
            {
                label3.Text = "Word is not valid 👎";
                bSubmit.Enabled = false;
            }
        }

        private void bBackSpace_Click_1(object sender, EventArgs e)
        {

        }
    }
}
