﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnoGame.Card.CardBehaviors
{
    public class Draw:CardBehavior
    {
        public Draw(BasicCard card)
        {
            this.BasicCard = card;
            Color = BasicCard.Color;
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
        }

        public override void playCard()
        {
            PerformCardAction.DrawCard();
            BasicCard.playCard();

        }
    }
}
