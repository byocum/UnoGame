using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Enums;

namespace UnoGame.Decks
{
    public class DiscardDeck:Deck
    {
        public DiscardDeck()
        {
            this.CardDeck = new List<BasicCard>(); 
        }

        public int removeCard(int cardIndex)
        {
            int cardsLeftInDeck = this.CardDeck.Count;
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

        public bool isCardPlayable(BasicCard cardToPlay)
        {
            bool isPlayable = false;
            BasicCard discardDeckTopCard = CardDeck[topCardIndex()];

            if (cardToPlay.Color == null)
            {
                isPlayable = true;
            }
            else if (discardDeckTopCard.Color == cardToPlay.Color || discardDeckTopCard.Type == cardToPlay.Type)
            {
                isPlayable = true;
            }
            else if (cardToPlay.Type == CardType.Wild || cardToPlay.Type == CardType.WildDrawFour)
            {
                isPlayable = true;
            }
            return isPlayable;
        }

        public void displayTopCard()
        {
            Console.WriteLine("The top card on the discard deck is: " + CardDeck[topCardIndex()].Color + " " + CardDeck[topCardIndex()].Type);
        }
    }
}
