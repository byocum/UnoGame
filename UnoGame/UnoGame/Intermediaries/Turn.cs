using System;
using System.Collections.Generic;
using UnoGame.Players;
using UnoGame.Enums;
using UnoGame.Decks;
using UnoGame.Functions;

namespace UnoGame.Intermediaries
{
    public class Turn
    {
        private readonly List<Player> players;
        private int currentPlayerIndex;
        TurnDirection turnDirection;

        public List<Player> Players
        {
            get { return players; }
        }

        public int CurrentPlayerIndex
        {
            get { return currentPlayerIndex; }
        }

        public Turn()
        {
            players = new List<Player>();
            currentPlayerIndex = 0;
            turnDirection = TurnDirection.Ascending;
        }

        public void AddPlayer(string name, Deck discardDeck)
        {
            name = Function.titleCase(name);

            Player player = new Player(name, discardDeck);
            players.Add(player);
        }

        public void ListOtherPlayers()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if(i != currentPlayerIndex)
                {
                    Console.WriteLine(i + " " + Players[i].Name);
                }   
            }
        }

        public int PickAPlayer()
        {
            Player currentPlayer = Players[CurrentPlayerIndex];

            bool validPlayerPicked = false;
            int playerPickedIndex;

            do
            {
                Console.WriteLine("Pick the number of one of the following players: ");
                ListOtherPlayers();

                string response = currentPlayer.PlayerEntryTitleCase();
                bool isNumber = int.TryParse(response, out playerPickedIndex);

                if (isNumber && playerPickedIndex >= 0 && playerPickedIndex < Players.Count && playerPickedIndex != CurrentPlayerIndex)
                {
                    validPlayerPicked = true;
                }
                else
                {
                    Console.WriteLine("That is not the number of one of the players.");
                }

            } while (validPlayerPicked == false);

            return playerPickedIndex;
        }

        public void ReverseTurnDirection()
        {
            if(turnDirection == TurnDirection.Ascending)
            {
                turnDirection = TurnDirection.Decending;
            }
            else
            {
                turnDirection = TurnDirection.Ascending;
            }
        }

        public void GoToNextTurn()
        {
            if (turnDirection == TurnDirection.Ascending)
            {
                currentPlayerIndex = GetNextTurnAscendingIndex();
            }
            else
            {
                currentPlayerIndex = GetNextTurnDescendingIndex();
            }
        }
        public int GetNextTurnIndex()
        {
            if (turnDirection == TurnDirection.Ascending)
            {
                return GetNextTurnAscendingIndex();
            }
            else
            {
                return GetNextTurnDescendingIndex();
            }
        }

        private int GetNextTurnAscendingIndex()
        {
            int turnOfLastPlayer = players.Count - 1;

            if (currentPlayerIndex >= 0 && currentPlayerIndex < turnOfLastPlayer)
            {
                return currentPlayerIndex + 1;
            }
            else
            {
                return 0;
            }
        }

        private int GetNextTurnDescendingIndex()
        {
            int turnOfLastPlayer = players.Count - 1;

            if (currentPlayerIndex > 0 && currentPlayerIndex <= turnOfLastPlayer)
            {
                return currentPlayerIndex - 1;
            }
            else
            {
                return turnOfLastPlayer;
            }
        }
    }
}
