using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Cards.CardBehaviors
{
    public class Draw:CardBehavior
    {
        public Draw(BasicCard card)
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
            PerformCardAction.DrawCard();
            BasicCard.playCard();

        }
    }
}
