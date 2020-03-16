using System;
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

        public override void createCardsForDeck(ICardFactory cardFactory)
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

        public override int refreshDeck(Deck discardDeck)
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

        public override void displayTopCard()
        {
            Console.WriteLine("The top card on the draw deck is: " + CardDeck[topCardIndex()].Color + " " + CardDeck[topCardIndex()].Type);
        }
    }
}
