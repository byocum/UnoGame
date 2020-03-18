using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Intermediaries;
using UnoGame.Players;

namespace UnoGame.GameActions
{
    public class SortHand:GameAction
    {
        public SortHand(Turn turnOrder)
        {
            this.TurnOrder = turnOrder; 
        }
        public override bool PerformAction()
        {
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];
            currentPlayer.Hand.sort();
            currentPlayer.LookAtHand();

            return false;
        }
    }
}
