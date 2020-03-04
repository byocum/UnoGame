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
            CardWithNoActions = true;
        }
        public Card(CardColor color, CardType type, PerformCardAction performCardAction)
        {
            this.setColor(color);
            Type = type;
            PerformCardAction = performCardAction;
            CardWithNoActions = true;
        }
        public override void playCard()
        {
            PerformCardAction.NextTurn();
            Console.WriteLine(lookAtCard() + " was played.");
        }
    }
}
