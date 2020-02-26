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

        public bool isCardPlayable(BasicCard cardToPlay)
        {
            bool isPlayable = false;
            BasicCard discardDeckTopCard = CardDeck[CardDeck.Count - 1];

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

        public void lookAtTopCard()
        {
            int topCardIndex = CardDeck.Count - 1;
            Console.WriteLine("The top card on the discard deck is: " + CardDeck[topCardIndex].Color + " " + CardDeck[topCardIndex].Type);

        }
    }
}
