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
        private readonly Turn turn;
        private readonly PlayerActionFactory playerActionFactory;

        public PerformPlayerActions(PlayerActionFactory playerActionFactory, Turn turn )
        {
            this.turn = turn;
            this.playerActionFactory = playerActionFactory; 
        }

        public bool PerformPlayerAction(string[] playerInput)
        {            
            bool playerActionCompleted;
            Player currentPlayer = turn.Players[turn.CurrentPlayerIndex];
            bool isPlayerInputInt = int.TryParse(playerInput[0], out int cardToPlayIndex);
            bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerInput[0], out PlayerActionEnum action);

            if (isPlayerInputInt)
            {
                PlayerAction playCard = playerActionFactory.createPlayCardAction(currentPlayer.Hand);
                playerActionCompleted = playCard.PerformAction(cardToPlayIndex);
            }
            else if(playerInput.Length > 1 && isPlayerActionEnum)
            {
                bool isPlayerActionConfrontEnum = Enum.TryParse<PlayerActionConfront>(playerInput[1], out PlayerActionConfront confrontAction);
                if (isPlayerActionConfrontEnum)
                {
                    PlayerAction playerAction = playerActionFactory.createPlayerAction(action, confrontAction);
                    playerActionCompleted = playerAction.PerformAction();
                }
                else
                {
                    playerActionCompleted = false;
                } 
            }
            else if (isPlayerActionEnum)
            {
                PlayerAction playerAction = playerActionFactory.createPlayerAction(action, PlayerActionConfront.NoAction);
                playerActionCompleted = playerAction.PerformAction();
            }
            else
            {
                PlayerAction playerAction = playerActionFactory.createPlayerAction(PlayerActionEnum.NoAction, PlayerActionConfront.NoAction);
                playerActionCompleted = playerAction.PerformAction();
            }

            return playerActionCompleted;
        }
    }
}
