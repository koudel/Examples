using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Enum
{
    public enum CardTypeEnum : ushort
    {
        [Description("h")]
        Hearts,
        [Description("d")]
        Diamonds,
        [Description("s")]
        Spades,
        [Description("c")]
        Clubs,
    }
}
