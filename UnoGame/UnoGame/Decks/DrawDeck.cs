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

        public override void TimeToRefreshDeck(Deck discardDeck)
        {
            int cardsInDrawDeck = CardDeck.Count;
            int cardsInDiscardDeck = discardDeck.CardDeck.Count;

            if (cardsInDiscardDeck > 1 && cardsInDrawDeck <= 0)
            {
                refreshDeck(discardDeck);
            }
            else if (cardsInDiscardDeck <= 1 && cardsInDrawDeck <= 0)
            {
                ErrorCannotRefreshDeck();
            }
        }

        public void refreshDeck(Deck discardDeck)
        {
            Console.WriteLine("Refreshing the Draw Deck...");

            int discardDeckTopCardIndex = discardDeck.topCardIndex();
            BasicCard discardDeckTopCard = discardDeck.CardDeck[discardDeckTopCardIndex];
            discardDeck.removeCard(discardDeckTopCardIndex);

            CardDeck.AddRange(discardDeck.CardDeck);
            shuffle();
            discardDeck.CardDeck.RemoveRange(0, discardDeck.CardDeck.Count);

            discardDeck.CardDeck.Add(discardDeckTopCard);
        }

        private void ErrorCannotRefreshDeck()
        {
            Console.WriteLine("There are no cards in the discard pile to refresh the draw pile with.");
            Console.WriteLine("Card cannot be drawn.");
            Console.WriteLine("Game ends without a winner.");
            Environment.Exit(0);
        }

        public override void displayTopCard()
        {
            Console.WriteLine("The top card on the draw deck is: " + CardDeck[topCardIndex()].Color + " " + CardDeck[topCardIndex()].Type);
        }
    }
}
