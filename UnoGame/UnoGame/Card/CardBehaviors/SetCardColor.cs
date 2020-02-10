using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enum;

namespace UnoGame.Card.CardBehaviors
{
    public class SetCardColor:CardBehavior
    {
        private Nullable<CardColor> color;
        public SetCardColor(BasicCard card)
        {
            this.BasicCard = card;
            Color = BasicCard.Color;
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
        }

        public override Nullable<CardColor> Color
        {
            get { return color; }
            set { color = value; }
        }

        public override void playCard()
        {
            PerformCardAction.SetCardColor();
            BasicCard.playCard();

        }
    }
}
