using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using BJ;
using System.Threading;

namespace BlackJackClient
{
    public partial class Form1 : Form
    {
        const int PB_PLAYER_X = 258;
        const int PB_DEALER_X = 258;
        const int PB_PLAYER_Y = 482;
        const int PB_DEALER_Y = 12;

        List<string> dealer = new List<string>();
        List<string> player = new List<string>();
        List<PictureBox> playerCards = new List<PictureBox>();
        List<PictureBox> dealerCards = new List<PictureBox>();

        static Channel channel;
        BJ.BJ.BJClient client;
        string uid = null;

        private async void Reset()
        {
            await Task.Delay(5000);

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

            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnDouble.Enabled = false;
            btnSurrender.Enabled = false;
            btnDeal.Enabled = true;
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

        private void SetLabels(GameResult gr)
        {
            lblAmount.Text = gr.Money;
            lblPlayerAmount.Text = gr.PlayerAmount;
            lblDealerAmount.Text = gr.DealerAmount;
            lblResult.Text = gr.Result;
        }

        private void SetForm(string result, int playerCardsCount)
        {
            if(IsTheEnd(result))
            {
                btnDeal.Enabled = true;
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                btnDouble.Enabled = false;
                btnSurrender.Enabled = false;
            }
            else if(playerCardsCount == 2)
            {
                btnDeal.Enabled = false;
                btnHit.Enabled = true;
                btnStand.Enabled = true;
                btnDouble.Enabled = true;
                btnSurrender.Enabled = true;
            }
            else
            {
                btnDeal.Enabled = false;
                btnHit.Enabled = true;
                btnStand.Enabled = true;
                btnDouble.Enabled = false;
                btnSurrender.Enabled = false;
            }
        }

        private bool IsTheEnd(string result)
        {
            if (result != "Sok sikert!")
            {
                Reset();
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            channel = new Channel("127.0.0.1:50052", Credentials.Insecure);
            client = BJ.BJ.NewClient(channel);

            ListTopList();
            
            dealerCards.Add(pbDealer1);
            dealerCards.Add(pbDealer2);
            playerCards.Add(pbPlayer1);
            playerCards.Add(pbPlayer2);

            pictureBox1.Load("Images/dealer.png");
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox2.Load("Images/logo.png");
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            dealerCards[0].SizeMode = PictureBoxSizeMode.StretchImage;
            dealerCards[0].BackColor = Color.Transparent;
            dealerCards[1].SizeMode = PictureBoxSizeMode.StretchImage;
            dealerCards[1].BackColor = Color.Transparent;
            playerCards[0].SizeMode = PictureBoxSizeMode.StretchImage;
            playerCards[0].BackColor = Color.Transparent;
            playerCards[1].SizeMode = PictureBoxSizeMode.StretchImage;
            playerCards[1].BackColor = Color.Transparent;

            btnDeal.Enabled = false;
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnDouble.Enabled = false;
            btnSurrender.Enabled = false;
            btnLogout.Enabled = false;

            lblPlayerName.Visible = false;
            btnLogout.Visible = false;
        }


        //Requests
        private async void ListTopList()
        {
            listBoxNames.Items.Clear();
            listBoxMoneys.Items.Clear();

            using (var call = client.List(new Empty { }))
            {
                var responseStream = call.ResponseStream;
                while (await responseStream.MoveNext())
                {
                    UserRecord ur = responseStream.Current;
                    listBoxNames.Items.Add(ur.Name);
                    listBoxMoneys.Items.Add(ur.Money);
                }
            }
        }

        private async void btnRegistration_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = tbLoginUsername.Text;
            user.Passwd =tbLoginPassword.Text;
            BJ.Receipt receipt = client.Registration(user);
            lblServerMsg.Text = receipt.Success;
            tbLoginUsername.Text = "";
            tbLoginPassword.Text = "";
            await Task.Delay(5000);
            lblServerMsg.Text = "";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = tbLoginUsername.Text;
            user.Passwd = tbLoginPassword.Text;

            uid = client.Login(user).Id;

            if(uid == "")
            {
                lblServerMsg.Text = "Sikertelen belépés!";
                await Task.Delay(3000);
                lblServerMsg.Text = "";
                                                
            }
            else
            {
                string[] elements = uid.Split('|');
                uid = elements[0];
                lblAmount.Text = elements[1];
                lblServerMsg.Text = "Sikeres belépés!";
                ListTopList();
                btnLogin.Enabled = false;
                btnRegistration.Enabled = false;
                btnLogout.Enabled = true;
                btnDeal.Enabled = true;
                lblPlayerName.Text = tbLoginUsername.Text;
                tbLoginUsername.Text = "";
                tbLoginPassword.Text = "";
                await Task.Delay(3000);
                lblServerMsg.Text = "";

                tbLoginUsername.Visible = false;
                tbLoginPassword.Visible = false;
                btnRegistration.Visible = false;
                btnLogin.Visible = false;
                btnLogout.Visible = true;
                lblPlayerName.Visible = true;
                
            }
        }

        private async void btLogout_Click(object sender, EventArgs e)
        {
            Receipt receipt = client.Logout(new Session_Id { Id = uid });
            lblServerMsg.Text = receipt.Success;
            uid = null;

            btnLogin.Enabled = true;
            btnRegistration.Enabled = true;
            btnLogout.Enabled = false;
            btnDeal.Enabled = false;

            lblAmount.Text = "";

            await Task.Delay(3000);
            lblServerMsg.Text = "";

            tbLoginUsername.Visible = true;
            tbLoginPassword.Visible = true;
            btnRegistration.Visible = true;
            btnLogin.Visible = true;
            btnLogout.Visible = false;
            lblPlayerName.Visible = false;
        }

        private void btDeal_Click(object sender, EventArgs e)
        {
            int dAmount = Convert.ToInt32(udDeal.Value);
            GameResult gr = client.Deal(new Request { Id = uid,Amount = dAmount });

            string[] resultPlayerCards = gr.PlayerCards.Split('|');
            string[] resultDealerCards = gr.DealerCards.Split('|');

            playerCards[0].Load(string.Format("Images/cards/{0}.png", resultPlayerCards[0]));
            playerCards[1].Load(string.Format("Images/cards/{0}.png", resultPlayerCards[1]));

            dealerCards[0].Load(string.Format("Images/cards/{0}.png", resultDealerCards[0]));
            dealerCards[1].Load(string.Format("Images/cards/{0}.png", resultDealerCards[1]));

            for(int i=2;i<resultDealerCards.Length;i++)
            {
                NewPictureBoxToDealer(resultDealerCards[i]);
            }

            SetLabels(gr);
            SetForm(gr.Result, resultPlayerCards.Length);

        }

        private void btHit_Click(object sender, EventArgs e)
        {
            GameResult gr = client.Hit(new Session_Id { Id = uid });

            string[] resultPlayerCards = gr.PlayerCards.Split('|');
            string[] resultDealerCards = gr.DealerCards.Split('|');

            NewPictureBoxToPlayer(resultPlayerCards[resultPlayerCards.Length - 1]);

            if (IsTheEnd(gr.Result))
            {
                dealerCards[1].Load(string.Format("Images/cards/{0}.png", resultDealerCards[1]));
                for (int i = 2; i < resultDealerCards.Length; i++)
                {
                    NewPictureBoxToDealer(resultDealerCards[i]);
                }
            }

            SetLabels(gr);
            SetForm(gr.Result, resultPlayerCards.Length);
        }

        private void btStand_Click(object sender, EventArgs e)
        {
            GameResult gr = client.Stand(new Session_Id { Id = uid });

            string[] resultPlayerCards = gr.PlayerCards.Split('|');
            string[] resultDealerCards = gr.DealerCards.Split('|');

            dealerCards[1].Load(string.Format("Images/cards/{0}.png", resultDealerCards[1]));
            for (int i = 2; i < resultDealerCards.Length; i++)
            {
                NewPictureBoxToDealer(resultDealerCards[i]);
            }

            SetLabels(gr);
            SetForm(gr.Result, resultPlayerCards.Length);
        }

        private void btDouble_Click(object sender, EventArgs e)
        {
            GameResult gr = client.Double(new Session_Id { Id = uid });

            string[] resultPlayerCards = gr.PlayerCards.Split('|');
            string[] resultDealerCards = gr.DealerCards.Split('|');

            NewPictureBoxToPlayer(resultPlayerCards[resultPlayerCards.Length - 1]);

            dealerCards[1].Load(string.Format("Images/cards/{0}.png", resultDealerCards[1]));
            for (int i = 2; i < resultDealerCards.Length; i++)
            {
                NewPictureBoxToDealer(resultDealerCards[i]);
            }

            SetLabels(gr);
            SetForm(gr.Result, resultPlayerCards.Length);
        }

        private void btSurrender_Click(object sender, EventArgs e)
        {
            GameResult gr = client.Surrender(new Session_Id { Id = uid });

            string[] resultPlayerCards = gr.PlayerCards.Split('|');
            string[] resultDealerCards = gr.DealerCards.Split('|');

            SetLabels(gr);
            SetForm(gr.Result, resultPlayerCards.Length);
        }
      }
}
