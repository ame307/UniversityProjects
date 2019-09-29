using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        const int PB_PLAYER_X = 258;
        const int PB_DEALER_X = 258;
        const int PB_PLAYER_Y = 482;
        const int PB_DEALER_Y = 12;

        int money = 1000;
        int dealAmount;
        List<string> deck = new List<string>();
        List<string> dealer = new List<string>();
        List<string> player = new List<string>();
        List<PictureBox> playerCards = new List<PictureBox>();
        List<PictureBox> dealerCards = new List<PictureBox>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dealerCards.Add(pbDealer1);
            dealerCards.Add(pbDealer2);
            playerCards.Add(pbPlayer1);
            playerCards.Add(pbPlayer2);
            
            pictureBox1.Load("Images/dealer.png");
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            dealerCards[0].SizeMode = PictureBoxSizeMode.StretchImage;
            dealerCards[0].BackColor = Color.Transparent;
            dealerCards[1].SizeMode = PictureBoxSizeMode.StretchImage;
            dealerCards[1].BackColor = Color.Transparent;
            playerCards[0].SizeMode = PictureBoxSizeMode.StretchImage;
            playerCards[0].BackColor = Color.Transparent;
            playerCards[1].SizeMode = PictureBoxSizeMode.StretchImage;
            playerCards[1].BackColor = Color.Transparent;

            DeckRead();
            Shuffle();
        }

        private void DeckRead()
        {
            StreamReader sr = new StreamReader("cards.txt");

            int y = 0;
            while (!sr.EndOfStream)
            {
                deck.Add(sr.ReadLine());
                y++;
            }
        }

        private void btDeal_Click(object sender, EventArgs e)
        {
            dealAmount = Convert.ToInt32(udDeal.Value);
            if(deck.Count < 17)
            {
                deck.Clear();
                DeckRead();
                Shuffle();
            }
            FirstDeal();
            SetUp();
        }

        private void Shuffle()
        {
            int n = deck.Count - 1;
            int k;
            string temp;

            for (int i = n - 1; i > 0; --i)
            {
                k = rnd.Next(n + 1);
                temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }

        private void FirstDeal()
        {
            player.Add(Draw());
            dealer.Add(Draw());
            player.Add(Draw());
            dealer.Add(Draw());

            dealerCards[0].Load(string.Format("Images/cards/{0}.png", dealer[0]));
            dealerCards[1].Load(string.Format("Images/cards/Back/gray_back.png"));
            playerCards[0].Load(string.Format("Images/cards/{0}.png", player[0]));
            playerCards[1].Load(string.Format("Images/cards/{0}.png", player[1]));

            lblDealerAmount.Text = int.Parse(dealer[0].Substring(0, 2)).ToString();
            lblPlayerAmount.Text = PlayerAmount().ToString();

            money = money - dealAmount;
            lblAmount.Text = money.ToString();
            btDeal.Enabled = false;
        }

        private string Draw()
        {
            if (deck.Count == 0)
            {
                return null;
            }
            else
            {
                string card = deck[0];
                deck.RemoveAt(0);
                return card;
            }
        }

        private void SetUp()
        {
            int s = PlayerAmount();
            int n = player.Count;

            if (n == 2 && s != 21)
            {
                btSurrender.Enabled = true;
                btHit.Enabled = true;
                btStand.Enabled = true;
                btDouble.Enabled = true;
            }
            else if (s < 21)
            {
                btSurrender.Enabled = false;
                btDouble.Enabled = false;
                btStand.Enabled = true;
                btHit.Enabled = true;
            }
            else if (s > 21)
            {
                dealerCards[1].Load(string.Format("Images/cards/{0}.png", dealer[1]));
                lblDealerAmount.Text = DealerAmount().ToString();
                Lose();
            }
            else
            {
                PlayerEnd();
            }
        }

        private int PlayerAmount()
        {
            int s = 0;
            int aceCount = 0;
            for (int i = 0; i < player.Count; i++)
            {
                s += int.Parse(player[i].Substring(0, 2));
                if(int.Parse(player[i].Substring(0, 2)) == 11)
                {
                    aceCount++;
                }
            }

            while(s > 21 && aceCount > 0)
            {
                s = s - 10;
                aceCount--;
            }

            return s;
        }

        private void PlayerEnd()
        {
            if(DealerPlay() == PlayerAmount() && PlayerAmount() <= 21)
            {
                Tie();
            }
            else if ((PlayerAmount() > DealerPlay() && PlayerAmount() <= 21) || DealerAmount() > 21 && PlayerAmount() <= 21)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }

        private void Tie()
        {
            lblResult.Text = string.Format("Döntetlen!");
            money = money + dealAmount;
            lblAmount.Text = money.ToString();
            Reset(); 
        }

        private void Win()
        {
            if(PlayerAmount() == 21)
            {
                lblResult.Text = string.Format("Nyertél: {0}", (int)(dealAmount * (2/3)));
                money = money + (int)(dealAmount * (2 / 3));
            }
            else
            {
                lblResult.Text = string.Format("Nyertél: {0}", dealAmount * 2);
                money = money + dealAmount * 2;
            }
            
            lblAmount.Text = money.ToString();
            Reset();
        }

        private void Lose()
        {
            lblResult.Text = string.Format("Vesztettél!");
            Reset();
        }

        private void btHit_Click(object sender, EventArgs e)
        {
            string newCard = Draw();
            player.Add(newCard);
            NewPictureBoxToPlayer(newCard);
            lblPlayerAmount.Text = PlayerAmount().ToString();

            SetUp();
        }

        private void NewPictureBoxToPlayer(string newCard)
        {
            PictureBox tempPictureBox = new PictureBox();
            tempPictureBox.Width = 138;
            tempPictureBox.Height = 211;
            tempPictureBox.Location = new System.Drawing.Point(PB_PLAYER_X + (playerCards.Count * 40), PB_PLAYER_Y);
            tempPictureBox.BackColor = Color.Transparent;
            tempPictureBox.Load(string.Format("Images/cards/{0}.png", newCard));
            tempPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(tempPictureBox);
            tempPictureBox.BringToFront();
            playerCards.Add(tempPictureBox);
        }

        private void btSurrender_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Feladtad!";
            money = money + dealAmount / 2;
            Reset();
        }

        public void Reset()
        {
            Task.Delay(5000).Wait();

            lblDealerAmount.Text = null;
            lblPlayerAmount.Text = null;
            lblResult.Text = "Sok sikert!";

            for (int n = dealerCards.Count - 1; n > 1; n--)
            {
                this.Controls.Remove(dealerCards[n]);
            }

            for (int n = playerCards.Count - 1; n > 1; n--)
            {
                this.Controls.Remove(playerCards[n]);
            }

            dealer.Clear();
            player.Clear();
            dealerCards.Clear();
            playerCards.Clear();

            pbDealer1.Image = null;
            pbDealer2.Image = null;
            pbPlayer1.Image = null;
            pbPlayer2.Image = null;

            dealerCards.Add(pbDealer1);
            dealerCards.Add(pbDealer2);
            playerCards.Add(pbPlayer1);
            playerCards.Add(pbPlayer2);

            btHit.Enabled = false;
            btStand.Enabled = false;
            btDouble.Enabled = false;
            btSurrender.Enabled = false;
            btDeal.Enabled = true;
        }

        private void btStand_Click(object sender, EventArgs e)
        {
            PlayerEnd();
            btHit.Enabled = false;
            btStand.Enabled = false;
            btDouble.Enabled = false;
            btSurrender.Enabled = false;
        }

        private int DealerPlay()
        {

            dealerCards[1].Load(string.Format("Images/cards/{0}.png", dealer[1]));
            lblDealerAmount.Text = DealerAmount().ToString();

            string newCard;

            while(DealerAmount() <= 16)
            {
                Task.Delay(2000).Wait();
                newCard = Draw();
                dealer.Add(newCard);
                lblDealerAmount.Text = DealerAmount().ToString();
                NewPictureBoxToDealer(newCard);
            }

            return DealerAmount();
        }

        private void NewPictureBoxToDealer(string newCard)
        {
            PictureBox tempPictureBox = new PictureBox();
            tempPictureBox.Width = 138;
            tempPictureBox.Height = 211;
            tempPictureBox.Location = new System.Drawing.Point(PB_DEALER_X + (dealerCards.Count * 40), PB_DEALER_Y);
            tempPictureBox.BackColor = Color.Transparent;
            tempPictureBox.Load(string.Format("Images/cards/{0}.png", newCard));
            tempPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(tempPictureBox);
            tempPictureBox.BringToFront();
            dealerCards.Add(tempPictureBox);
        }


        private int DealerAmount()
        {
            int s = 0;
            bool haveAce = false;

            for(int i=0;i<dealer.Count;i++)
            {
                s += int.Parse(dealer[i].Substring(0, 2));
                if (int.Parse(dealer[i].Substring(0, 2)) == 11 && !haveAce)
                {
                    haveAce = true;
                }
            }

            if(haveAce && s > 21)
            {
                s = s - 10;
            }

            return s;
        }

        private void btDouble_Click(object sender, EventArgs e)
        {
            string newCard = Draw();
            player.Add(newCard);
            NewPictureBoxToPlayer(newCard);
            money = money - dealAmount;
            lblAmount.Text = money.ToString();
            lblPlayerAmount.Text = PlayerAmount().ToString();
            dealAmount = dealAmount * 2;
            PlayerEnd();
        }
    }
}
