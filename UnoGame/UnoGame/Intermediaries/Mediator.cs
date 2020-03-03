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
            gameRules();
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

            Player currentPlayer;

            do
            {
                int currentPlayerIndex = turn.CurrentPlayerIndex;
                currentPlayer = turn.Players[turn.CurrentPlayerIndex];

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
            while (currentPlayer.numCardsInHand() > 0);

            endGame(currentPlayer);
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
                        gameRules();
                        break;
                    case PlayerAction.Draw:
                        playerActionDrawCard();
                        playerActionCompleted = true;
                        break;
                    case PlayerAction.Uno:
                        playerActionUno();
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

        private void playerActionDrawCard(int playerIndex)
        {
            Player playerToDraw = turn.Players[playerIndex];
            int cardDrawnIndex = drawDeck.CardDeck.Count - 1;
            BasicCard cardDrawn = drawDeck.CardDeck[cardDrawnIndex];

            drawDeck.removeCard(cardDrawnIndex, discardDeck);
            playerToDraw.putCardInHand(cardDrawn);
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
                turn.showAllPlayersExceptOne(currentPlayerIndex);

                response = currentPlayer.playerEntryTitleCase();

                if (int.TryParse(response, out numPlayerEntered))
                {
                    if ((numPlayerEntered < turn.Players.Count || numPlayerEntered >= 0) && numPlayerEntered != currentPlayerIndex)
                    {
                        hasPlayerPickedPlayer = true;
                        Player playerPicked = turn.Players[numPlayerEntered];
                        if(playerPicked.numCardsInHand() == 1 && playerPicked.SaidUno == false)
                        {
                            penaltyForNotSayingUno(numPlayerEntered);
                        }
                        else
                        {
                            Console.WriteLine(playerPicked.Name + " Said Uno or did not have only one card in their hand.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not the number of a player. Please select a player number.");
                    }
                }
                else
                {
                    Console.Write("That is not the number. Please select a player number.");
                }

            } while (hasPlayerPickedPlayer == false);
        }

        private void penaltyForNotSayingUno(int indexOfPlayerPicked)
        {
            playerActionDrawCard(indexOfPlayerPicked);
            playerActionDrawCard(indexOfPlayerPicked);

            Console.WriteLine(turn.Players[indexOfPlayerPicked].Name + " drew two cards for having only one card in their hand and not saying uno.");
        }

        public void gameRules()
        {
            string welcome = "Welcome to the game of UNO.           \n\n";
            Console.WriteLine(welcome.PadLeft(Console.WindowWidth - welcome.Length));

            Console.WriteLine("PLAYING A CARD \n");
            Console.WriteLine("When playing a card type in the number to the left of the card.");
            Console.Write("For Example: If the card displays as: \"3 Green Draw 2\" type in \"3\".\n");

            //ToDo: I want to make sure the user does not have to do this.
            Console.WriteLine("When writing two actions on one line put a comma between the two actions.\n See examples below.\n");

            //ToDo: Write functionality for declaring uno. Then rewrite the directions.
            Console.WriteLine("SAY UNO\n");
            Console.WriteLine("In order to say UNO when playing your second to last card, type in \"UNO\"");
            Console.WriteLine("after the number of the card you are playing.");
            Console.WriteLine("For Example: \"3, UNO\"\n");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();

            Console.WriteLine("CALL A PLAYER OUT FOR NOT SAYING UNO\n");
            Console.WriteLine("If you want to call a player out for not saying Uno when they are playing");
            Console.WriteLine("their second to last card type \"Uno\" you will then be asked which player you want to pick. ");
            Console.WriteLine("Type the number next to the players name to select a player.");

            Console.WriteLine("If a player is called out for not saying Uno when they play their second to last");
            Console.WriteLine("card they have to draw 2 cards.\n");

            Console.WriteLine("DRAW A CARD\n");
            Console.WriteLine("Type \"Draw\" to draw a card.You may draw a card on your turn whether or");
            Console.WriteLine("not you have a playable card. Once you have drawn a card, you will have the");
            Console.WriteLine("option to play the card you drew if it is a playable card. However, you will");
            Console.WriteLine("not have the option to play a card in your hand.\n");

            Console.WriteLine("SEE GAME RULES\n");
            Console.WriteLine("If you want to see these instructions again during the game type \"Rules\".");

            Console.WriteLine("\nPress any key to enter players and start the game.");
            Console.ReadLine();
        }

        private void endGame(Player winner)
        {
            Console.WriteLine(winner.Name + " you won!");
        }
    }
}
