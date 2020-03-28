using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Intermediaries;
using UnoGame.Players;

namespace UnoGame.GameActions
{
    public class NumCardsInHands:GameAction
    {
        public NumCardsInHands(Turn turn)
        {
            TurnOrder = turn;
        }

        public override bool PerformAction()
        {
            Console.WriteLine("The number of cards in each players hand is:");

            foreach(Player player in TurnOrder.Players)
            {
                Console.WriteLine(player.Name + ": " + player.NumCardsInHand());
            }

            return false;
        }
    }
}
