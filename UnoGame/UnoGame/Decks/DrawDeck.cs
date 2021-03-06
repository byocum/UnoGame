﻿using System;
using System.Collections.Generic;
using UnoGame.Cards;
using UnoGame.Factories;
using UnoGame.Enums;

namespace UnoGame.Decks
{
    public class DrawDeck:Deck
    {
        public DrawDeck()
        {
            this.CardDeck = new List<BasicCard>();
        }

        public void createCardsForDeck(ICardFactory cardFactory)
        {
            this.CardFactory = cardFactory;

            for (int i = 0; i < 4; i++)
            {
                CardDeck.Add(CardFactory.CreateWildCard(CardType.Wild));
                CardDeck.Add(CardFactory.CreateWildCard(CardType.WildDrawFour));
            }

            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    if (type != CardType.Wild && type != CardType.WildDrawFour)
                    {
                        CardDeck.Add(CardFactory.CreateCard(color, type));

                        if (type != CardType.Zero)
                        {
                            CardDeck.Add(CardFactory.CreateCard(color, type));
                        }
                    }
                }
            }
        }

        public int removeCard(int cardIndex, DiscardDeck discardDeck)
        {
            int cardsLeftInDeck = CardDeck.Count;

            if (cardsLeftInDeck > 1)
            {
                CardDeck.RemoveAt(cardIndex);
                cardsLeftInDeck--;
            }
            else if (cardsLeftInDeck == 1)
            {
                CardDeck.RemoveAt(cardIndex);
                refreshDeck(discardDeck);
                cardsLeftInDeck = CardDeck.Count;

            }
            else
            {
                errorNoCardsInDeck();
                refreshDeck(discardDeck);
                cardsLeftInDeck = CardDeck.Count;
                CardDeck.RemoveAt(topCardIndex());
            }

            return cardsLeftInDeck;
        }

        private int refreshDeck(DiscardDeck discardDeck)
        {
            Console.WriteLine("Refreshing the Draw Deck...");
            int cardsLeftInDeck = CardDeck.Count;

            int discardDeckTopCardIndex = discardDeck.topCardIndex();
            BasicCard discardDeckTopCard = discardDeck.CardDeck[discardDeckTopCardIndex];
            discardDeck.removeCard(discardDeckTopCardIndex);

            CardDeck.AddRange(discardDeck.CardDeck);
            shuffle();
            discardDeck.CardDeck.RemoveRange(0, discardDeck.CardDeck.Count);

            discardDeck.CardDeck.Add(discardDeckTopCard);

            return cardsLeftInDeck;
        }
    }
}
