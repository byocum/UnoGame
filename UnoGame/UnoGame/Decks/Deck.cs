using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Factories;

namespace UnoGame.Decks
{
    public abstract class Deck
    {
        List<BasicCard> cardDeck;
        ICardFactory cardFactory;

        protected List<BasicCard> CardDeck
        {
            get { return cardDeck; }
            set { cardDeck = value; }
        }

        protected ICardFactory CardFactory
        {
            get { return cardFactory; }
            set { cardFactory = value; }
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
