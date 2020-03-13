using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Cards.CardBehaviors
{
    public class NextTurn:CardBehavior
    {
        public NextTurn(BasicCard card)
        {
            this.BasicCard = card;
            setColor(card.Color);
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
            CardWithNoActions = false;
            card.CardWithNoActions = false;
        }

        public override void playCard()
        {
            PerformCardAction.NextTurn();
            BasicCard.playCard();

        }
    }
}
