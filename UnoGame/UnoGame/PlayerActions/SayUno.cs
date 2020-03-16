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
        private readonly PlayerAction playCard;
        private readonly PlayerAction draw;
        public SayUno(Turn turn, PlayerAction playCard, PlayerAction draw)
        {
            TurnOrder = turn;
            this.playCard = playCard;
            this.draw = draw;
        }
        public override bool PerformAction()
        {
            return PlayerSaysUno();
        }
        private bool PlayerSaysUno()
        {

            bool readyForNextPlayersTurn = false;
            string[] playerAction;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            if (currentPlayer.SaidUno == false)
            {
                if (currentPlayer.SayUno())
                {
                    do
                    {
                        Console.WriteLine("Please pick a card to play or draw a card.");
                        playerAction = currentPlayer.PickAction();
                        readyForNextPlayersTurn = PlayerPlayOrDrawACardAfterSayingUno(playerAction);
                    } while (readyForNextPlayersTurn == false);

                }
            }
            else
            {
                Console.WriteLine("You already said Uno.");
            }

            return readyForNextPlayersTurn;
        }

        private bool PlayerPlayOrDrawACardAfterSayingUno(string[] playerAction)
        {
            bool readyForNextPlayersTurn = false;
            bool isPlayerInputInt = int.TryParse(playerAction[0], out int cardToPlayIndex);
            bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerAction[0], out PlayerActionEnum action);

            if (isPlayerInputInt)
            {
                readyForNextPlayersTurn = playCard.PerformAction(cardToPlayIndex);
            }
            else if (isPlayerActionEnum)
            {
                if(action == PlayerActionEnum.Draw)
                {
                    readyForNextPlayersTurn = draw.PerformAction(TurnOrder.CurrentPlayerIndex);
                }
            }

            return readyForNextPlayersTurn;
        }
    }
}
