﻿using System;
using UnoGame.Players;
using UnoGame.Enums;

namespace UnoGame.Intermediaries
{
    class InterperatePlayerInput
    {
        private readonly Turn turn;
        private readonly PerformAction performAction;

        public InterperatePlayerInput(PerformAction performAction, Turn turn)
        {
            this.turn = turn;
            this.performAction = performAction; 
        }

        public bool PerformPlayerAction(string[] playerInput)
        {
            bool playerActionCompleted;
            bool isPlayerInputInt = int.TryParse(playerInput[0], out int cardInputNum);
            bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerInput[0], out PlayerActionEnum action);

            if (isPlayerInputInt)
            {
                int cardToPlayIndex = cardInputNum - 1;
                playerActionCompleted = performAction.PlayCard(cardToPlayIndex);
            }
            else if (isPlayerActionEnum && action == PlayerActionEnum.Call)
            {
                if (playerInput.Length > 1)
                {
                    bool isPlayerActionConfrontEnum = Enum.TryParse<PlayerActionCall>(playerInput[1], out PlayerActionCall confrontAction);
                    if (isPlayerActionConfrontEnum && confrontAction == PlayerActionCall.Uno)
                    {
                        int playerPickedIndex = turn.PickAPlayer();
                        Player playerPicked = turn.Players[playerPickedIndex];

                        playerActionCompleted = performAction.ConfrontUno(playerPicked);
                    }
                    else
                    {
                        ConfrontActionErrorMessage();
                        playerActionCompleted = false;
                    }
                }
                else
                {
                    ConfrontActionErrorMessage();
                    playerActionCompleted = false;
                }
            }
            else if (isPlayerActionEnum)
            {
                playerActionCompleted = SelectPlayerAction(action);
            }
            else
            {
                playerActionCompleted = performAction.NoAction();
            }

            return playerActionCompleted;
        }

        private bool SelectPlayerAction(PlayerActionEnum action)
        {
            bool playerActionCompleted;

            switch (action)
            {
                case PlayerActionEnum.Rules:
                    playerActionCompleted = performAction.Rules();
                    break;
                case PlayerActionEnum.Draw:
                    playerActionCompleted = performAction.Draw();
                    break;
                case PlayerActionEnum.Uno:
                    playerActionCompleted = performAction.SayUno();
                    if (playerActionCompleted == true)
                    {
                        PickCardAfterSayingUno();
                    }
                    break;
                case PlayerActionEnum.Sort:
                    playerActionCompleted = performAction.Sort();
                    break;
                case PlayerActionEnum.Hands:
                    playerActionCompleted = performAction.Hands();
                    break;
                default:
                    ActionErrorMessage();
                    playerActionCompleted = performAction.NoAction();
                    break;
            }

            return playerActionCompleted;
        }

        private void ActionErrorMessage()
        {
            Console.WriteLine("That is not a possible action.  Possible actions are: ");
            foreach (string possibleAction in Enum.GetNames(typeof(PlayerActionEnum)))
            {
                Console.WriteLine(possibleAction);
            }

            Console.WriteLine("or the number of the card you would like to play.");
        }

        private void ConfrontActionErrorMessage()
        {
            Console.WriteLine("The word Confront needs to be followed by a confront action. Possible confront actions are: ");

            foreach (string possibleAction in Enum.GetNames(typeof(PlayerActionCall)))
            {
                if (possibleAction != PlayerActionCall.NoAction.ToString())
                    Console.WriteLine(possibleAction);
            }
        }

        private void PickCardAfterSayingUno()
        {
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];
            bool readyForNextPlayersTurn;

            do
            {
                Console.WriteLine("Please pick a card to play or draw a card.");
                string [] playerAction = currentPlayer.PickAction();
                readyForNextPlayersTurn = PlayerPlayOrDrawACardAfterSayingUno(playerAction);
            } while (readyForNextPlayersTurn == false);
        }

        private bool PlayerPlayOrDrawACardAfterSayingUno(string[] playerAction)
        {
            bool readyForNextPlayersTurn = false;
            bool isPlayerInputInt = int.TryParse(playerAction[0], out int playerInputNum);
            bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerAction[0], out PlayerActionEnum action);
            int cardToPlayIndex = playerInputNum - 1;

            if (isPlayerInputInt)
            {
                readyForNextPlayersTurn = performAction.PlayCard(cardToPlayIndex);
            }
            else if (isPlayerActionEnum)
            {
                if (action == PlayerActionEnum.Draw)
                {
                    readyForNextPlayersTurn = performAction.Draw();
                }
            }

            return readyForNextPlayersTurn;
        }
    }
}
