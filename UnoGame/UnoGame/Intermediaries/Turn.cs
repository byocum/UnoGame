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
        List<Player> players;
        int currentPlayerIndex;
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

        public void addPlayer(string name, DiscardDeck discardDeck)
        {
            name = Function.titleCase(name);

            Player player = new Player(name, discardDeck);
            players.Add(player);
        }

        public void listOtherPlayers()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if(i != currentPlayerIndex)
                {
                    Console.WriteLine(i + " " + Players[i].Name);
                }   
            }
        }

        public int pickAPlayer()
        {
            Player currentPlayer = Players[CurrentPlayerIndex];

            bool validPlayerPicked = false;
            int playerPickedIndex;

            do
            {
                Console.WriteLine("Pick the number of one of the following players: ");
                listOtherPlayers();

                string response = currentPlayer.playerEntryTitleCase();
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

        public void reverseTurnDirection()
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

        public void goToNextTurn()
        {
            if (turnDirection == TurnDirection.Ascending)
            {
                currentPlayerIndex = getNextTurnAscendingIndex();
            }
            else
            {
                currentPlayerIndex = getNextTurnDescendingIndex();
            }
        }
        public int getNextTurnIndex()
        {
            if (turnDirection == TurnDirection.Ascending)
            {
                return getNextTurnAscendingIndex();
            }
            else
            {
                return getNextTurnDescendingIndex();
            }
        }

        private int getNextTurnAscendingIndex()
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

        private int getNextTurnDescendingIndex()
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
