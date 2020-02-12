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
        Random random = new Random();

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

        public void order()
        {
            cardDeck.Sort();
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
