using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;

namespace UnoGame.PlayerActions
{
    public class DeterminePlayers:PlayerAction
    {
        public DeterminePlayers(Turn turn, Deck discardDeck)
        {
            TurnOrder = turn;
            DiscardDeck = discardDeck;
        }
        public override bool PerformAction()
        {
            CreatePlayers();
            return true;
        }

        private void CreatePlayers()
        {
            string playerName;
            bool addAnotherPlayer = true;
            int count = 1;

            while (addAnotherPlayer == true)
            {
                Console.WriteLine("Please enter a name for the player:");
                playerName = Console.ReadLine();
                TurnOrder.AddPlayer(playerName, DiscardDeck);

                if (count > 1)
                {
                    Console.WriteLine("Would you like to add another player?");
                    addAnotherPlayer = PlayerEnterYesOrNo();
                }
                count++;
            }
        }
    }
}
