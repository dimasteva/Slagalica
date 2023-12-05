using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slagalica_
{
    public partial class KoZnaZna : Form
    {
        Home home;
        string connectionString = Home.connectionString;

        bool finished = false;

        int time = 150;
        int points = 0;

        int currentQuestion = 0;

        string question = string.Empty;
        string answerA = string.Empty , answerB = string.Empty, answerC = string.Empty, answerD = string.Empty;
        string answer = string.Empty;
        public KoZnaZna(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void KoZnaZna_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++)
            {
                RoundedButton button = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                button.Click += Button_Clicked;
            }
            GenerateQuestion();
        }

        private void EndGame()
        {
            //home.success.Play();
            MessageBox.Show("Game's over, you earned " + points + " points");

            for (int i = 1; i <= 5; i++)
            {
                RoundedButton button1 = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                button1.Enabled = false;
                button1.BackColor = Color.MediumSlateBlue;
            }

            home.koZnaZnaPoints = points;
        }

        private void GenerateQuestion()
        {
            currentQuestion++;
            if (currentQuestion == 11)
            {
                timer1.Stop();
                finished = true;
                EndGame();
                return;
            }
            label1.Text = "Question: " + currentQuestion.ToString() + "/10";
            RetrieveDataFromDatabase(connectionString, GetRandomQuestionID(connectionString), out question, out answerA, out answerB, out answerC, out answerD, out answer);

            textBox1.Text = question;

            roundedButton1.Text = answerA;
            roundedButton2.Text = answerB;
            roundedButton3.Text = answerC;
            roundedButton4.Text = answerD;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            RoundedButton button = (RoundedButton)sender;

            timer2.Start();
            if (button.Text == answer)
                points += 6;
            else
            {
                points -= 3;
                button.BackColor = Color.Red;
            }

            label2.Text = "Points: " + points;

            for (int i = 1; i <= 4; i++)
            {
                RoundedButton button1 = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                if (button1.Text == answer)
                {
                    button1.BackColor = Color.LightGreen;
                }
                button1.Enabled = false;
            }
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            timer2.Start();
            for (int i = 1; i <= 4; i++)
            {
                RoundedButton button1 = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                if (button1.Text == answer)
                {
                    button1.BackColor = Color.LightGreen;
                }
                button1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            for (int i = 1; i <= 4; i++)
            {
                RoundedButton button1 = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                button1.Enabled = true;
                button1.BackColor = Color.MediumSlateBlue;
            }

            GenerateQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label4.Text = time.ToString();

            if (time <= 0)
            {
                timer1.Stop();
                home.koZnaZnaPoints = points;
                MessageBox.Show("Time's up, you earned " + points + " points");
                finished = true;
                for (int i = 1; i <= 5; i++)
                {
                    RoundedButton button1 = (RoundedButton)Controls.Find("roundedButton" + i, true)[0];
                    button1.Enabled = false;
                    button1.BackColor = Color.MediumSlateBlue;
                }
            }
        }

        static int GetRandomQuestionID(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Query to get the minimum and maximum QuestionID in the table
                string rangeQuery = "SELECT MIN(QuestionID) AS MinID, MAX(QuestionID) AS MaxID FROM KoZnaZna";

                using (SQLiteCommand rangeCommand = new SQLiteCommand(rangeQuery, connection))
                {
                    using (SQLiteDataReader rangeReader = rangeCommand.ExecuteReader())
                    {
                        if (rangeReader.Read())
                        {
                            int minID = rangeReader.GetInt32(0);
                            int maxID = rangeReader.GetInt32(1);

                            // Use a random number generator to generate a random questionID within the range
                            Random random = new Random();
                            int randomIndex = random.Next(minID, maxID + 1);

                            return randomIndex;
                        }
                    }
                }

                // Handle the case where no data is found in the table
                throw new InvalidOperationException("No data found in the KoZnaZna table.");
            }

        }

        static void RetrieveDataFromDatabase(string connectionString, int questionID, out string questionText, out string answerA, out string answerB, out string answerC, out string answerD, out string correctAnswer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT QuestionText, AnswerA, AnswerB, AnswerC, AnswerD, Answer " +
                               "FROM KoZnaZna " +
                               "WHERE QuestionID = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", questionID);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve data
                            questionText = reader["QuestionText"].ToString();
                            answerA = reader["AnswerA"].ToString();
                            answerB = reader["AnswerB"].ToString();
                            answerC = reader["AnswerC"].ToString();
                            answerD = reader["AnswerD"].ToString();
                            correctAnswer = reader["Answer"].ToString();
                        }
                        else
                        {
                            // Handle the case where no question is found
                            throw new InvalidOperationException("No question found for the specified ID.");
                        }
                    }
                }
            }

        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                home.koZnaZnaPoints = points;
                MessageBox.Show("You earned " + points + " points");
            }
            this.Close();
        }


    }
}
