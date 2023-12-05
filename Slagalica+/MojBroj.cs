using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slagalica_
{
    public partial class MojBroj : Form
    {
        Home home;
        Random rnd = new Random();
        string connectionString = Home.connectionString;

        int time = 90;
        int points = 0;

        int number;
        int number1, number2, number3, number4, number5, number6;

        private void MojBroj_Load(object sender, EventArgs e)
        {
            bBackSpace.Click += bBackSpace_Click;
            bBackSpace.MouseDown += bBackSpace_MouseDown;
            bBackSpace.MouseUp += bBackSpace_MouseUp;

            for (int i = 3; i <= 15; i++)
            {
                if (i == 13)
                    continue;
                RoundedButton button = (RoundedButton)Controls.Find("Roundedbutton" + i, true)[0];
                button.Click += Button_Clicked;
            }
        }
        private bool isButtonHeld = false;
        private Timer holdTimer;
        int openBrackets = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            RoundedButton rounded = (RoundedButton)sender;
            if (rounded.Text.All(char.IsDigit))
            {
                if (textBox1.Text.Length < 1)
                {
                    textBox1.Text += rounded.Text;
                    rounded.Enabled = false;
                }
                else if (!char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]) && textBox1.Text[textBox1.Text.Length - 1] != ')')
                {
                    textBox1.Text += rounded.Text;
                    rounded.Enabled = false;
                }
            } else
            {
                if (rounded.Text == "(")
                {
                    if (textBox1.Text.Length < 1)
                    {
                        textBox1.Text += rounded.Text;
                        openBrackets++;
                    }
                    else if (!char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]) && textBox1.Text[textBox1.Text.Length - 1] != ')')
                    {
                        textBox1.Text += rounded.Text;
                        openBrackets++;
                    }
                }
                else if (rounded.Text == ")")
                {
                    if (textBox1.Text.Length < 1)
                    {
                        return;
                    }
                    else if ((char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]) || textBox1.Text[textBox1.Text.Length - 1] == ')') && openBrackets > 0)
                    {
                        textBox1.Text += rounded.Text;
                        openBrackets--;
                    }
                }
                else if (textBox1.Text.Length >= 1)
                {
                    if (char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]) || textBox1.Text[textBox1.Text.Length - 1] == ')')
                    {
                        textBox1.Text += rounded.Text;
                    }
                }
            }
                
        }
        private void bBackSpace_Click(object sender, EventArgs e)
        {
            if (!isButtonHeld)
            {
                // Delete all logic
                for (int i = 2; i <= 8; i++)
                {
                    RoundedButton button = (RoundedButton)Controls.Find("Roundedbutton" + i, true)[0];
                    button.Enabled = true;
                }
                openBrackets = 0;
                textBox1.Clear();
            }
            else
            {
                // Delete one letter logic
                if (textBox1.Text.Length != 0)
                {
                    string c = textBox1.Text[textBox1.Text.Length - 1].ToString();

                    if (textBox1.Text.Length > 1 && c.All(char.IsDigit))
                    {
                        if (char.IsDigit(textBox1.Text[textBox1.Text.Length - 2]))
                        {
                            c += textBox1.Text[textBox1.Text.Length - 2];
                            c = new string(c.Reverse().ToArray());
                        }
                    }
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    if (c.Length == 2)
                        textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                    if (c == "(")
                        openBrackets--;
                    else if (c == ")")
                        openBrackets++;

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

        private void roundedButton2_Click(object sender, EventArgs e)
        {

            try
            {
                string expression = textBox1.Text;

                DataTable table = new DataTable();
                DataColumn column = new DataColumn("Expr", typeof(double), expression);
                table.Columns.Add(column);
                DataRow row = table.NewRow();
                table.Rows.Add(row);

                double result = (double)row["Expr"];

                int numAbs = Math.Abs(number - Convert.ToInt32(result));
                if (numAbs == 0)
                {
                    points = 30;
                }
                else if (numAbs <= 1)
                {
                    points = 20;
                } else if (numAbs <= 5)
                {
                    points = 10;
                } else if (numAbs <= 10)
                {
                    points = 5;
                } else
                {
                    points = 0;
                }

                //home.success.Play();

                MessageBox.Show("Your number was " + Convert.ToInt32(result) +"\n" + "You earned " + points + " points");

                home.mojBrojPoints = points;
                timer2.Stop();

                roundedButton2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }

        private void bBackSpace_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time--;
            label2.Text = time.ToString();

            if (time == 0)
            {
                timer2.Stop();
                MessageBox.Show("Time's up, you earned 0 points");
                roundedButton2.Enabled = false;
            }
        }

        private void roundedButton16_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public MojBroj(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void RetrieveData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT trial_number_2, number1, number2, number3, number4, number5, number6 FROM mojbroj ORDER BY RANDOM() LIMIT 1;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                number = Convert.ToInt32(reader["trial_number_2"]);
                                number1 = Convert.ToInt32(reader["number1"]);
                                number2 = Convert.ToInt32(reader["number2"]);
                                number3 = Convert.ToInt32(reader["number3"]);
                                number4 = Convert.ToInt32(reader["number4"]);
                                number5 = Convert.ToInt32(reader["number5"]);
                                number6 = Convert.ToInt32(reader["number6"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            roundedButton1.Text = rnd.Next(100, 1000).ToString();
            for (int i = 3; i <= 6; i++)
            {
                RoundedButton roundedButton = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                roundedButton.Text = rnd.Next(1, 10).ToString();
            }
            roundedButton7.Text = (rnd.Next(1, 4) * 5).ToString();
            roundedButton8.Text = (rnd.Next(1, 4) * 25).ToString();
        }

        private void roundedButton13_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Start();
            RetrieveData();

            roundedButton1.Text = number.ToString();
            roundedButton3.Text = number1.ToString();
            roundedButton4.Text = number2.ToString();
            roundedButton5.Text = number3.ToString();
            roundedButton6.Text = number4.ToString();
            roundedButton7.Text = number5.ToString();
            roundedButton8.Text = number6.ToString();

            roundedButton13.Visible = false;

            for (int i = 2; i <= 15; i++)
            {
                RoundedButton roundedButton = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                roundedButton.Enabled = true;
            }

        }
    }
}
