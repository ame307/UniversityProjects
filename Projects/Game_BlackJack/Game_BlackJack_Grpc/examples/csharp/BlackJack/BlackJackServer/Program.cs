using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJ;
using Grpc.Core;
using System.IO;
using BlackJackServer.DataBase;
using BlackJackServer.Models;

namespace BlackJackServer
{
    class BJS : BJ.BJ.IBJ
    {
        //Game
        const int PB_PLAYER_X = 258;
        const int PB_DEALER_X = 258;
        const int PB_PLAYER_Y = 482;
        const int PB_DEALER_Y = 12;

        List<Game> games = new List<Game>();
        Random rnd = new Random();

        string lblTextResult = "Sok sikert!";

        private void DeckRead(string id)
        {
            StreamReader sr = new StreamReader("cards.txt");

            int y = 0;
            while (!sr.EndOfStream)
            {
                games[GetSessionIdIndex(id)].Deck.Add(sr.ReadLine());
                y++;
            }
        }

        private void Shuffle(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            int n = games[gameIndex].Deck.Count - 1;
            int k;
            string temp;

            for (int i = n - 1; i > 0; --i)
            {
                k = rnd.Next(n + 1);
                temp = games[gameIndex].Deck[n];
                games[gameIndex].Deck[n] = games[gameIndex].Deck[k];
                games[gameIndex].Deck[k] = temp;
            }
        }

        private void FirstDeal(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            games[gameIndex].Player.Add(Draw(id));
            games[gameIndex].Dealer.Add(Draw(id));
            games[gameIndex].Player.Add(Draw(id));
            games[gameIndex].Dealer.Add("gray_back");
            games[gameIndex].DealerSecondCard = Draw(id);

            games[gameIndex].Money = games[gameIndex].Money - games[gameIndex].DealAmount;
        }

        private string Draw(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            if (games[gameIndex].Deck.Count == 0)
            {
                return null;
            }
            else
            {
                string card = games[gameIndex].Deck[0];
                games[gameIndex].Deck.RemoveAt(0);
                return card;
            }
        }

        private void SetUp(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            int s = PlayerAmount(id);
            int n = games[gameIndex].Player.Count;

            if (n == 2 && s != 21)
            {
                
            }
            else if (s < 21)
            {
                
            }
            else if (s > 21)
            {
                games[gameIndex].Dealer[1] = games[gameIndex].DealerSecondCard;
                Lose(id);
            }
            else
            {
                PlayerEnd(id);
            }
        }

        private void PlayerEnd(string id)
        {
            int DA = DealerPlay(id);
            int PA = PlayerAmount(id);

            if (DA == PA && PA <= 21)
            {
                Tie(id);
            }
            else if ((PA > DA && PA <= 21) || DA > 21 && PA <= 21)
            {
                Win(id);
            }
            else
            {
                Lose(id);
            }
        }

        private int DealerPlay(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            games[gameIndex].Dealer[1] = games[gameIndex].DealerSecondCard;
            int DA = DealerAmount(id);

            string newCard;

            while (DA <= 16)
            {
                newCard = Draw(id);
                games[gameIndex].Dealer.Add(newCard);
                DA = DealerAmount(id);
            }

            return DA;
        }

        private int DealerAmount(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            int s = int.Parse(games[gameIndex].Dealer[0].Substring(0, 2));
            bool haveAce = false;

            if (games[gameIndex].Dealer[1] != "gray_back")
            {
                s += int.Parse(games[gameIndex].Dealer[1].Substring(0, 2));
            }

            for (int i = 2; i < games[gameIndex].Dealer.Count; i++)
            {
                s += int.Parse(games[gameIndex].Dealer[i].Substring(0, 2));
                if (int.Parse(games[gameIndex].Dealer[i].Substring(0, 2)) == 11 && !haveAce)
                {
                    haveAce = true;
                }
            }

            if (haveAce && s > 21)
            {
                s = s - 10;
            }

            return s;
        }

        private int PlayerAmount(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            int s = 0;
            int aceCount = 0;
            for (int i = 0; i < games[gameIndex].Player.Count; i++)
            {
                s += int.Parse(games[gameIndex].Player[i].Substring(0, 2));
                if (int.Parse(games[gameIndex].Player[i].Substring(0, 2)) == 11)
                {
                    aceCount++;
                }
            }

            while (s > 21 && aceCount > 0)
            {
                s = s - 10;
                aceCount--;
            }

            return s;
        }

        

        private void Tie(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            lblTextResult = string.Format("Döntetlen!");
            games[gameIndex].Money = games[gameIndex].Money + games[gameIndex].DealAmount;
            games[gameIndex].IsTheEnd = true;
        }

        private void Win(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            if (PlayerAmount(id) == 21)
            {
                int prize = Convert.ToInt32(Math.Round(games[gameIndex].DealAmount * (3.0 / 2.0), 0));

                lblTextResult = string.Format("Nyertél: {0}", prize);
                games[gameIndex].Money = games[gameIndex].Money + prize;
            }
            else
            {
                lblTextResult = string.Format("Nyertél: {0}", games[gameIndex].DealAmount * 2);
                games[gameIndex].Money = games[gameIndex].Money + games[gameIndex].DealAmount * 2;
            }

            games[gameIndex].IsTheEnd = true;
        }

        private void Lose(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            lblTextResult = string.Format("Vesztettél!");
            games[gameIndex].IsTheEnd = true;
        }

        private GameResult CreateGameResult(string id)
        {
            int gameIndex = GetSessionIdIndex(id);
            GameResult gr = new GameResult();

            string playerCardsString = games[gameIndex].Player[0];

            for (int i = 1; i < games[gameIndex].Player.Count; i++)
            {
                playerCardsString += string.Format("|{0}", games[gameIndex].Player[i]);
            }

            string dealerCardsString = games[gameIndex].Dealer[0];

            for (int i = 1; i < games[gameIndex].Dealer.Count; i++)
            {
                dealerCardsString += string.Format("|{0}", games[gameIndex].Dealer[i]);
            }

            gr.PlayerCards = playerCardsString;
            gr.DealerCards = dealerCardsString;
            gr.Money = games[gameIndex].Money.ToString();
            gr.PlayerAmount = PlayerAmount(id).ToString();
            gr.DealerAmount = DealerAmount(id).ToString();
            gr.Result = lblTextResult;

            IsTheEnd(id);

            return gr;
        }

        public void IsTheEnd(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            if (games[gameIndex].IsTheEnd)
            {
                Reset(id);
            }
        }

        private void Reset(string id)
        {
            int gameIndex = GetSessionIdIndex(id);

            if (games[gameIndex].Money <= 0)
            {
                games[gameIndex].Money = 50;
            }

            lblTextResult = "Sok sikert!";
            games[gameIndex].IsTheEnd = false;

            games[gameIndex].Dealer.Clear();
            games[gameIndex].Player.Clear();
        }

        private int GetSessionIdIndex(string id)
        {
            int y = 0;
            while(sessions[y] != id)
            {
                y++;
            }
            return y;
        }

        private bool IsSessionValid(string id)
        {
            int y = 0;
            while (y < sessions.Count && sessions[y] != id)
            {
                y++;
            }
            if(y < sessions.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateMoney(string id)
        {
            UserManager um = new UserManager();
            um.updateMoney(Convert.ToInt32(id), games[GetSessionIdIndex(id)].Money);
        }

        //Tasks
        readonly List<string> sessions = new List<string>();
        public Task<Session_Id> Login(User user, ServerCallContext context)
        {
            Session_Id sid = new Session_Id();
            UserManager um = new UserManager();
            if(um.hasUsername(user.Name))
            {
                DatabaseUser dbUser = um.getUserByName(user.Name);
                if(dbUser.Password != user.Passwd)
                {
                    sid.Id = "";
                }
                else
                {
                    sid.Id = dbUser.Id.ToString() + "|" + dbUser.Money.ToString();
                    sessions.Add(dbUser.Id.ToString());
                    games.Add(new Game());
                    games[GetSessionIdIndex(dbUser.Id.ToString())].Money = dbUser.Money;
                    DeckRead(dbUser.Id.ToString());
                    Shuffle(dbUser.Id.ToString());
                }    
            }
            else
            {
                sid.Id = "";
            }

            return Task.FromResult(sid);
            
        }

        public Task<Receipt> Logout(Session_Id id, ServerCallContext context)
        {
            games.RemoveAt(GetSessionIdIndex(id.Id));
            sessions.Remove(id.Id);
            return Task.FromResult(new Receipt { Success = "Kilépve!" }); ;
        }

        public Task<Receipt> Registration(User user, ServerCallContext context)
        {
            UserManager um = new UserManager();
            DatabaseUser dbUser = new DatabaseUser(0,user.Name, user.Passwd, 1000);
            Receipt receipt = new Receipt();

            if(!um.hasUsername(dbUser.Username))
            {
                um.registrateNewUser(dbUser);
                receipt.Success = "Sikeres regisztráció!";
            }
            else
            {
                receipt.Success = "Sikertelen regisztráció!";
            }

            return Task.FromResult(receipt);
            
        }

        public Task<GameResult> Deal(Request request, ServerCallContext context)
        {
            GameResult gr = new GameResult();

            if(IsSessionValid(request.Id))
            {
                int gameIndex = GetSessionIdIndex(request.Id);

                games[gameIndex].DealAmount = Convert.ToInt32(request.Amount);

                if (games[gameIndex].Deck.Count < 17)
                {
                    games[gameIndex].Deck.Clear();
                    DeckRead(request.Id);
                    Shuffle(request.Id);
                }

                FirstDeal(request.Id);
                SetUp(request.Id);
                UpdateMoney(request.Id);
                
                gr = CreateGameResult(request.Id);
            }
            
            return Task.FromResult(gr);
        }

        public Task<GameResult> Hit(Session_Id id, ServerCallContext context)
        {
            GameResult gr = new GameResult();

            if (IsSessionValid(id.Id))
            {
                string newCard = Draw(id.Id);
                games[GetSessionIdIndex(id.Id)].Player.Add(newCard);
                SetUp(id.Id);
                UpdateMoney(id.Id);
                gr = CreateGameResult(id.Id);
            }
            
            return Task.FromResult(gr);
        }

        public Task<GameResult> Stand(Session_Id id, ServerCallContext context)
        {
            GameResult gr = new GameResult();

            if (IsSessionValid(id.Id))
            {
                PlayerEnd(id.Id);
                UpdateMoney(id.Id);
                gr = CreateGameResult(id.Id);
            }
                
            return Task.FromResult(gr);
        }

        public Task<GameResult> Double(Session_Id id, ServerCallContext context)
        {
            GameResult gr = new GameResult();

            if (IsSessionValid(id.Id))
            {
                int gameIndex = GetSessionIdIndex(id.Id);

                string newCard = Draw(id.Id);
                games[gameIndex].Player.Add(newCard);
                games[gameIndex].Money = games[gameIndex].Money - games[gameIndex].DealAmount;
                games[gameIndex].DealAmount = games[gameIndex].DealAmount * 2;
                PlayerEnd(id.Id);
                UpdateMoney(id.Id);
                gr = CreateGameResult(id.Id);
            }
            
            return Task.FromResult(gr);
        }

        public Task<GameResult> Surrender(Session_Id id, ServerCallContext context)
        {
            GameResult gr = new GameResult();

            if (IsSessionValid(id.Id))
            {
                int gameIndex = GetSessionIdIndex(id.Id);

                lblTextResult = "Feladtad!";
                games[gameIndex].Money = games[gameIndex].Money + games[gameIndex].DealAmount / 2;
                UpdateMoney(id.Id);
                gr = CreateGameResult(id.Id);
                Reset(id.Id);
            }

            return Task.FromResult(gr);
        }

        public async Task List(Empty emp, IServerStreamWriter<UserRecord> responseStream, ServerCallContext context)
        {
            UserManager um = new UserManager();
            List<DatabaseUser> list = um.getUsers();
            UserRecord ur = new UserRecord();

            for(int i=0;i<list.Count;i++)
            {
                ur.Name = list[i].Username;
                ur.Money = list[i].Money;
                await responseStream.WriteAsync(ur);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int Port = 50052;
            Server server = new Server
            {
                Services = { BJ.BJ.BindService(new BJS()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Black Jack server has been started on port:" + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();
            server.ShutdownAsync().Wait();
        }
    }
}
