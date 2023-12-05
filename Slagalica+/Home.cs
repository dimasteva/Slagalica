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
    public partial class Home : Form
    {
        public static string connectionString;



        List<Panel> panelList = new List<Panel>();
        int pindex = 0;

        //public SoundPlayer success = new SoundPlayer("Success Sound.wav");

        public int slagalicaPoints = 0, mojBrojPoints = 0, skockoPoints = 0, koZnaZnaPoints = 0, asocijacijePoints = 0;
        int points = 0;

        public Home()
        {
            InitializeComponent();
            panelList.Add(panel1);
            panelList.Add(panel2);
            panelList[pindex].BringToFront();

            
        }
        private void Home_Load(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            connectionString = $"Data Source={baseDirectory}slagalicaLite.sqlite;Version=3;";
        }

        private void ResetGame()
        {
            points = 0;
            skockoPoints = 0;
            mojBrojPoints = 0;
            skockoPoints = 0;
            koZnaZnaPoints = 0;
            asocijacijePoints = 0;

            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            label9.Text = "0";

            bSlagalica.Enabled = true;
            bMojBroj.Enabled = true;
            bSkocko.Enabled = true;
            bKoZnaZna.Enabled = true;
            bAsocijacije.Enabled = true;
            bSave.Enabled = true;

            bSave.Visible = false;
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            if (pindex == 0)
                pindex++;
            panelList[pindex].BringToFront();

            bContinue.Enabled = true;

            ResetGame();
        }

        private void bAsocijacije_Click(object sender, EventArgs e)
        {
            Asocijacije asocijacije = new Asocijacije(this);
            asocijacije.ShowDialog();

            bAsocijacije.Enabled = false;
            label6.Text = asocijacijePoints.ToString();

            points += asocijacijePoints;
            label9.Text = points.ToString();

            Check();
        }

        private void bKoZnaZna_Click(object sender, EventArgs e)
        {
            KoZnaZna koZnaZna = new KoZnaZna(this);
            koZnaZna.ShowDialog();

            bKoZnaZna.Enabled = false;
            label5.Text = koZnaZnaPoints.ToString();

            points += koZnaZnaPoints;
            label9.Text = points.ToString();

            Check();
        }

        private void bMojBroj_Click(object sender, EventArgs e)
        {
            MojBroj mojBroj = new MojBroj(this);
            mojBroj.ShowDialog();

            bMojBroj.Enabled = false;
            label3.Text = mojBrojPoints.ToString();

            points += mojBrojPoints;
            label9.Text = points.ToString();

            Check();
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            if (pindex == 1)
                pindex--;
            panelList[pindex].BringToFront();
        }
        
        private void bSave_Click(object sender, EventArgs e)
        {
            InsertData();
            bSave.Enabled = false;

            //success.Play();
            MessageBox.Show("Data saved");
        }

        private void roundedButton1_Click(object sender, EventArgs e) //bSlagalica
        {
            Slagalica slagalica = new Slagalica(this);
            slagalica.ShowDialog();

            label2.Text = slagalicaPoints.ToString();
            bSlagalica.Enabled = false;

            points += slagalicaPoints;
            label9.Text = points.ToString();

            Check();
        }

        private void bGameHistory_Click(object sender, EventArgs e)
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.ShowDialog();
        }

        

        private void bSkocko_Click(object sender, EventArgs e)
        {
            Skocko skocko = new Skocko(this);
            skocko.ShowDialog();

            label4.Text = skockoPoints.ToString();
            bSkocko.Enabled = false;

            points += skockoPoints;
            label9.Text = points.ToString();

            Check();
        }


        private void bContinue_Click_1(object sender, EventArgs e)
        {
            if (pindex == 0)
                pindex++;
            panelList[pindex].BringToFront();
        }

        private void Check()
        {
            if (!bSlagalica.Enabled && !bMojBroj.Enabled && !bSkocko.Enabled && !bKoZnaZna.Enabled && !bAsocijacije.Enabled)
            {
                bSave.Visible = true;
            }
        }

        private void InsertData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Assuming you have the values stored in variables
                int slagalicaResults = slagalicaPoints;
                int mojBrojResults = mojBrojPoints;
                int skockoResults = skockoPoints;
                int koZnaZnaResults = koZnaZnaPoints;
                int asocijacijeResults = asocijacijePoints;
                int finalResults = points;

                // SQLite query to insert data into the MainTable
                string insertQuery = @"INSERT INTO maintable 
                       (slagalicaresults, mojbrojresults, skockoresults, koznaznaresults, asocijacijeresults, finalresults) 
                       VALUES 
                       (@slagalicaResults, @mojBrojResults, @skockoResults, @koZnaZnaResults, @asocijacijeResults, @finalResults)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                {
                    // Add parameters to the SQLite query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@slagalicaResults", slagalicaResults);
                    cmd.Parameters.AddWithValue("@mojBrojResults", mojBrojResults);
                    cmd.Parameters.AddWithValue("@skockoResults", skockoResults);
                    cmd.Parameters.AddWithValue("@koZnaZnaResults", koZnaZnaResults);
                    cmd.Parameters.AddWithValue("@asocijacijeResults", asocijacijeResults);
                    cmd.Parameters.AddWithValue("@finalResults", finalResults);

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
