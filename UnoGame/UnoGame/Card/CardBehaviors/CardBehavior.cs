using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enum;

namespace UnoGame.Card.CardBehaviors
{
    public abstract class CardBehavior:BasicCard
    {
        private BasicCard basicCard;

        protected BasicCard BasicCard
        {
            get { return basicCard; }
            set { basicCard = value; } 
        }

    }
}
