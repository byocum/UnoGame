using System;
using UnoGame.Players;
using UnoGame.Intermediaries;

namespace UnoGame.GameActions
{
    public class SayUno:GameAction
    {
        public SayUno(Turn turn)
        {
            TurnOrder = turn;
        }
        public override bool PerformAction()
        {
            return PlayerSaysUno();
        }
        private bool PlayerSaysUno()
        {

            bool saidUno = false;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            if (currentPlayer.SaidUno == false)
            {
                if (currentPlayer.SayUno())
                {
                    saidUno = true;
                }
            }
            else
            {
                Console.WriteLine("You already said Uno.");
            }

            return saidUno;
        }
    }
}
