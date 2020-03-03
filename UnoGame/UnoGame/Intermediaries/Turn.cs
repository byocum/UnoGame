using System;
using System.Collections.Generic;
using System.Text;
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

        public void showAllPlayersExceptOne(int currentPlayerIndex)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if(i != currentPlayerIndex)
                {
                    Console.WriteLine(i + " " + Players[i].Name);
                }
                
            }
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
