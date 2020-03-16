using System;
using System.Collections.Generic;
using UnoGame.Decks;
using UnoGame.Factories;
using UnoGame.Cards;
using UnoGame.Enums;
using UnoGame.Players;
using UnoGame.PlayerActions;

namespace UnoGame.Intermediaries
{
    public class Mediator
    {
        private readonly Turn turn;
        private readonly Deck drawDeck;
        private readonly Deck discardDeck;
        private readonly PerformCardAction performCardAction;
        private readonly CardFactory cardFactory;
        private readonly PerformMediatorActions performMediatorActions;
        private readonly PerformPlayerActions performPlayerActions;
        private readonly PlayerActionFactory playerActionFactory;

        public Mediator()
        {
            turn = new Turn();
            drawDeck = new DrawDeck();
            discardDeck = new DiscardDeck();            
            performCardAction = new PerformCardAction(drawDeck, discardDeck, turn);
            cardFactory = new CardFactory(performCardAction);
            performMediatorActions = new PerformMediatorActions(drawDeck, discardDeck, turn);
            playerActionFactory = new PlayerActionFactory(drawDeck, discardDeck, turn);
            performPlayerActions = new PerformPlayerActions(playerActionFactory, turn);

        }

        public void SetupGame()
        {
            performMediatorActions.ShowRules();
            drawDeck.createCardsForDeck(cardFactory); 
            drawDeck.shuffle();
            performMediatorActions.DeterminePlayers();
            performMediatorActions.Deal();
        }

        public void PlayGame()
        {
            Player currentPlayer;

            Console.WriteLine("Starting Game...");

            performMediatorActions.DiscardDeckAddFirstCard();

            do
            {
                currentPlayer = turn.Players[turn.CurrentPlayerIndex];

                Console.Clear();
                Console.WriteLine(currentPlayer.Name + "'s turn.");
                Pause();

                SetUpPlayerToTakeTheirTurn(currentPlayer);

                PlayerTakesTheirTurn(currentPlayer);

                Pause();

            }
            while (IsWinner() == false);

        }

        private void Pause()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }
        private void SetUpPlayerToTakeTheirTurn(Player currentPlayer)
        {
            Console.WriteLine();
            discardDeck.displayTopCard();
            Console.WriteLine("Your hand is: ");

            currentPlayer.LookAtHand();
        }
        private void PlayerTakesTheirTurn(Player currentPlayer)
        {
            bool readyforNextPlayersTurn;

            do
            {
                Console.WriteLine("What would you like to do?");
                string[] action = currentPlayer.PickAction();
                readyforNextPlayersTurn = performPlayerActions.PerformPlayerAction(action);

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
