﻿using System;
using UnoGame.Decks;
using UnoGame.Intermediaries;

namespace UnoGame.GameActions
{
    public class DeterminePlayers:GameAction
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
                bool isValidPlayerName;

                do
                {
                    Console.WriteLine("Please enter a name for the player:");
                    playerName = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(playerName) || playerName.Length > 20)
                    {
                        Console.WriteLine("That is not a valid player name.");
                        Console.WriteLine("The player's name must be at least 1 character and no more than 20 charaters.");
                        isValidPlayerName = false;
                    }
                    else
                    {
                        isValidPlayerName = true;
                    }
                   
                } while (isValidPlayerName == false);
                
                TurnOrder.AddPlayer(playerName, DiscardDeck);
                if(TurnOrder.Players.Count == 10)
                {
                    Console.WriteLine("The max number of players for the game is 10.  You now have 10 players.");
                    Console.WriteLine("Play will start.");
                    addAnotherPlayer = false;
                }
                else if (count > 1)
                {
                    Console.WriteLine("Would you like to add another player?");
                    addAnotherPlayer = PlayerEnterYesOrNo();
                }

                count++;
            }
        }
    }
}