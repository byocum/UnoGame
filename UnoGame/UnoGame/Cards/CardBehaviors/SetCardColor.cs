using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enums;
using UnoGame.Cards;

namespace UnoGame.Cards.CardBehaviors
{
    public class SetCardColor:CardBehavior
    {
        private Nullable<CardColor> color;
        public SetCardColor(BasicCard card)
        {
            this.BasicCard = card;
            setColor(BasicCard.Color);
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
        }

        //public override Nullable<CardColor> Color
        //{
        //    get { return color; }
        //}

        public override void setColor(CardColor? color)
        {
            this.color = color;
        }

        public override void playCard()
        {
            PerformCardAction.SetCardColor();
            BasicCard.playCard();

        }
    }
}
