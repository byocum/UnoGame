using System;
using UnoGame.Players;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using UnoGame.Factories;

namespace UnoGame.PlayerActions
{
    public class SayUno:PlayerAction
    {
        private PlayerAction playCard;
        private PlayerAction draw;
        public SayUno(Turn turn, PlayerAction playCard, PlayerAction draw)
        {
            TurnOrder = turn;
            this.playCard = playCard;
            this.draw = draw;
        }
        public override bool performAction()
        {
            return playerSaysUno();
        }
        private bool playerSaysUno()
        {

            bool readyForNextPlayersTurn = false;
            string[] playerAction;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            if (currentPlayer.SaidUno == false)
            {
                if (currentPlayer.sayUno())
                {
                    do
                    {
                        Console.WriteLine("Please pick a card to play or draw a card.");
                        playerAction = currentPlayer.pickAction();
                        readyForNextPlayersTurn = playerPlayOrDrawACardAfterSayingUno(playerAction);
                    } while (readyForNextPlayersTurn == false);

                }
            }
            else
            {
                Console.WriteLine("You already said Uno.");
            }

            return readyForNextPlayersTurn;
        }

        private bool playerPlayOrDrawACardAfterSayingUno(string[] playerAction)
        {
            bool readyForNextPlayersTurn = false;
            bool isPlayerInputInt = int.TryParse(playerAction[0], out int cardToPlayIndex);
            bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerAction[0], out PlayerActionEnum action);

            if (isPlayerInputInt)
            {
                readyForNextPlayersTurn = playCard.performAction(cardToPlayIndex);
            }
            else if (isPlayerActionEnum)
            {
                if(action == PlayerActionEnum.Draw)
                {
                    readyForNextPlayersTurn = draw.performAction(TurnOrder.CurrentPlayerIndex);
                }
            }

            return readyForNextPlayersTurn;
        }
    }
}
