using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enums;

namespace UnoGame.Cards
{
    public class Card:BasicCard
    {
        public Card(CardType type, PerformCardAction performCardAction)
        {
            Type = type;
            PerformCardAction = performCardAction;
        }
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
