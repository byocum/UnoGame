using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Enums;

namespace UnoGame.GameActions
{
    public class DiscardDeckAddFirstCard:GameAction
    {
        public DiscardDeckAddFirstCard(Deck drawDeck, Deck discardDeck)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
        }

        public override bool PerformAction()
        {
            AddValidInitialCardToDiscardDeck();
            return true;
        }
        private void AddValidInitialCardToDiscardDeck()
        {
            Console.WriteLine("Putting the draw deck top card on the discard deck...");
            MoveCardFromDrawDeckToDiscardDeck();

            MakeFirstCardOnDiscardDeckValid();

            DiscardDeck.displayTopCard();

            PlayDiscardDeckTopCard();
        }

        private void MakeFirstCardOnDiscardDeckValid()
        {

            int discardDeckTopCardIndex = DiscardDeck.topCardIndex();
            BasicCard discardDeckTopCard = DiscardDeck.CardDeck[discardDeckTopCardIndex];

            while (discardDeckTopCard.Type == CardType.WildDrawFour)
            {
                DiscardDeck.removeCard(discardDeckTopCardIndex);
                DrawDeck.addCardRandomlyToDeck(discardDeckTopCard);
                MoveCardFromDrawDeckToDiscardDeck();
            }
        }

        private void MoveCardFromDrawDeckToDiscardDeck()
        {
            int drawDeckTopCardIndex = DrawDeck.topCardIndex();
            BasicCard drawDeckTopCard = DrawDeck.CardDeck[drawDeckTopCardIndex];

            DrawDeck.removeCard(drawDeckTopCardIndex);
            DiscardDeck.addCard(drawDeckTopCard);
        }

        private void PlayDiscardDeckTopCard()
        {
            BasicCard discardDeckTopCard = DiscardDeck.CardDeck[DiscardDeck.topCardIndex()];

            if (discardDeckTopCard.CardWithNoActions == false)
            {
                Console.WriteLine("This card plays when it is turned up at the beginning of the game.");
                Console.WriteLine("Playing card...");

                discardDeckTopCard.playCard();
            }
        }
    }
}
