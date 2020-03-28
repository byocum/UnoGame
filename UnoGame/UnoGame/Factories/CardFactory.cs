﻿using UnoGame.Cards;
using UnoGame.Cards.CardBehaviors;
using UnoGame.Enums;

namespace UnoGame.Factories
{
    public class CardFactory:ICardFactory
    {
        private PerformCardAction performCardAction;

        public CardFactory(PerformCardAction performCardAction)
        {
            this.performCardAction = performCardAction; 
        }
        public BasicCard CreateCard(CardColor color, CardType type)
        {
            BasicCard card;

            switch (type)
            {
                case CardType.DrawTwo:
                    card = new Card(color, type, this.performCardAction);
                    card = new NextTurn(card);
                    card = new Draw(card);
                    card = new Draw(card);
                    break;

                case CardType.Skip:
                    card = new Card(color, type, this.performCardAction);
                    card = new NextTurn(card);
                    break;

                case CardType.Reverse:
                    card = new Card(color, type, this.performCardAction);
                    card = new ReverseTurnOrder(card);
                    break;

                case CardType.Wild:
                    card = CreateWildCard(type);
                    break;

                case CardType.WildDrawFour:
                    card = CreateWildCard(type);
                    break;

                default:
                    card = new Card(color, type, this.performCardAction);
                    break;
            }

            return card;
        }

        public BasicCard CreateWildCard(CardType type)
        {
            BasicCard card;

            switch (type)
            {
                case CardType.WildDrawFour:
                    card = new Card(CardType.WildDrawFour, this.performCardAction);
                    card = new NextTurn(card);
                    card = new Draw(card);
                    card = new Draw(card);
                    card = new Draw(card);
                    card = new Draw(card);
                    card = new SetCardColor(card);
                    break;

                default:
                    card = new Card(CardType.Wild, this.performCardAction);
                    card = new SetCardColor(card);
                    break;
            }

            return card;
        }
    }
}
