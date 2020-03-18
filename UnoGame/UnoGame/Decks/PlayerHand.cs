using System;
using System.Collections.Generic;
using UnoGame.Cards;
using UnoGame.Factories;

namespace UnoGame.Decks
{
    public class PlayerHand:Deck
    {
        public PlayerHand()
        {
            this.CardDeck = new List<BasicCard>();
        }

        public override int removeCard(int cardIndex)
        {
            int cardsLeftInDeck = CardDeck.Count;
            if (cardsLeftInDeck > 0)
            {
                CardDeck.RemoveAt(cardIndex);
                cardsLeftInDeck--;
            }
            else
            {
                errorNoCardsInDeck();
            }

            return cardsLeftInDeck;
        }
        protected override void errorNoCardsInDeck()
        {
            Console.WriteLine("The card cannot be removed because their are no cards in the hand.");
        }

        public override void displayTopCard()
        {
            Console.WriteLine("A player's hand does not have a top card.");
        }

        public override int refreshDeck(Deck discardDeck)
        {
            Console.WriteLine("A player's hand cannot be refreshed.");
            return CardDeck.Count;
        }

        public override void createCardsForDeck(ICardFactory cardFactory)
        {
            Console.WriteLine("Cards are put into a player's hand not created for a player's hand.");
        }
    }
}
