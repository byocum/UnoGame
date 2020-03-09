using System;
using System.Collections.Generic;
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
                    if(addAnotherPlayer.Length == 0)
                    {
                        addAnotherPlayer = "n";
                    }
                }

                count++;
            }
        }
        private void dealCards()
        {
            Console.WriteLine("Dealing Cards...");

            dealEachPlayerSevenCards();
        }

        private void dealEachPlayerSevenCards()
        {
            for (int numCardsEachPersonHas = 0; numCardsEachPersonHas < 7; numCardsEachPersonHas++)
            {
                dealEachPlayerOneCard();
            }
        }

        private void dealEachPlayerOneCard()
        {
            for (int player = 0; player < turn.Players.Count; player++)
            {
                dealCard(player);
            }

        }

        private void dealCard(int playerIndex)
        {
            int drawDeckTopCardIndex = drawDeck.topCardIndex();

            BasicCard cardDealing = drawDeck.CardDeck[drawDeckTopCardIndex];

            drawDeck.removeCard(drawDeckTopCardIndex, discardDeck);
            turn.Players[playerIndex].addCardToHand(cardDealing);

        }
        private void moveCardFromDrawDeckToDiscardDeck()
        {
            int drawDeckTopCardIndex = drawDeck.topCardIndex();
            BasicCard drawDeckTopCard = drawDeck.CardDeck[drawDeckTopCardIndex];

            drawDeck.removeCard(drawDeckTopCardIndex, discardDeck);
            discardDeck.addCard(drawDeckTopCard);
        }

        public void startGame()
        {    
            Console.WriteLine("Starting Game...");

            addValidInitialCardToDiscardDeck();

            playGame();
        }

        public void playGame()
        {
            Player currentPlayer;

            do
            {
                int currentPlayerIndex = turn.CurrentPlayerIndex;
                currentPlayer = turn.Players[turn.CurrentPlayerIndex];

                setUpPlayerToTakeTheirTurn(currentPlayer);

                playerTakesTheirTurn(currentPlayer);

                pauseForNextPlayer();
            }
            while (isWinner() == false);

        }

        private void pauseForNextPlayer()
        {
            Console.Clear();
            Console.WriteLine("Press enter to go to the next players turn.");
            Console.ReadLine();
        }
        private void setUpPlayerToTakeTheirTurn(Player currentPlayer)
        {
            Console.WriteLine();
            Console.WriteLine(currentPlayer.Name + "'s turn.");
            discardDeck.displayTopCard();
            Console.WriteLine("Your hand is: ");

            currentPlayer.lookAtHand();
        }
        private void playerTakesTheirTurn(Player currentPlayer)
        {
            bool isPlayerActionCompleted = false;

            do
            {
                string[] action = currentPlayer.pickAction();
                isPlayerActionCompleted = performPlayerAction(action);

            } while (isPlayerActionCompleted == false);

        }
        private void addValidInitialCardToDiscardDeck()
        {
            Console.WriteLine("Putting the draw deck top card on the discard deck...");
            moveCardFromDrawDeckToDiscardDeck();

            makeFirstCardOnDiscardDeckValid();

            discardDeck.displayTopCard();

            playDiscardDeckTopCard();
        }

        private void playDiscardDeckTopCard()
        {
            BasicCard discardDeckTopCard = discardDeck.CardDeck[discardDeck.topCardIndex()];

            if (discardDeckTopCard.CardWithNoActions == false)
            {
                Console.WriteLine("This card plays when it is turned up at the beginning of the game.");
                Console.WriteLine("Playing card...");

                discardDeckTopCard.playCard();
            }

        }

        private void makeFirstCardOnDiscardDeckValid()
        {

            int discardDeckTopCardIndex = discardDeck.topCardIndex();
            BasicCard discardDeckTopCard = discardDeck.CardDeck[discardDeckTopCardIndex];

            while (discardDeckTopCard.Type == CardType.WildDrawFour)
            {
                discardDeck.removeCard(discardDeckTopCardIndex);
                drawDeck.addCardRandomlyToDeck(discardDeckTopCard);
                moveCardFromDrawDeckToDiscardDeck();
            }
        }

        private bool performPlayerAction(string[] playerAction)
        {
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];
            bool isInt = int.TryParse(playerAction[0], out int cardPlayedIndex);
            bool isPlayerActionEnum = Enum.TryParse<PlayerAction>(playerAction[0], out PlayerAction action);
            bool playerActionCompleted = false;

            if (isInt && currentPlayer.isCardInHand(cardPlayedIndex))
            {
                currentPlayer.playCard(cardPlayedIndex);
                playerActionCompleted = true;

            }else if (isPlayerActionEnum)
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
                        playerActionCompleted = playerActionSayUno(playerAction);
                        break;
                    case PlayerAction.Confront:
                        playerActionCompleted = confrontOtherPlayer(playerAction);
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

        private bool playerActionSayUno(string[] playerAction)
        {
            bool isPlayComplete = false;
            int cardIndex;
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];

            if (playerAction.Length > 1)
            {
                bool isInt = int.TryParse(playerAction[1], out cardIndex);

                if (isInt && currentPlayer.isCardInHand(cardIndex))
                {                    
                    currentPlayer.sayUno();
                    isPlayComplete = currentPlayer.playCard(cardIndex);
                }
                else
                {
                    UnoErrorMessage();
                }

            }
            else
            {
                UnoErrorMessage();
            }


            return isPlayComplete;
        }
        private void possibleConfrontActions()
        {
            foreach (string possibleAction in Enum.GetNames(typeof(PlayerActionConfront)))
            {
                Console.WriteLine(PlayerAction.Confront.ToString() + " " +  possibleAction);
            }
        }

        private void UnoErrorMessage() 
        {
            Console.WriteLine("The action 'Uno' needs the number of the card you want to play after it.");
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
            int cardDrawnIndex = drawDeck.topCardIndex();
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
            int cardDrawnIndex = drawDeck.topCardIndex();
            BasicCard cardDrawn = drawDeck.CardDeck[cardDrawnIndex];

            drawDeck.removeCard(cardDrawnIndex, discardDeck);
            playerToDraw.putCardInHand(cardDrawn);
        }

        private bool confrontOtherPlayer(string[] playerAction)
        {
            bool playerActionCompleted = false;

            if (playerAction.Length > 1)
            {
                string playerActionSecondPart = playerAction[1];

                bool enumConverted = Enum.TryParse<PlayerAction>(playerActionSecondPart, out PlayerAction action);
                if (enumConverted)
                {
                    if (action == PlayerAction.Uno)
                    {
                        didPlayerSayUno();
                        playerActionCompleted = true;
                    }
                    else
                    {
                        Console.WriteLine(playerActionSecondPart + " is not a valid confront action.");
                    }
                }
                else
                {
                    Console.WriteLine("The action 'Confront' needs a second word. Possible Confront actions are:");
                    possibleConfrontActions();
                }
            }

            return playerActionCompleted;
        }

        private void didPlayerSayUno()
        {
            int currentPlayerIndex = turn.CurrentPlayerIndex;
            Player currentPlayer = turn.Players[currentPlayerIndex];
            int playerPickedIndex;

            playerPickedIndex = turn.pickAPlayer();
            Player playerPicked = turn.Players[playerPickedIndex];

            if(playerPicked.numCardsInHand() == 1 && playerPicked.SaidUno == false)
            {
                penaltyForNotSayingUno(playerPickedIndex);
            }
            else
            {
                Console.WriteLine(playerPicked.Name + " Said Uno or did not have only one card in their hand.");
            }
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

        private bool isWinner()
        {
            List<Player> players = turn.Players;
            bool isWinner = false;

            for(int i = 0; i < players.Count; i++)
            {
                if(players[i].numCardsInHand() <= 0)
                {
                    isWinner = true;
                    Console.WriteLine(players[i].Name + " won!");
                }
            }

            if(isWinner == false)
            {
                playGame();
            }

            return isWinner;
            
        }
    }
}
