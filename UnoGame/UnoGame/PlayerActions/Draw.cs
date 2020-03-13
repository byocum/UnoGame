using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;

namespace UnoGame.PlayerActions
{
    class Draw : PlayerAction
    {
        public Draw(DrawDeck drawDeck, DiscardDeck discardDeck, Turn turn)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }

        public override bool performAction(int playerIndex)
        {
            drawAndPlayCard(playerIndex);
            return true;
        }

        private void drawAndPlayCard(int playerIndex)
        {
            Player currentPlayer = TurnOrder.Players[playerIndex];
            int cardDrawnIndex = DrawDeck.topCardIndex();
            BasicCard cardDrawn = DrawDeck.CardDeck[cardDrawnIndex];

            DrawDeck.removeCard(cardDrawnIndex);
            if (!playDrawnCard(cardDrawn))
            {
                TurnOrder.goToNextTurn();
            }
        }

        private bool playDrawnCard(BasicCard cardDrawn)
        {
            bool playedCard = false;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            Console.WriteLine("You drew a " + cardDrawn.lookAtCard() + ".");

            if (DiscardDeck.isCardPlayable(cardDrawn))
            {
                Console.WriteLine("The card you drew is playable.");
                Console.WriteLine("Would you like to play this card?");

                if (playerEnterYesOrNo())
                {
                    currentPlayer.playCard(cardDrawn);
                    playedCard = true;
                }
                else
                {
                    currentPlayer.addCardToHand(cardDrawn);
                }

            }
            else
            {
                currentPlayer.addCardToHand(cardDrawn);
            }

            return playedCard;
        }
    }
}
