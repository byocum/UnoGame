using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;
using UnoGame.Cards;

namespace UnoGame.PlayerActions
{
    public class PenaltyDraw:PlayerAction
    {
        public PenaltyDraw(Deck drawDeck, Deck discardDeck, Turn turn)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }

        public override bool PerformAction(int playerIndex)
        {
            PlayerActionDrawCard(playerIndex);
            return true;
        }

        private void PlayerActionDrawCard(int playerIndex)
        {
            Player playerToDraw = TurnOrder.Players[playerIndex];
            int cardDrawnIndex = DrawDeck.topCardIndex();
            BasicCard cardDrawn = DrawDeck.CardDeck[cardDrawnIndex];

            DrawDeck.removeCard(cardDrawnIndex);
            playerToDraw.AddCardToHand(cardDrawn);
        }
    }
}
