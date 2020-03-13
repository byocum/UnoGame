using System;
using UnoGame.Factories;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;
using UnoGame.Enums;

namespace UnoGame.PlayerActions
{
    public class PerformPlayerActions
    {
        private Turn turn;
        PlayerActionFactory playerActionFactory;

        public PerformPlayerActions(PlayerActionFactory playerActionFactory, Turn turn )
        {
            this.turn = turn;
            this.playerActionFactory = playerActionFactory; 
        }

        public bool performPlayerAction(string[] playerInput)
        {            
            bool playerActionCompleted = false;
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];
            bool isPlayerActionConfrontEnum = false;
            PlayerActionConfront confrontAction;
            bool isPlayerInputInt = int.TryParse(playerInput[0], out int cardToPlayIndex);
            bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerInput[0], out PlayerActionEnum action);

            if (isPlayerInputInt)
            {
                PlayerAction playCard = playerActionFactory.createPlayCardAction(currentPlayer.Hand);
                playerActionCompleted = playCard.performAction(cardToPlayIndex);
            }
            else if(playerInput.Length > 1 && isPlayerActionEnum && isPlayerActionConfrontEnum)
            {
                isPlayerActionConfrontEnum = Enum.TryParse<PlayerActionConfront>(playerInput[1], out confrontAction);
                PlayerAction playerAction = playerActionFactory.createPlayerAction(action, confrontAction);
                playerActionCompleted = playerAction.performAction();
            }
            else if (isPlayerActionEnum)
            {
                PlayerAction playerAction = playerActionFactory.createPlayerAction(action, PlayerActionConfront.NoAction);
                playerActionCompleted = playerAction.performAction();
            }
            else
            {
                PlayerAction playerAction = playerActionFactory.createPlayerAction(PlayerActionEnum.NoAction, PlayerActionConfront.NoAction);
                playerActionCompleted = playerAction.performAction();
            }

            return playerActionCompleted;
        }
    }
}
