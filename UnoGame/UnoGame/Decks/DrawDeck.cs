using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Factories;
using UnoGame.Enums;

namespace UnoGame.Decks
{
    public class DrawDeck:Deck
    {
        public DrawDeck(ICardFactory cardFactory)
        {
            this.CardDeck = new List<BasicCard>();
            this.CardFactory = cardFactory;
            createDeck();
        }

        private void createDeck()
        {
            for(int i = 0; i < 4; i++)
            {
                CardDeck.Add(CardFactory.CreateCard(CardType.Wild));
                CardDeck.Add(CardFactory.CreateCard(CardType.WildDrawFour));
            }

            foreach(CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach(CardType type in Enum.GetValues(typeof(CardType)))
                {
                    if(type != CardType.Wild && type != CardType.WildDrawFour)
                    {
                        CardDeck.Add(CardFactory.CreateCard(color, type));

                        if(type != CardType.Zero)
                        {
                            CardDeck.Add(CardFactory.CreateCard(color, type));
                        }
                    }
                }
                
            }

        }
    }
}
