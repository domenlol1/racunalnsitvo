using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int card1, card2;
        Score score = new Score(0, 0);

        private void BtnReset_Click(object sender, EventArgs e)
        {
            score.resetScore();
            pl1score.Text = score.Player1.ToString();
            pl2score.Text = score.Player2.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("score.txt");
                //score = new Score(int.Parse(sr.ReadLine()), int.Parse(sr.ReadLine()));
                MessageBox.Show(string.Format("Prejšnja igra rezultat: {0} : {1}", sr.ReadLine(), sr.ReadLine()));
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            card1 = random.Next(1, 23);
            card2 = random.Next(1, 23);

            if (card1 > card2)
            {
                score.Player1 = int.Parse(pl1score.Text);
                score.Player1++;
                pl1score.Text = score.Player1.ToString();
                border1.ImageLocation = string.Format("{0}Resources\\zmaga.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                border2.ImageLocation = string.Format("{0}Resources\\zguba.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));


            }
            else if (card1 < card2)
            {
                score.Player2 = int.Parse(pl2score.Text);
                score.Player2++;
                pl2score.Text = score.Player2.ToString();
                border1.ImageLocation = string.Format("{0}Resources\\zguba.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                border2.ImageLocation = string.Format("{0}Resources\\zmaga.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            }
            else
            {
                border1.ImageLocation = string.Format("{0}Resources\\border.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                border2.ImageLocation = string.Format("{0}Resources\\border.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));

            }

            karta1.ImageLocation = string.Format("{0}Resources\\auto{1}.png", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")), card1.ToString());
            karta2.ImageLocation = string.Format("{0}Resources\\auto{1}.png", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")), card2.ToString());


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            shrani();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        void shrani()
        {
            try
            {
                using(StreamWriter sw = new StreamWriter("score.txt"))
                {
                    sw.WriteLine(score.Player1);
                    sw.WriteLine(score.Player2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
