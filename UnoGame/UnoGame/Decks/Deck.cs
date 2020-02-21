using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Factories;
using System.Collections.Concurrent;

namespace UnoGame.Decks
{
    public abstract class Deck
    {
        private List<BasicCard> cardDeck;
        private ICardFactory cardFactory;
        private Random random = new Random();

        public List<BasicCard> CardDeck
        {
            get { return cardDeck; }
            protected set { cardDeck = value; }
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

        public void removeCard(int cardIndex)
        {
            BasicCard cardRemoved = CardDeck[cardIndex];
            CardDeck.RemoveAt(cardIndex);
        }
        
        //Modern version of Fishers and Yates' alogrithm
        public void shuffle()
        {
            for(int i = 0; i < cardDeck.Count - 1; i++)
            {
                BasicCard card = cardDeck[i];
                int index = random.Next(0, i + 1);
                cardDeck[i] = cardDeck[index];
                cardDeck[index] = card;
            }
        }

        public void sort()
        {
            CardDeck.Sort();
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
