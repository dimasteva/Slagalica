using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slagalica_
{
    public partial class Skocko : Form
    {
        Home home;
        Random rnd = new Random();

        int[] combination = { 0, 0, 0, 0 };
        int[] guess = { -1, -1, -1, -1 };

        int row = 0;
        int countSymbols = 0;

        int positionY = 68; //Starting Y position for dynamic labels

        int time = 90; //Seconds
        public Skocko(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void Skocko_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                combination[i] = rnd.Next(0, 6);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    RoundedButton button = GetButton(i, j);
                    button.Click += ClearRoundedButton;
                }
            }
        }

        private void ClearRoundedButton(object sender, EventArgs e)
        {
            if (sender is RoundedButton button)
            {
                if (button.Text != "")
                    countSymbols--;

                button.Text = "";

                bOK.Visible = false;
            }

            /*if (sender is RoundedButton button)
            {
                if (int.TryParse(button.Name.Replace("roundedButton", ""), out int buttonNumber))
                {
                    int buttonRow = (buttonNumber - 1) / 4;

                    if (buttonRow == row)
                    {
                        if (button.Text != "")
                            countSymbols--;

                        button.Text = "";

                        bOK.Visible = false;
                    }
                }
            }
            */
        }

        private RoundedButton GetButton(int row, int col)
        {

            string buttonName = "roundedButton" + (row * 4 + col);

            Control[] controls = Controls.Find(buttonName, true);

            if (controls.Length > 0 && controls[0] is RoundedButton button)
            {
                return button;
            }

            return null;
        }

        private void SetField(int x)
        {
            for (int i = 1; i <= 4; i++)
            {
                RoundedButton button = GetButton(row, i);

                if (button != null && button.Text == "")
                {
                    string s = "";

                    switch(x)
                    {
                        case 0:
                            s = "🦉"; break;
                        case 1:
                            s = "♣"; break;
                        case 2:
                            s = "♠"; break;
                        case 3:
                            s = "💙"; break;
                        case 4:
                            s = "♦"; break;
                        case 5:
                            s = "🌟"; break;
                        default:
                            s = "Error"; break;
                    }

                    button.Text = s;

                    guess[i - 1] = x;
                    countSymbols++;

                    if (countSymbols == 4)
                        bOK.Visible = true;

                    break;
                }
            }
        }

        private void bOwl_Click(object sender, EventArgs e)
        {
            SetField(0);
        }

        private void bClubs_Click(object sender, EventArgs e)
        {
            SetField(1);
        }

        private void bSpades_Click(object sender, EventArgs e)
        {
            SetField(2);
        }

        private void bHearts_Click(object sender, EventArgs e)
        {
            SetField(3);
        }

        private void bDiamonds_Click(object sender, EventArgs e)
        {
            SetField(4);
        }

        private void bStars_Click(object sender, EventArgs e)
        {
            SetField(5);
        }

        private void CreateLabel(int red, int yellow)
        {
            // Ensure that the total number of circles does not exceed 4
            int totalCircles = red + yellow;
            if (totalCircles > 4)
            {
                throw new ArgumentException("The total number of circles (red + yellow) must not exceed 4.");
            }

            // Create a PictureBox
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(150, 50);
            pictureBox.Location = new Point(265, positionY);
            pictureBox.BackColor = Color.Transparent;

            // Create a Bitmap to draw circles
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            // Draw circles on the Bitmap
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                DrawCircles(g, red, yellow);
            }

            // Set the Image property of the PictureBox
            pictureBox.Image = bitmap;

            // Add the PictureBox to the form
            Controls.Add(pictureBox);

            positionY += 67;
        }

        private void DrawCircles(Graphics g, int red, int yellow)
        {
            // Calculate circle dimensions
            int circleSize = 30;
            int padding = 5;

            // Draw red circles
            for (int i = 0; i < red; i++)
            {
                g.FillEllipse(Brushes.Red, i * (circleSize + padding), 0, circleSize, circleSize);
            }

            // Draw yellow circles
            for (int i = 0; i < yellow; i++)
            {
                g.FillEllipse(Brushes.Yellow, (red + i) * (circleSize + padding), 0, circleSize, circleSize);
            }

            // Draw black circles
            for (int i = red + yellow; i < 4; i++)
            {
                g.FillEllipse(Brushes.Black, i * (circleSize + padding), 0, circleSize, circleSize);
            }
        }


        private void ShowStatus()
        {
            //Calculating occurences
            int yellow = 0;
            int red = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == combination[i])
                    red++;
            }

            int[] combinationCopy = (int[])combination.Clone();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (guess[i] == combinationCopy[j])
                    {
                        yellow++;
                        combinationCopy[j] = -1;
                        break;
                    }
                }    
            }
            
            yellow -= red;


            CreateLabel(red, yellow);

            if (red == 4)
            {
                timer1.Stop();
                home.skockoPoints = (7 - row + 1) * 5;

                //home.success.Play();
                MessageBox.Show("You got the combination right. You earned " + home.skockoPoints + " points.");
                
                ShowCorrectCombination();
            } else if (row == 7)
            {
                timer1.Stop();

                MessageBox.Show("You lost. Better luck next time. You earned " + home.skockoPoints + " points.");

                ShowCorrectCombination();
            }
        }

        private void DisableButtons()
        {
            for (int i = 1; i <= 4; i++)
            {
                RoundedButton roundedButton = GetButton(row, i);
                if (roundedButton != null)
                    roundedButton.Enabled = false;
            }
        }

        private void roundedButton29_Click(object sender, EventArgs e) //bOk RoundedButton
        {
            bOK.Visible = false;
            bOK.Location = new System.Drawing.Point(bOK.Location.X, bOK.Location.Y + 67);

            countSymbols = 0;

            DisableButtons();
            row++;

            ShowStatus();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (time - 1).ToString();
            time--;
            if (time <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Time's up! You lost :(. You earned " + home.skockoPoints + " points.");

                ShowCorrectCombination();
            }
        }
        private void ShowCorrectCombination()
        {
            bOwl.Enabled = false;
            bClubs.Enabled = false;
            bSpades.Enabled = false;
            bHearts.Enabled = false;
            bDiamonds.Enabled = false;
            bStars.Enabled = false;
            bOK.Visible = false;

            for (int i = 0; i < 4; i++)
            {
                string s = "";

                switch (combination[i])
                {
                    case 0:
                        s = "🦉"; break;
                    case 1:
                        s = "♣"; break;
                    case 2:
                        s = "♠"; break;
                    case 3:
                        s = "💙"; break;
                    case 4:
                        s = "♦"; break;
                    case 5:
                        s = "🌟"; break;
                    default:
                        s = "Error"; break;
                }
                switch(i)
                {
                    case 0:
                        bC1.Text = s; break;
                    case 1:
                        bC2.Text = s; break;
                    case 2:
                        bC3.Text = s; break;
                    case 3:
                        bC4.Text = s; break;
                }
            }
            label5.Visible = true;
            bC1.Visible = true;
            bC2.Visible = true;
            bC3.Visible = true;
            bC4.Visible = true;
        }

        private void roundedButton29_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
