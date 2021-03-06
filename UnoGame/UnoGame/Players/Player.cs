﻿using System;
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

        public bool SaidUno
        {
            get { return saidUno; }
        }
        public Player(string name, DiscardDeck discardDeck)
        {
            this.name = Function.titleCase(name);
            this.hand = new PlayerHand();
            this.discardDeck = discardDeck;
            this.saidUno = false;
        }

        public void addCardToHand(BasicCard card)
        {
            hand.addCard(card);

            if(hand.CardDeck.Count > 1)
            {
                resetSaidUnoField();
            }
        }

        public bool playCard(int cardIndex)
        {
            bool isPlayComplete = false;
            BasicCard cardToBePlayed = hand.CardDeck[cardIndex];

            if (discardDeck.isCardPlayable(cardToBePlayed))
            {
                hand.removeCard(cardIndex);
                discardDeck.addCard(cardToBePlayed);
                cardToBePlayed.playCard();
                isPlayComplete = true;
            }
            else
            {
                Console.WriteLine(cardToBePlayed.lookAtCard() + " is not playable.");
            }

            return isPlayComplete;

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
                Console.WriteLine("The card you drew is playable.");
                Console.WriteLine("Would you like to play this card?");
      
                if (playerEnterYesOrNo())
                {
                    playCard(cardDrawn);
                    playedCard = true;
                }
                else
                {
                    putCardInHand(cardDrawn);
                }

            }
            else
            {
                putCardInHand(cardDrawn);
            }
            
            return playedCard;
        }

        private bool playerEnterYesOrNo()
        {
            string playCardDrawn;
            bool isYes = false;

            Console.WriteLine("Enter y for yes or another character for no");
            playCardDrawn = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(playCardDrawn))
            {
                isYes = false;
            }
            else if(playCardDrawn[0] == 'y')
            {
                isYes = true;
            }
            else
            {
                isYes = false;
            }

            return isYes;
        }

        public void putCardInHand(BasicCard cardDrawn)
        {
            addCardToHand(cardDrawn);
        }

        public string[] pickAction()
        {
            string playerAction;
            string[] playerActionParts;
            playerAction = playerEntryTitleCase();
            playerActionParts = playerAction.Split(' ');

            Console.WriteLine();
            
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

        public bool isCardInHand(int index)
        {
            return hand.isCardInDeck(index);
        }

        public bool sayUno()
        {
            bool didSayUno = false;

            if(hand.CardDeck.Count == 2 || hand.CardDeck.Count == 1)
            {
                saidUno = true;
                Console.WriteLine("You say Uno.");
                didSayUno = true;

            }
            else
            {
                Console.WriteLine("You can only say Uno if you have one or two cards in your hand and play one card.");
                Console.WriteLine("You currently have " + hand.CardDeck.Count + " cards in your hand.");
            }

            return didSayUno;
        }

        public void resetSaidUnoField()
        {
            saidUno = false;
        }
    }
}
