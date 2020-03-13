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
        public PenaltyDraw(DrawDeck drawDeck, DiscardDeck discardDeck, Turn turn)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }

        public override bool performAction(int playerIndex)
        {
            playerActionDrawCard(playerIndex);
            return true;
        }

        private void playerActionDrawCard(int playerIndex)
        {
            Player playerToDraw = TurnOrder.Players[playerIndex];
            int cardDrawnIndex = DrawDeck.topCardIndex();
            BasicCard cardDrawn = DrawDeck.CardDeck[cardDrawnIndex];

            DrawDeck.removeCard(cardDrawnIndex);
            playerToDraw.addCardToHand(cardDrawn);
        }
    }
}
