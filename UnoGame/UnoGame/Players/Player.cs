using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Functions;

namespace UnoGame.Players
{
    public class Player
    {
        private string name;
        private Deck hand;
        private Deck discardDeck;
        private bool saidUno;

        public string Name
        {
            get { return name; }
        }

        public bool SaidUno
        {
            get { return saidUno; }
        }

        public Deck Hand
        {
            get { return hand; }
        }
        public Player(string name, Deck discardDeck)
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

        public void playCard(BasicCard cardToBePlayed)
        {
            discardDeck.addCard(cardToBePlayed);
            cardToBePlayed.playCard();
        }

        public int numCardsInHand()
        {
            return hand.CardDeck.Count;
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
