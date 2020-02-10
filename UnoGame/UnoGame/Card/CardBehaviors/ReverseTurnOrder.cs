using System;
using System.Collections.Generic;
using System.Text;

namespace UnoGame.Card.CardBehaviors
{
    public class ReverseTurnOrder:CardBehavior
    {
        public ReverseTurnOrder(BasicCard card)
        {
            this.BasicCard = card;
            Color = BasicCard.Color;
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
        }

        public override void playCard()
        {
            PerformCardAction.ReverseTurnOrder();
            BasicCard.playCard();

        }
    }
}
