using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Factories;
using UnoGame.GameActions;
using UnoGame.Players;
using UnoGame.Decks;

namespace UnoGame.Intermediaries
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
            GameAction confrontUno = actionFactory.ConfrontUno(playerPicked);
            return confrontUno.PerformAction();
        }

        public bool Deal()
        {
            GameAction deal = actionFactory.Deal();
            return deal.PerformAction();
        }

        public bool DeterminePlayers()
        {
            GameAction determinePlayers = actionFactory.DeterminePlayers();
            return determinePlayers.PerformAction();
        }

        public bool DiscardDeckAddFirstCard()
        {
            GameAction discardDeckAddFirstCard = actionFactory.DiscardDeckAddFirstCard();
            return discardDeckAddFirstCard.PerformAction();
        }

        public bool Draw()
        {
            GameAction draw = actionFactory.Draw();
            return draw.PerformAction();
        }

        public bool NoAction()
        {
            GameAction noAction = actionFactory.NoAction();
            return noAction.PerformAction();
        }

        public bool Pause()
        {
            GameAction pause = actionFactory.Pause();
            return pause.PerformAction();
        }

        public bool PenaltyDraw(Player playerPicked)
        {
            GameAction penaltyDraw = actionFactory.PenaltyDraw(playerPicked);
            return penaltyDraw.PerformAction();
        }

        public bool PlayCard(int cardToPlayIndex)
        {
            GameAction playCard = actionFactory.PlayCard(cardToPlayIndex);
            return playCard.PerformAction();
        }

        public bool Rules()
        {
            GameAction rules = actionFactory.Rules();
            return rules.PerformAction();
        }

        public bool SayUno()
        {
            GameAction sayUno = actionFactory.SayUno();
            return sayUno.PerformAction();
        }

        public bool Sort()
        {
            GameAction sort = actionFactory.Sort();
            return sort.PerformAction();
        }
    }
}
