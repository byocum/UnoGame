﻿using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enum;

namespace UnoGame.Card
{
    public abstract class BasicCard
    {
        private Nullable<CardColor> color;
        private CardType type;
        private PerformCardAction performCardAction;

        public virtual Nullable<CardColor> Color
        {
            get { return color; }
            set
            {
                if (value != null)
                {
                    color = value;
                }
            }
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

        public void showCard()
        {
            Console.Write(Color + " " + Type);
        }

        public abstract void playCard();


    }
}
