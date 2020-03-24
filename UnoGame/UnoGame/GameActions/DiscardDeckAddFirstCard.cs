using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Enums;
using UnoGame.Players;
using UnoGame.Intermediaries;

namespace UnoGame.GameActions
{
    public class DiscardDeckAddFirstCard:GameAction
    {
        GameAction pause;

        public DiscardDeckAddFirstCard(Deck drawDeck, Deck discardDeck, Turn turn, GameAction pause)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            this.pause = pause;
            TurnOrder = turn;
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
                Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

                Console.WriteLine("This card plays at the beginning of the game.");
                Console.WriteLine("It acts as if " + currentPlayer.Name + " is playing the card");
                Console.WriteLine("Your hand may be shown if a \"Wild\" is the first card turned up");
                pause.PerformAction();
                Console.WriteLine("Playing card...");

                if(discardDeckTopCard.Type == CardType.Wild)
                {
                    currentPlayer.LookAtHand();
                    discardDeckTopCard.playCard();
                }
                else
                {
                    discardDeckTopCard.playCard();
                }
                
            }
        }
    }
}
