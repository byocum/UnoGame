using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Enums;
using UnoGame.Factories;

namespace UnoGame.Decks
{
    public class DiscardDeck:Deck
    {
        public DiscardDeck()
        {
            this.CardDeck = new List<BasicCard>(); 
        }

        public override int removeCard(int cardIndex)
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

        public override bool isCardPlayable(BasicCard cardToPlay)
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

        public override void displayTopCard()
        {
            Console.WriteLine("The top card on the discard deck is: " + CardDeck[topCardIndex()].Color + " " + CardDeck[topCardIndex()].Type);
        }

        public override int refreshDeck(Deck discardDeck)
        {
            Console.WriteLine("The discard deck cannot be refreshed.");
            return CardDeck.Count;
        }

        public override void createCardsForDeck(ICardFactory cardFactory)
        {
            Console.WriteLine("Cards are put into the discard deck not created for the discard deck.");
        }

    }
}
