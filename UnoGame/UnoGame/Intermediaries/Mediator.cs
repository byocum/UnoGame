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
                for(int player = 0; player < turn.Players.Count; player++)
                {
                    int drawDeckTopCardIndex = drawDeck.CardDeck.Count - 1;
                    BasicCard cardDealing = drawDeck.CardDeck[drawDeckTopCardIndex];

                    drawDeck.removeCard(drawDeckTopCardIndex, discardDeck);
                    turn.Players[player].addCardToHand(cardDealing);
                }
            }
        }

        private void moveCardFromDrawDeckToDiscardDeck()
        {
            int topCardDrawDeckIndex = drawDeck.CardDeck.Count - 1;
            BasicCard topCardDrawDeck = drawDeck.CardDeck[topCardDrawDeckIndex];

            drawDeck.removeCard(topCardDrawDeckIndex, discardDeck);
            discardDeck.addCard(topCardDrawDeck);
        }

        public void startGame()
        {    
            Console.WriteLine("Starting Game...");
            //bool playerActionCompleted = false;
            Console.WriteLine("Putting the top card on the draw pile on the discard deck...");
            moveCardFromDrawDeckToDiscardDeck();

            int topCardOnDiscardDeckIndex = discardDeck.CardDeck.Count - 1;
            BasicCard discardDeckTopCard = discardDeck.CardDeck[topCardOnDiscardDeckIndex];

            while (discardDeckTopCard.Type == CardType.WildDrawFour)
            {
                discardDeck.removeCard(discardDeck.CardDeck.Count - 1);
                drawDeck.addCardRandomlyToDeck(discardDeckTopCard);
                moveCardFromDrawDeckToDiscardDeck();
            }

            discardDeck.displayTopCard();
            

            if(discardDeckTopCard.CardWithNoActions == false)
            {
                Console.WriteLine("This card plays when it is turned up at the beginning of the game.");
                Console.WriteLine("Playing card...");

                discardDeckTopCard.playCard();
            }


            bool gameOver = false;
            do
            {
                int currentPlayerIndex = turn.CurrentPlayerIndex;
                Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];

                Console.WriteLine(currentPlayer.Name + "'s turn.");
                discardDeck.displayTopCard();
                Console.WriteLine("Your hand is: ");

                currentPlayer.lookAtHand();
                string[] action = currentPlayer.pickAction();
                performPlayerAction(action);

                if (currentPlayerIndex != turn.CurrentPlayerIndex)
                {
                    Console.Clear();
                }

            }
            while (gameOver == false);
            //while (playerActionCompleted == false);
        }

        private bool performPlayerAction(string[] playerAction)
        {
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];
            bool intConverted = int.TryParse(playerAction[0], out int cardIndex);
            bool enumConverted = Enum.TryParse<PlayerAction>(playerAction[0], out PlayerAction action);
            bool playerActionCompleted = false;

            if (intConverted && cardIndex < currentPlayer.numCardsInHand() && cardIndex >= 0)
            {
                currentPlayer.playCard(cardIndex);
                playerActionCompleted = true;

            }else if (enumConverted)
            {            
                    switch (action)
                {
                    case PlayerAction.Rules:
                        displayRules();
                        break;
                    case PlayerAction.Draw:
                        playerActionDrawCard();
                        playerActionCompleted = true;
                        break;
                    case PlayerAction.Uno:

                        break;
                    default:
                        actionErrorMessage(playerAction);
                        break;
                }

            }
            else
            {
                actionErrorMessage(playerAction);

            }

            return playerActionCompleted;
        }

        private void actionErrorMessage(string[] playerAction)
        {
            Console.WriteLine(playerAction[0] + " is not a possible action.  Possible actions are: ");
            foreach (string possibleAction in Enum.GetNames(typeof(PlayerAction)))
            {
                Console.WriteLine(possibleAction);
            }

            Console.WriteLine("or the number of the card you would like to play.");
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

            drawDeck.removeCard(cardDrawnIndex, discardDeck);
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
