using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using UnoGame.PlayerActions;

namespace UnoGame.Factories
{
    //This class may not be needed.
    //public class MediatorActionFactory:IActionFactory
    //{
//        DrawDeck drawDeck;
//        DiscardDeck discardDeck;
//        Turn turnOrder;
//        public MediatorActionFactory(DrawDeck drawDeck, DiscardDeck discardDeck, Turn turnOrder)
//        {
//            this.drawDeck = drawDeck;
//            this.discardDeck = discardDeck;
//            this.turnOrder = turnOrder;
//        }

//        public PlayerAction createPlayCardAction(Deck deckToPlayFrom)
//        {
//            PlayerAction action;

//            action = new PlayCard(deckToPlayFrom, discardDeck, turnOrder);

//            return action;
//        }

//        public PlayerAction createMediatorAction(MediatorActionEnum action)
//        {
//            PlayerAction playerAction;

//            switch (action)
//            {
//                case MediatorActionEnum.Rules:
//                    playerAction = new Rules(drawDeck, discardDeck, turnOrder);
//                    break;
//                case MediatorActionEnum.DeterminePlayers:
//                    playerAction = new DeterminePlayers(drawDeck, discardDeck, turnOrder);
//                    break;
//                case MediatorActionEnum.Deal:
//                    playerAction = new Deal(drawDeck, discardDeck, turnOrder);
//                    break;
//                case MediatorActionEnum.PenaltyDraw:
//                    playerAction = new PenaltyDraw(drawDeck, discardDeck, turnOrder);
//                    break;
//                default:
//                    playerAction = new NoAction();
//                    break;                    
//            }
//            return playerAction;
//        }

//        private void actionErrorMessage()
//        {//Is this appropriate for the mediator as the players will not have control over this.
//            Console.WriteLine("That is not a possible action.  Possible actions are: ");
//            foreach (string possibleAction in Enum.GetNames(typeof(MediatorActionEnum)))
//            {
//                Console.WriteLine(possibleAction);
//            }

//            Console.WriteLine("or the number of the card you would like to play.");
//        }
   // }
}
