using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Cards.CardBehaviors
{
    public class ReverseTurnOrder:CardBehavior
    {
        public ReverseTurnOrder(BasicCard card)
        {
            this.BasicCard = card;
            setColor(BasicCard.Color);
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
            CardWithNoActions = false;
            card.CardWithNoActions = false;
        }

        public override void playCard()
        {
            PerformCardAction.ReverseTurnOrder();
            BasicCard.playCard();

        }
    }
}
