using System;
using UnoGame.Enums;

namespace UnoGame.Cards
{
    public abstract class BasicCard : IComparable
    {
        private Nullable<CardColor> color = null;
        private CardType type;
        private PerformCardAction performCardAction;
        private bool cardWithNoActions;

        public virtual Nullable<CardColor> Color
        {
            get { return color; }
            protected set { color = value; }
        }

        public virtual void setColor(Nullable<CardColor> color)
        {
            this.color = color;
        }
        public CardType Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool CardWithNoActions
        {
            get { return cardWithNoActions; }
            set { cardWithNoActions = value; }
        }

        public PerformCardAction PerformCardAction
        {
            get { return performCardAction; }
            set { performCardAction = value; }
        }

        public string lookAtCard()
        {
            return Color + " " + Type;
        }

        public int CompareTo(object otherObject) 
        {
            BasicCard otherCard = (BasicCard)otherObject;

            int thisCardType = Convert.ToInt32(this.Type);
            int otherCardType = Convert.ToInt32(otherCard.Type);

            if (this.Color < otherCard.Color)
            {
                return -1;
            }
            else if (this.Color == otherCard.Color && thisCardType < otherCardType)
            {
                return -1;
            }
            else if (this.Color != null && otherCard.Color == null)
            {
                return -1;
            }
            else if(this.Color == null && otherCard.Color == null && thisCardType < otherCardType)
            {
                return -1;
            }
            else if (this.Color == otherCard.Color && thisCardType == otherCardType)
            {
                return 0;
            }
            else if (this.Color == null && otherCard.Color == null && thisCardType == otherCardType)
            {
                return 0;
            }
            else if (this.Color > otherCard.Color)
            {
                return 1;
            }
            else if (this.Color == otherCard.Color && thisCardType > otherCardType)
            {
                return 1;
            }

            else if (this.Color == null && otherCard.Color != null)
            {
                return 1;
            }
            else if (this.Color == null && otherCard.Color == null && thisCardType > otherCardType)
            {
                return 1;
            }
            else
            {
                return 1;
            }
        }

        public abstract void playCard();
    }
}
