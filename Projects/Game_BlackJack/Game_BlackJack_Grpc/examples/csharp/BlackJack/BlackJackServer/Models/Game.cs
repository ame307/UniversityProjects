using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServer.Models
{
    public class Game
    {
        public int Money { get; set; }
        public int DealAmount { get; set; }
        public string DealerSecondCard { get; set; }
        public bool IsTheEnd { get; set; }
        public List<string> Deck { get; set; }
        public List<string> Dealer { get; set; }
        public List<string> Player { get; set; }

        public Game()
        {
            Money = 1000;
            DealAmount = 0;
            IsTheEnd = false;
            Deck = new List<string>();
            Dealer = new List<string>();
            Player = new List<string>();
        }
    }
}
