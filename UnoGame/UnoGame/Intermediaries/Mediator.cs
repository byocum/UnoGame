using System;
using System.Collections.Generic;
using UnoGame.Decks;
using UnoGame.Factories;
using UnoGame.Cards;
using UnoGame.Players;

namespace UnoGame.Intermediaries
{
    public class Mediator
    {
        private readonly Turn turn;
        private readonly Deck drawDeck;
        private readonly Deck discardDeck;
        private readonly PerformCardAction performCardAction;
        private readonly CardFactory cardFactory;
        private readonly ActionFactory actionFactory;
        private readonly PerformAction performAction;
        private readonly InterperatePlayerInput interperatePlayerInput;

        public Mediator()
        {
            turn = new Turn();
            drawDeck = new DrawDeck();
            discardDeck = new DiscardDeck();
            performCardAction = new PerformCardAction(drawDeck, discardDeck, turn);
            cardFactory = new CardFactory(performCardAction);
            actionFactory = new ActionFactory(drawDeck, discardDeck, turn);
            performAction = new PerformAction(actionFactory);
            interperatePlayerInput = new InterperatePlayerInput(performAction, turn);
        }

        public void SetupGame()
        {
            performAction.Rules();
            drawDeck.createCardsForDeck(cardFactory);
            drawDeck.shuffle();
            performAction.DeterminePlayers();
            performAction.Deal();
        }

        public void PlayGame()
        {
            Player currentPlayer;

            Console.WriteLine("Starting Game...");

            performAction.DiscardDeckAddFirstCard();

            performAction.Pause();

            do
            {
                currentPlayer = turn.Players[turn.CurrentPlayerIndex];

                Console.Clear();
                Console.WriteLine(currentPlayer.Name + "'s turn.");
                performAction.Pause();

                DisplayPlayersWhoSaidUno();

                PlayerTakesTheirTurn(currentPlayer);

                performAction.Pause();

            }
            while (IsWinner() == false);

            Environment.Exit(0);

        }

        private void DisplayPlayersWhoSaidUno()
        {
            string currentPlayerName = turn.Players[turn.CurrentPlayerIndex].Name;

            foreach (Player player in turn.Players)
            {
                if (player.SaidUno == true)
                {
                    if (player.Name == turn.Players[turn.CurrentPlayerIndex].Name)
                    {
                        Console.WriteLine("You said UNO!!!");
                    }
                    else
                    {
                        Console.WriteLine(player.Name + " said UNO!!!");
                    }       
                }
            }
        }

        private void PlayerTakesTheirTurn(Player currentPlayer)
        {
            bool readyforNextPlayersTurn;

            do
            {            
                Console.WriteLine();
                discardDeck.displayTopCard();
                Console.WriteLine("Your hand is: ");
                currentPlayer.LookAtHand();
                Console.WriteLine("What would you like to do?");
                string[] action = currentPlayer.PickAction();
                readyforNextPlayersTurn = interperatePlayerInput.PerformPlayerAction(action);

            } while (readyforNextPlayersTurn == false);

        }

        private bool IsWinner()
        {
            List<Player> players = turn.Players;
            bool isWinner = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].NumCardsInHand() <= 0)
                {
                    isWinner = true;
                    Console.WriteLine(players[i].Name + " won!");
                }
            }

            return isWinner;
        }
    }
}
