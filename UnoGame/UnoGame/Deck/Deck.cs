using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Card;

namespace UnoGame.Deck
{
    public abstract class Deck
    {
        List<BasicCard> cardDeck;

        protected List<BasicCard> CardDeck
        {
            get { return cardDeck; }
            set { cardDeck = value; }
        }
       
        public void addCard(BasicCard card)
        {
            CardDeck.Add(card);
        }

        public void removeCard(BasicCard card)
        {
            CardDeck.Remove(card);
        }

        public void lookAtDeck()
        {
            for(int i = 0; i < CardDeck.Count; i++)
            {
                Console.WriteLine(i + " " + CardDeck[i].Color + " " + CardDeck[i].Type);
            }

        }
    }
}
