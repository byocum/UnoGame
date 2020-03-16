using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Players;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Factories;
using UnoGame.Enums;
using UnoGame.PlayerActions;

namespace UnoGame.PlayerActions
{
    public class PerformMediatorActions
    {
        private readonly Turn turn;
        private readonly Deck drawDeck;
        private readonly Deck discardDeck;

        public PerformMediatorActions(Deck drawDeck, Deck discardDeck, Turn turn)
        {
            this.turn = turn;
            this.drawDeck = drawDeck;
            this.discardDeck = discardDeck;
        }

        public void ShowRules()
        {
            PlayerAction showRules = new Rules();
            showRules.PerformAction();
        }

        public void DeterminePlayers()
        {
            PlayerAction determinePlayers = new DeterminePlayers(turn, discardDeck);
            determinePlayers.PerformAction();
        }

        public void Deal()
        {
            PlayerAction deal = new Deal(drawDeck, discardDeck, turn);
            deal.PerformAction();
        }

        public void PenaltyDraw(int playerThatGetsPenaltyIndex)
        {
            PlayerAction penaltydraw = new PenaltyDraw(drawDeck, discardDeck, turn);
            penaltydraw.PerformAction(playerThatGetsPenaltyIndex);
        }

        public void DiscardDeckAddFirstCard()
        {
            PlayerAction discardDeckAddFirstCard = new DiscardDeckAddFirstCard(drawDeck, discardDeck);
            discardDeckAddFirstCard.PerformAction();
        }
    }
}
