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

namespace WinformDemo_FrenchCards
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public string[] deck = new string[52];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Images/cards/cards.txt");

            int y = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                deck[y] = line;
                y++;
            }

            pictureBox1.Load("Images/cards/" + deck[0] + ".png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = hScrollBar1.Value.ToString();
            pictureBox1.Load(string.Format("Images/cards/{0}.png", deck[hScrollBar1.Value - 1]));
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
