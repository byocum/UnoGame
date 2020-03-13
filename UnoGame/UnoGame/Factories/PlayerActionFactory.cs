using UnoGame.PlayerActions;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using System;

namespace UnoGame.Factories
{
    public class PlayerActionFactory:IActionFactory
    {
        private DrawDeck drawDeck;
        private DiscardDeck discardDeck;
        private Turn turnOrder;

        public PlayerActionFactory(DrawDeck drawDeck, DiscardDeck discardDeck, Turn turnOrder)
        {
            this.drawDeck = drawDeck;
            this.discardDeck = discardDeck;
            this.turnOrder = turnOrder;
        }

        public PlayerAction createPlayCardAction(Deck deckToPlayFrom)
        {
            PlayerAction action;

            action = new PlayCard(deckToPlayFrom, discardDeck, turnOrder);

            return action;
        }

        public PlayerAction createPlayerAction (PlayerActionEnum action, PlayerActionConfront confrontAction)
        {
            PlayerAction playerAction;

            switch (action)
            {
                case PlayerActionEnum.Rules:
                    playerAction = new Rules();
                    break;
                case PlayerActionEnum.Draw:
                    playerAction = new Draw(drawDeck, discardDeck, turnOrder);
                    break;
                case PlayerActionEnum.Uno:
                    Deck currentPlayerHand = turnOrder.Players[turnOrder.CurrentPlayerIndex].Hand;
                    PlayerAction playCard = new PlayCard(currentPlayerHand, discardDeck, turnOrder);
                    PlayerAction draw = new Draw(drawDeck, discardDeck, turnOrder);
                    playerAction = new SayUno(turnOrder, playCard, draw);
                    break;
                case PlayerActionEnum.Confront:
                    if(confrontAction == PlayerActionConfront.Uno)
                    {
                        PlayerAction penaltyDraw = new PenaltyDraw(drawDeck, discardDeck, turnOrder);
                        playerAction = new ConfrontUno(turnOrder, penaltyDraw);
                    }
                    else
                    {
                        confrontActionErrorMessage();
                        playerAction = new NoAction();
                    }
                    
                    break;
                default:
                    actionErrorMessage();
                    playerAction = new NoAction();
                    break;
            }

            return playerAction;
        }

        private void actionErrorMessage()
        {//ToDo: Fix this the list is going to break in the new structure.  Maybe is needs to be changed into player actions
            //and mediator actions...although rules can be both.
            Console.WriteLine("That is not a possible action.  Possible actions are: ");
            foreach (string possibleAction in Enum.GetNames(typeof(PlayerActionEnum)))
            {
                Console.WriteLine(possibleAction);
            }

            Console.WriteLine("or the number of the card you would like to play.");
        }

        private void confrontActionErrorMessage()
        {
            Console.WriteLine("The word Confront needs to be followed by a confront action. Possible confront actions are: ");

            foreach (string possibleAction in Enum.GetNames(typeof(PlayerActionConfront)))
            {
                if(possibleAction != PlayerActionConfront.NoAction.ToString())
                Console.WriteLine(possibleAction);
            }
        }
    }
}
