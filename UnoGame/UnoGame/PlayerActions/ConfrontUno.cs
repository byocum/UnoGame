using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using UnoGame.Players;

namespace UnoGame.PlayerActions
{
    public class ConfrontUno:PlayerAction
    {
        PlayerAction penaltyDraw;
        public ConfrontUno(Turn turn, PlayerAction penaltyDraw)
        {
            TurnOrder = turn;
            this.penaltyDraw = penaltyDraw;
        }

        public override bool performAction()
        {
            bool isNextPlayersTurn = false;

            didPlayerSayUno();

            return isNextPlayersTurn;
        }

        private void didPlayerSayUno()
        {
            int currentPlayerIndex = TurnOrder.CurrentPlayerIndex;
            Player currentPlayer = TurnOrder.Players[currentPlayerIndex];
            int playerPickedIndex;

            playerPickedIndex = TurnOrder.pickAPlayer();
            Player playerPicked = TurnOrder.Players[playerPickedIndex];

            if (playerPicked.numCardsInHand() == 1 && playerPicked.SaidUno == false)
            {
                penaltyForNotSayingUno(playerPickedIndex);
            }
            else
            {
                Console.WriteLine(playerPicked.Name + " Said Uno or did not have only one card in their hand.");
            }
        }

        private void penaltyForNotSayingUno(int indexOfPlayerPicked)
        {
            penaltyDraw.performAction(indexOfPlayerPicked);
            penaltyDraw.performAction(indexOfPlayerPicked);

            Console.WriteLine(TurnOrder.Players[indexOfPlayerPicked].Name + " drew two cards for having only one card in their hand and not saying uno.");
        }
    }
}
