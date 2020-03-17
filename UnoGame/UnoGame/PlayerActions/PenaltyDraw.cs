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
        private Player playerDrawingCard;
        public PenaltyDraw(Deck drawDeck, Player playerDrawingCard)
        {
            DrawDeck = drawDeck;
            this.playerDrawingCard = playerDrawingCard;
        }

        public override bool PerformAction()
        {
            PlayerActionDrawCard();
            return true;
        }

        private void PlayerActionDrawCard()
        {
            int cardDrawnIndex = DrawDeck.topCardIndex();
            BasicCard cardDrawn = DrawDeck.CardDeck[cardDrawnIndex];

            DrawDeck.removeCard(cardDrawnIndex);
            playerDrawingCard.AddCardToHand(cardDrawn);
        }
    }
}
