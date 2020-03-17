using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Factories;
using UnoGame.PlayerActions;
using UnoGame.Players;
using UnoGame.Decks;

namespace UnoGame.PlayerActions
{
    public class PerformAction
    {
        private readonly ActionFactory actionFactory;

        public PerformAction(ActionFactory actionFactory) 
        {
            this.actionFactory = actionFactory;
        }

        public bool ConfrontUno(Player playerPicked)
        {
            PlayerAction confrontUno = actionFactory.ConfrontUno(playerPicked);
            return confrontUno.PerformAction();
        }

        public bool Deal()
        {
            PlayerAction deal = actionFactory.Deal();
            return deal.PerformAction();
        }

        public bool DeterminePlayers()
        {
            PlayerAction determinePlayers = actionFactory.DeterminePlayers();
            return determinePlayers.PerformAction();
        }

        public bool DiscardDeckAddFirstCard()
        {
            PlayerAction discardDeckAddFirstCard = actionFactory.DiscardDeckAddFirstCard();
            return discardDeckAddFirstCard.PerformAction();
        }

        public bool Draw()
        {
            PlayerAction draw = actionFactory.Draw();
            return draw.PerformAction();
        }

        public bool NoAction()
        {
            PlayerAction noAction = actionFactory.NoAction();
            return noAction.PerformAction();
        }

        public bool Pause()
        {
            PlayerAction pause = actionFactory.Pause();
            return pause.PerformAction();
        }

        public bool PenaltyDraw(Player playerPicked)
        {
            PlayerAction penaltyDraw = actionFactory.PenaltyDraw(playerPicked);
            return penaltyDraw.PerformAction();
        }

        public bool PlayCard(int cardToPlayIndex)
        {
            PlayerAction playCard = actionFactory.PlayCard(cardToPlayIndex);
            return playCard.PerformAction();
        }

        public bool Rules()
        {
            PlayerAction rules = actionFactory.Rules();
            return rules.PerformAction();
        }

        public bool SayUno()
        {
            PlayerAction sayUno = actionFactory.SayUno();
            return sayUno.PerformAction();
        }
    }
}
