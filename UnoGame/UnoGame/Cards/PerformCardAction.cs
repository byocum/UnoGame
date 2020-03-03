using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using UnoGame.Players;

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
            if (turn.Players.Count == 2)
            {
                ReverseTurnDirectionTwoPlayers();
            }
            else
            {
                turn.reverseTurnDirection();
            }  
        }

        public void ReverseTurnDirectionTwoPlayers()
        {
                turn.reverseTurnDirection();
                turn.goToNextTurn();
        }

        public void DrawCard()
        {
            int nextPlayerIndex = turn.getNextTurnIndex();
            Player nextPlayer = turn.Players[nextPlayerIndex];
            int cardDrawnIndex = drawDeck.CardDeck.Count - 1;
            BasicCard cardDrawn = drawDeck.CardDeck[cardDrawnIndex];

            drawDeck.removeCard(cardDrawnIndex, discardDeck);
            nextPlayer.addCardToHand(cardDrawn);
        }

        public void NextTurn()
        {
            turn.goToNextTurn();
        }
    }
}
