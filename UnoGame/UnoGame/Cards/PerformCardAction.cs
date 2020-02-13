using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;

namespace UnoGame.Cards
{
    public class PerformCardAction
    {
        DrawDeck drawDeck;
        DiscardDeck discardDeck;
        Turn turn;
        public PerformCardAction(DrawDeck drawDeck, DiscardDeck discardDeck, Turn turn)
        {
            this.drawDeck = drawDeck;
            this.discardDeck = discardDeck;
            this.turn = turn;
        }

        public void ReverseTurnOrder()
        {
            turn.reverseTurnDirection();
        }

        public void DrawCard()
        {
            int nextPlayerIndex = turn.getNextTurnIndex();
            int cardDrawnIndex = drawDeck.CardDeck.Count - 1;
            BasicCard cardDrawn = drawDeck.CardDeck[cardDrawnIndex];

            drawDeck.removeCard(cardDrawnIndex);
            turn.Players[nextPlayerIndex].addCardToHand(cardDrawn);

        }

        public void SetCardColor(CardColor color)
        {
            BasicCard cardToChangeColor = discardDeck.CardDeck[discardDeck.CardDeck.Count - 1];
            cardToChangeColor.setColor(color);
        }

        public void NextTurn()
        {
            turn.goToNextTurn();

        }
    }
}
