using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;
using UnoGame.Cards;

namespace UnoGame.PlayerActions
{
    public class PlayCard : PlayerAction
    {
        Deck deckToPlayFrom;
        public PlayCard(Deck deckToPlayFrom, DiscardDeck discardDeck, Turn turn)
        {
            this.deckToPlayFrom = deckToPlayFrom;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }
        public override bool performAction(int index)
        {
            bool actionCompleted = false;

            if (isPlayerInputACardInDeck(index, deckToPlayFrom))
            {
                actionCompleted = playCard(index);

            }
            else
            {
                Console.WriteLine("That card does not exist.");
            }

            return actionCompleted;
        }

        public bool playCard(int cardIndex)
        {
            bool isPlayComplete = false;
            BasicCard cardToBePlayed = deckToPlayFrom.CardDeck[cardIndex];

            if (DiscardDeck.isCardPlayable(cardToBePlayed))
            {
                deckToPlayFrom.removeCard(cardIndex);
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
