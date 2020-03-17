using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;
using UnoGame.Cards;

namespace UnoGame.PlayerActions
{
    public class PlayerPlayingCard : PlayerAction
    {
        private readonly int cardToPlayIndex;

        public PlayerPlayingCard(int cardToPlayIndex, Deck discardDeck, Turn turnOrder)
        {
            DiscardDeck = discardDeck;
            this.cardToPlayIndex = cardToPlayIndex;
            TurnOrder = turnOrder;
        }
        public override bool PerformAction()
        {
            bool actionCompleted = false;

            if (IsPlayerInputACardInDeck())
            {
                actionCompleted = Play();

            }
            else
            {
                Console.WriteLine("That card does not exist.");
            }

            return actionCompleted;
        }

        protected bool IsPlayerInputACardInDeck()
        {
            bool isCardInDeck = false;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            if (currentPlayer.IsCardInHand(cardToPlayIndex))
            {
                isCardInDeck = true;
            }

            return isCardInDeck;
        }

        public bool Play()
        {
            bool isPlayComplete = false;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];
            BasicCard cardToBePlayed = currentPlayer.Hand.CardDeck[cardToPlayIndex];

            if (DiscardDeck.isCardPlayable(cardToBePlayed))
            {
                currentPlayer.Hand.removeCard(cardToPlayIndex);
                DiscardDeck.addCard(cardToBePlayed);
                cardToBePlayed.playCard();
                isPlayComplete = true;
            }
            else
            {
                Console.WriteLine(cardToBePlayed.lookAtCard() + " is not playable.");
            }

            return isPlayComplete;

        }
    }
}
