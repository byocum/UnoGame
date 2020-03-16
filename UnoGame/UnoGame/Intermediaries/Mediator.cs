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
        private Turn turn;
        private Deck drawDeck;
        private Deck discardDeck;
        private PerformCardAction performCardAction;
        private CardFactory cardFactory;
        private PerformMediatorActions performMediatorActions;
        private PerformPlayerActions performPlayerActions;
        private PlayerActionFactory playerActionFactory;

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

        public void setupGame()
        {
            performMediatorActions.showRules();
            drawDeck.createCardsForDeck(cardFactory); 
            drawDeck.shuffle();
            performMediatorActions.determinePlayers();
            performMediatorActions.deal();
        }

        public void playGame()
        {
            Player currentPlayer;

            Console.WriteLine("Starting Game...");

            performMediatorActions.discardDeckAddFirstCard();

            do
            {
                int currentPlayerIndex = turn.CurrentPlayerIndex;
                currentPlayer = turn.Players[turn.CurrentPlayerIndex];

                Console.Clear();
                Console.WriteLine(currentPlayer.Name + "'s turn.");
                pause();

                setUpPlayerToTakeTheirTurn(currentPlayer);

                playerTakesTheirTurn(currentPlayer);

                pause();

            }
            while (isWinner() == false);

        }

        private void pause()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }
        private void setUpPlayerToTakeTheirTurn(Player currentPlayer)
        {
            Console.WriteLine();
            discardDeck.displayTopCard();
            Console.WriteLine("Your hand is: ");

            currentPlayer.lookAtHand();
        }
        private void playerTakesTheirTurn(Player currentPlayer)
        {
            bool readyforNextPlayersTurn = false;

            do
            {
                Console.WriteLine("What would you like to do?");
                string[] action = currentPlayer.pickAction();
                readyforNextPlayersTurn = performPlayerActions.performPlayerAction(action);

            } while (readyforNextPlayersTurn == false);

        }

        private bool isWinner()
        {
            List<Player> players = turn.Players;
            bool isWinner = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].numCardsInHand() <= 0)
                {
                    isWinner = true;
                    Console.WriteLine(players[i].Name + " won!");
                }
            }

            return isWinner;
        }
    }
}
