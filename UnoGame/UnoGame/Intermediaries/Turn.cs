using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Players;
using UnoGame.Enums;
using UnoGame.Decks;

namespace UnoGame.Intermediaries
{
    public class Turn
    {
        List<Player> players;
        int turn;
        TurnDirection turnDirection;

        public List<Player> Players
        {
            get { return players; }
        }

        public Turn()
        {
            players = new List<Player>();
            turn = 0;
            turnDirection = TurnDirection.Ascending;
        }

        public void addPlayer(string name, DiscardDeck discardDeck)
        {
            PlayerHand hand = new PlayerHand();
            Player player = new Player(name, hand, discardDeck);
            players.Add(player);
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

        public void nextTurn()
        {
            if (turnDirection == TurnDirection.Ascending)
            {
                nextTurnAscending();
            }
            else
            {
                nextTurnDescending();
            }  
        }

        private void nextTurnAscending()
        {
            int turnOfLastPlayer = players.Count - 1;

            if(turn >= 0 && turn < turnOfLastPlayer)
            {
                turn++;
            }
            else
            {
                turn = 0;
            }
        }

        private void nextTurnDescending()
        {
            int turnOfLastPlayer = players.Count - 1;

            if (turn > 0 && turn <= turnOfLastPlayer)
            {
                turn--;
            }
            else
            {
                turn = turnOfLastPlayer;
            }
        }
    }
}
