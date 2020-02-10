using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enum;

namespace UnoGame.Card
{
    public class Card:BasicCard
    {
        public Card(CardColor color, CardType type, PerformCardAction performCardAction)
        {
            Color = color;
            Type = type;
            PerformCardAction = performCardAction;
        }
        public override void playCard()
        {
            PerformCardAction.NextTurn();
        }
    }
}
