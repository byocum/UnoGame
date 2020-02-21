﻿using System;
using System.Collections;
using System.Text;
using UnoGame.Enums;

namespace UnoGame.Cards
{
    public abstract class BasicCard:IComparable
    {
        private Nullable<CardColor> color = null;
        private CardType type;
        private PerformCardAction performCardAction;

        public virtual Nullable<CardColor> Color
        {
            get { return color; }
        }

        public virtual void setColor(Nullable<CardColor> color)
        {
                if (color != null)
                {
                    this.color = color;
                }

                //ToDo: Some kind of error handling needs to happen when you set the color to null and cannot.
        }
        public CardType Type
        {
            get { return type; }
            set { type = value; }
        }

        public PerformCardAction PerformCardAction
        {
            get { return performCardAction; }
            set { performCardAction = value; }
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
        

        public void showCard()
        {
            Console.Write(Color + " " + Type);
        }

        public abstract void playCard();
    }
}
