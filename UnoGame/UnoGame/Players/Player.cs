using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Decks;

namespace UnoGame.Players
{
    public class Player
    {
        private string name;
        private PlayerHand hand;
        private DiscardDeck discardDeck;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Player(PlayerHand hand, DiscardDeck discardDeck)
        {
            this.hand = hand;
            this.discardDeck = discardDeck;
        }

        public void addCardToHand(BasicCard card)
        {
            hand.addCard(card);
        }
        public void playCard(int cardIndex)
        {
            BasicCard cardToBePlayed = hand.CardDeck[cardIndex];

            if (discardDeck.isCardPlayable(cardToBePlayed))
            {
                hand.removeCard(cardIndex);
                discardDeck.addCard(cardToBePlayed);
                cardToBePlayed.playCard();
            }
        }
    }
}
