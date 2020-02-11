using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Cards.CardBehaviors;
using UnoGame.Enums;

namespace UnoGame.Factories
{
    public class CardFactory
    {
        private PerformCardAction performCardAction;

        public CardFactory()
        {
            performCardAction = new PerformCardAction(); 
        }
        public BasicCard CreateCard(CardColor color, CardType type)
        {
            BasicCard card;

            switch (type)
            {
                case CardType.DrawTwo:
                    card = new Card(color, type, this.performCardAction);
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
                    card = new Card(type, this.performCardAction);
                    card = new SetCardColor(card);
                    break;

                case CardType.WildDrawFour:
                    card = new Card(type, this.performCardAction);
                    card = new Draw(card);
                    card = new Draw(card);
                    card = new Draw(card);
                    card = new Draw(card);
                    card = new SetCardColor(card);
                    break;

                default:
                    card = new Card(color, type, this.performCardAction);
                    break;
            }
            return card;
        }
    }
}
