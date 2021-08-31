using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Enum
{
    public enum CardValueEnum : ushort
    {
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten,
        [Description("11")]
        Jack,
        [Description("12")]
        Queen,
        [Description("13")]
        King,
        [Description("14")]
        Ace,
    }
}
