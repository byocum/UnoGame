using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;

namespace UnoGame.GameActions
{
    class Draw : GameAction
    {
        public Draw(Deck drawDeck, Deck discardDeck, Turn turn)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }

        public override bool PerformAction()
        {
            DrawAndPlayCard();
            return true;
        }

        private void DrawAndPlayCard()
        {
            int cardDrawnIndex = DrawDeck.topCardIndex();
            BasicCard cardDrawn = DrawDeck.CardDeck[cardDrawnIndex];

            DrawDeck.removeCard(cardDrawnIndex);
            if (!PlayDrawnCard(cardDrawn))
            {
                TurnOrder.GoToNextTurn();
            }
        }

        private bool PlayDrawnCard(BasicCard cardDrawn)
        {
            bool playedCard = false;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            Console.WriteLine("You drew a " + cardDrawn.lookAtCard() + ".");

            if (DiscardDeck.isCardPlayable(cardDrawn))
            {
                Console.WriteLine("The card you drew is playable.");
                Console.WriteLine("Would you like to play this card?");

                if (PlayerEnterYesOrNo())
                {
                    currentPlayer.PlayCard(cardDrawn);
                    playedCard = true;
                }
                else
                {
                    currentPlayer.AddCardToHand(cardDrawn);
                }

            }
            else
            {
                currentPlayer.AddCardToHand(cardDrawn);
            }

            return playedCard;
        }
    }
}
