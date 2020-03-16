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
        private readonly PlayerAction penaltyDraw;
        public ConfrontUno(Turn turn, PlayerAction penaltyDraw)
        {
            TurnOrder = turn;
            this.penaltyDraw = penaltyDraw;
        }

        public override bool PerformAction()
        {
            bool isNextPlayersTurn = false;

            DidPlayerSayUno();

            return isNextPlayersTurn;
        }

        private void DidPlayerSayUno()
        {
            int playerPickedIndex;

            playerPickedIndex = TurnOrder.PickAPlayer();
            Player playerPicked = TurnOrder.Players[playerPickedIndex];

            if (playerPicked.NumCardsInHand() == 1 && playerPicked.SaidUno == false)
            {
                PenaltyForNotSayingUno(playerPickedIndex);
            }
            else
            {
                Console.WriteLine(playerPicked.Name + " Said Uno or did not have only one card in their hand.");
            }
        }

        private void PenaltyForNotSayingUno(int indexOfPlayerPicked)
        {
            penaltyDraw.PerformAction(indexOfPlayerPicked);
            penaltyDraw.PerformAction(indexOfPlayerPicked);

            Console.WriteLine(TurnOrder.Players[indexOfPlayerPicked].Name + " drew two cards for having only one card in their hand and not saying uno.");
        }
    }
}
