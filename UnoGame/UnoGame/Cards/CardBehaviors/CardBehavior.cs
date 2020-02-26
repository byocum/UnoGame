using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Enums;

namespace UnoGame.Cards.CardBehaviors
{
    public abstract class CardBehavior:BasicCard
    {
        private BasicCard basicCard;

        protected BasicCard BasicCard
        {
            get { return basicCard; }
            set { basicCard = value; } 
        }

        public override void setColor(Nullable<CardColor> color)
        {
            this.Color = color;
            this.basicCard.setColor(color);
        }

    }
}
