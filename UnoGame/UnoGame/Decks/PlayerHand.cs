using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Decks
{
    public class PlayerHand:Deck
    {
        public PlayerHand()
        {
            this.CardDeck = new List<BasicCard>();
        }

        public int removeCard(int cardIndex)
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
    }
}
