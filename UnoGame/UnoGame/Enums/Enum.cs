using System;
using System.Collections.Generic;
using System.Text;

namespace UnoGame.Enums
{
    public enum CardColor
    {
        Red = 0,
        Blue = 1,
        Green = 2,
        Yellow = 3
    }

    public enum CardType
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        DrawTwo = 10,
        Skip = 11,
        Reverse = 12,
        Wild = 13,
        WildDrawFour = 14
    }

    public enum TurnDirection
    {
        Ascending = 0,
        Decending = 1
    }
}
