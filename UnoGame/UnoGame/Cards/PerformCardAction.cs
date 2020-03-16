using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;

namespace UnoGame.Cards
{
    public class PerformCardAction
    {
        Deck drawDeck;
        Deck discardDeck;
        Turn turn;
        public PerformCardAction(Deck drawDeck, Deck discardDeck, Turn turn)
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
                turn.ReverseTurnDirection();
            }  
        }

        public void ReverseTurnDirectionTwoPlayers()
        {
                turn.ReverseTurnDirection();
                turn.GoToNextTurn();
        }

        public void DrawCard()
        {
            int nextPlayerIndex = turn.GetNextTurnIndex();
            Player nextPlayer = turn.Players[nextPlayerIndex];
            int cardDrawnIndex = drawDeck.topCardIndex();
            BasicCard cardDrawn = drawDeck.CardDeck[cardDrawnIndex];

            drawDeck.removeCard(cardDrawnIndex);
            nextPlayer.AddCardToHand(cardDrawn);
        }

        public void NextTurn()
        {
            turn.GoToNextTurn();
        }
    }
}
