using System;
using UnoGame.Players;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using UnoGame.Factories;

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
