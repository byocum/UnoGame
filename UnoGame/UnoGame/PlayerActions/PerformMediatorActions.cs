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
        private Turn turn;
        private Deck drawDeck;
        private Deck discardDeck;

        public PerformMediatorActions(Deck drawDeck, Deck discardDeck, Turn turn)
        {
            this.turn = turn;
            this.drawDeck = drawDeck;
            this.discardDeck = discardDeck;
        }

        //public void playCard(int cardIndex, Deck deckToPlayFrom)
        //{
        //    PlayerAction playCard = new PlayCard(deckToPlayFrom, discardDeck);
        //    playCard.performAction(cardIndex);
        //}
        public void showRules()
        {
            PlayerAction showRules = new Rules();
            showRules.performAction();
        }

        public void determinePlayers()
        {
            PlayerAction determinePlayers = new DeterminePlayers(turn, discardDeck);
            determinePlayers.performAction();
        }

        public void deal()
        {
            PlayerAction deal = new Deal(drawDeck, discardDeck, turn);
            deal.performAction();
        }

        public void penaltyDraw(int playerThatGetsPenaltyIndex)
        {
            PlayerAction penaltydraw = new PenaltyDraw(drawDeck, discardDeck, turn);
            penaltydraw.performAction(playerThatGetsPenaltyIndex);
        }

        public void discardDeckAddFirstCard()
        {
            PlayerAction discardDeckAddFirstCard = new DiscardDeckAddFirstCard(drawDeck, discardDeck);
            discardDeckAddFirstCard.performAction();
        }
    }
}
