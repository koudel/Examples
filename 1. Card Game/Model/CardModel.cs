using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Enum;
using CardGame.Class;
using System.Windows.Controls;

namespace CardGame.Model
{
    public class CardModel
    {
        public CardValueEnum CardValue { get; set; }
        public CardTypeEnum CardType { get; set; }
        public CardColorEnum CardColor { get { return CardType.GetCardColor(); } }
        public CardTypeEnum? SpecialCardType { get; set; }
        public CardColorEnum? SpecialCardColor { get { return SpecialCardType?.GetCardColor(); } }
    }
}
