using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Enum
{
    public enum TableStateEnum
    {
        PlayerInNormalTurn,
        ComputerInNormalTurn,
        PlayerNeedsToTakeMoreCard,
        ComputerNeedsToTakeMoreCard,
        PlayerStays,
        ComputerStays,
        PlayerNeedsPickType,
        ComputerNeedsPickType,
    }
}
