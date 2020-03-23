﻿using System;
using System.Collections.Generic;
using UnoGame.Cards;
using UnoGame.Factories;
using UnoGame.Enums;

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

        public int topCardIndex()
        {
            return cardDeck.Count - 1;
        }

        public void addCard(BasicCard card)
        {
            CardDeck.Add(card);
        }

        public virtual int removeCard(int cardIndex)
        {
            int cardsLeftInDeck = CardDeck.Count;

            if (cardsLeftInDeck >= 1)
            {
                CardDeck.RemoveAt(cardIndex);
                cardsLeftInDeck--;
            }
            else
            {
                errorNoCardsInDeck();
                cardsLeftInDeck = CardDeck.Count;
            }

            return cardsLeftInDeck;
        }

        protected virtual void errorNoCardsInDeck()
        {
            Console.WriteLine("The card cannot be removed because the deck does not have any cards.");
        }

        public abstract void displayTopCard();


        //Modern version of Fishers and Yates' alogrithm
        public void shuffle()
        {
            for(int i = 0; i < topCardIndex(); i++)
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
            for(int index = 0; index < CardDeck.Count; index++)
            {
                int displayNumber = index + 1;

                if(CardDeck[index].Color == null)
                {
                    Console.WriteLine(displayNumber + " " + CardDeck[index].Type);
                }
                else
                {
                    Console.WriteLine(displayNumber + " " + CardDeck[index].Color + " " + CardDeck[index].Type);
                }
                
            }
        }

        public void addCardRandomlyToDeck(BasicCard card)
        {
            int index = random.Next(0, topCardIndex());
            CardDeck.Insert(index, card);
        }

        public bool isCardInDeck(int cardIndex)
        {
            bool isInDeck = false;

            if(cardIndex <= topCardIndex() && cardIndex >= 0)
            {
                isInDeck = true;
            }

            return isInDeck;
        }

        public virtual bool isCardPlayable(BasicCard cardToPlay)
        {
            Console.WriteLine("A card cannot be played on this deck.");
            return false;
        }

        public abstract void TimeToRefreshDeck(Deck discardDeck);

        public abstract void createCardsForDeck(ICardFactory cardFactory);
    }
}
