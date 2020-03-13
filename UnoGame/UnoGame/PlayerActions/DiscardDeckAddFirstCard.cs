using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Enums;

namespace UnoGame.PlayerActions
{
    public class DiscardDeckAddFirstCard:PlayerAction
    {
        public DiscardDeckAddFirstCard(DrawDeck drawDeck, DiscardDeck discardDeck)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
        }

        public override bool performAction()
        {
            addValidInitialCardToDiscardDeck();
            return true;
        }
        private void addValidInitialCardToDiscardDeck()
        {
            Console.WriteLine("Putting the draw deck top card on the discard deck...");
            moveCardFromDrawDeckToDiscardDeck();

            makeFirstCardOnDiscardDeckValid();

            DiscardDeck.displayTopCard();

            playDiscardDeckTopCard();
        }

        private void makeFirstCardOnDiscardDeckValid()
        {

            int discardDeckTopCardIndex = DiscardDeck.topCardIndex();
            BasicCard discardDeckTopCard = DiscardDeck.CardDeck[discardDeckTopCardIndex];

            while (discardDeckTopCard.Type == CardType.WildDrawFour)
            {
                DiscardDeck.removeCard(discardDeckTopCardIndex);
                DrawDeck.addCardRandomlyToDeck(discardDeckTopCard);
                moveCardFromDrawDeckToDiscardDeck();
            }
        }

        private void moveCardFromDrawDeckToDiscardDeck()
        {
            int drawDeckTopCardIndex = DrawDeck.topCardIndex();
            BasicCard drawDeckTopCard = DrawDeck.CardDeck[drawDeckTopCardIndex];

            DrawDeck.removeCard(drawDeckTopCardIndex);
            DiscardDeck.addCard(drawDeckTopCard);
        }

        private void playDiscardDeckTopCard()
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
