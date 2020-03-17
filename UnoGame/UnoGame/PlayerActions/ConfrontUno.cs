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
        private readonly Player playerPicked;
        public ConfrontUno(Turn turn, PlayerAction penaltyDraw, Player playerPicked)
        {
            TurnOrder = turn;
            this.penaltyDraw = penaltyDraw;
            this.playerPicked = playerPicked;
        }

        public override bool PerformAction()
        {
            bool isNextPlayersTurn = false;

            DidPlayerSayUno();

            return isNextPlayersTurn;
        }

        private void DidPlayerSayUno()
        {
            if (playerPicked.NumCardsInHand() == 1 && playerPicked.SaidUno == false)
            {
                PenaltyForNotSayingUno();
            }
            else
            {
                Console.WriteLine(playerPicked.Name + " Said Uno or did not have only one card in their hand.");
            }
        }

        private void PenaltyForNotSayingUno()
        {
            penaltyDraw.PerformAction();
            penaltyDraw.PerformAction();

            Console.WriteLine(playerPicked.Name + " drew two cards for having only one card in their hand and not saying uno.");
        }
    }
}
