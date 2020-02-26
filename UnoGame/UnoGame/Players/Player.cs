using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Functions;

namespace UnoGame.Players
{
    public class Player
    {
        private string name;
        private PlayerHand hand;
        private DiscardDeck discardDeck;
        private bool saidUno;

        public string Name
        {
            get { return name; }
        }

        public Player(string name, DiscardDeck discardDeck)
        {
            this.name = name;
            this.hand = new PlayerHand();
            this.discardDeck = discardDeck;
            this.saidUno = false;
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
            else
            {
                Console.WriteLine(cardToBePlayed.lookAtCard() + " is not playable.");
            }
        }

        private void playCard(BasicCard cardToBePlayed)
        {
            discardDeck.addCard(cardToBePlayed);
            cardToBePlayed.playCard();
        }

        public int numCardsInHand()
        {
            return hand.CardDeck.Count;
        }

        public bool playDrawnCard(BasicCard cardDrawn)
        {
            bool playedCard = false;

            Console.WriteLine("You drew a " + cardDrawn.lookAtCard() + ".");

            if (discardDeck.isCardPlayable(cardDrawn))
            {
                string playCardDrawn;

                Console.WriteLine("The card you drew is playable.");
                Console.WriteLine("Would you like to play this card?");
                Console.WriteLine("Enter y for yes or another character for no");
                playCardDrawn = Console.ReadLine().Trim().ToLower();
                if (playCardDrawn[0] == 'y')
                {
                    playCard(cardDrawn);
                    playedCard = true;
                }
                else
                {
                    addCardToHand(cardDrawn);
                }

            }
            else
            {
                addCardToHand(cardDrawn);
            }
            
            return playedCard;
        }

        public string[] pickAction()
        {
            string playerAction;
            string[] playerActionParts;
            Console.WriteLine("What would you like to do?");
            playerAction = playerEntryTitleCase();
            playerActionParts = playerAction.Split(',');
            
            return playerActionParts;
        }

        public string playerEntryTitleCase()
        {
            string playerAction;
            playerAction = Console.ReadLine().Trim().ToLower();
            playerAction = Function.titleCase(playerAction);
            return playerAction;
        }

        public void lookAtHand()
        {
            hand.lookAtDeck();
        }
    }
}
