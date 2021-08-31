using CardGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Model
{
    public class TableModel
    {
        public TableModel()
        {
            Deck = new List<CardModel>();
            PlayerHand = new List<CardModel>();
            ComputerHand = new List<CardModel>();
            GameDeck = new List<CardModel>();
        }

        public List<CardModel> Deck { get; set; }
        public List<CardModel> PlayerHand { get; set; }
        public List<CardModel> ComputerHand { get; set; }
        public List<CardModel> GameDeck { get; set; }
        public TableStateEnum State { get; set; }
        public int NewCardCount { get; set; }
    }
}
