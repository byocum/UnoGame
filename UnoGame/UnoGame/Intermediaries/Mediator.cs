using System;
using UnoGame.Decks;
using UnoGame.Factories;
using UnoGame.Cards;
using UnoGame.Enums;
using UnoGame.Players;

namespace UnoGame.Intermediaries
{
    public class Mediator
    {
        Turn turn;
        DrawDeck drawDeck;
        DiscardDeck discardDeck;
        PerformCardAction performCardAction;
        CardFactory cardFactory;

        public Mediator()
        {

            turn = new Turn();
            drawDeck = new DrawDeck();
            discardDeck = new DiscardDeck();            
            performCardAction = new PerformCardAction(drawDeck, discardDeck, turn);
            cardFactory = new CardFactory(performCardAction);
        }

        public void setupGame()
        {
            //ToDo: Display the instructions for the game
            drawDeck.createCardsForDeck(cardFactory); 
            drawDeck.shuffle();
            determinePlayers();
            dealCards();
            moveCardFromDrawDeckToDiscardDeck();
            discardDeck.lookAtTopCard();
        }

        private void determinePlayers()
        {
            string playerName;
            string addAnotherPlayer = "y";
            int count = 1;

            while(addAnotherPlayer[0] == 'y')
            {
                Console.WriteLine("Please enter a name for the player:");
                playerName = Console.ReadLine();
                turn.addPlayer(playerName, discardDeck);

                if(count > 1)
                {
                    Console.WriteLine("Would you like to add another player? Enter y for yes another character for no.");
                    addAnotherPlayer =  Console.ReadLine().Trim().ToLower();
                }

                count++;
            }

        }
        private void dealCards()
        {
            Console.WriteLine("Dealing Cards...");

            for(int numCardsEachPersonHas = 0; numCardsEachPersonHas < 7; numCardsEachPersonHas++)
            {
                for(int player = 1; player < turn.Players.Count; player++)
                {
                    int drawDeckTopCardIndex = drawDeck.CardDeck.Count - 1;
                    BasicCard cardDealing = drawDeck.CardDeck[drawDeckTopCardIndex];

                    drawDeck.removeCard(drawDeckTopCardIndex);
                    turn.Players[player].addCardToHand(cardDealing);
                }
            }
        }

        private void moveCardFromDrawDeckToDiscardDeck()
        {
            int topCardDrawDeckIndex = drawDeck.CardDeck.Count - 1;
            BasicCard topCardDrawDeck = drawDeck.CardDeck[topCardDrawDeckIndex];
            drawDeck.removeCard(topCardDrawDeckIndex);
            discardDeck.addCard(topCardDrawDeck);
        }

        public void startGame()
        {
            Console.WriteLine("Starting Game...");
        }

        private void performPlayerAction(string[] playerAction)
        {
            Enum.TryParse<PlayerAction>(playerAction[0], out PlayerAction action);

            switch (action)
            {
                case PlayerAction.Rules:
                    displayRules();
                    break;
                case PlayerAction.Draw:
                    playerActionDrawCard();
                    break;
                case PlayerAction.Uno:

                    break;
                default:
                    Console.WriteLine(playerAction[0] + " is not a possible action.  Possible actions are: ");
                    foreach (string possibleAction in Enum.GetNames(typeof(PlayerAction)))
                    {
                        Console.WriteLine(possibleAction);
                    }
                    break;
            }

        }

        private void displayRules()
        {
            //ToDo: Add Game Rules
            Console.WriteLine("Game Rules");
        }

        private void playerActionDrawCard()
        {
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];
            int cardDrawnIndex = drawDeck.CardDeck.Count - 1;
            BasicCard cardDrawn = drawDeck.CardDeck[cardDrawnIndex];

            drawDeck.removeCard(cardDrawnIndex);
            if (!currentPlayer.playDrawnCard(cardDrawn))
            {
                turn.goToNextTurn();
            }
        }

        private void playerActionUno()
        {
            string response;
            int numPlayerEntered;
            int currentPlayerIndex = turn.CurrentPlayerIndex;
            Player currentPlayer = turn.Players[currentPlayerIndex];
            bool hasPlayerPickedPlayer = false;
            do
            {
                Console.WriteLine("Which player did not say Uno? Please enter the player number.");
                turn.showPlayers();

                response = currentPlayer.playerEntryTitleCase();

                if (int.TryParse(response, out numPlayerEntered))
                {
                    if (numPlayerEntered < turn.Players.Count || numPlayerEntered >= 0)
                    {
                        penaltyForNotSayingUno(numPlayerEntered);
                    }
                    else
                    {
                        Console.WriteLine("That is not the number of a player.  The players are: ");
                    }
                }
                else
                {
                    Console.Write("That is not the number. Please select the number of a player. The players are: ");
                }

            } while (hasPlayerPickedPlayer == false);

        }

        private void penaltyForNotSayingUno(int indexOfPlayerPicked)
        {

        }
    }
}
