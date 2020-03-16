using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Functions;

namespace UnoGame.Players
{
    public class Player
    {
        private readonly string name;
        private readonly Deck hand;
        private readonly Deck discardDeck;
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

        public void AddCardToHand(BasicCard card)
        {
            hand.addCard(card);

            if(hand.CardDeck.Count > 1)
            {
                ResetSaidUnoField();
            }
        }

        public void PlayCard(BasicCard cardToBePlayed)
        {
            discardDeck.addCard(cardToBePlayed);
            cardToBePlayed.playCard();
        }

        public int NumCardsInHand()
        {
            return hand.CardDeck.Count;
        }

        public string[] PickAction()
        {
            string playerAction;
            string[] playerActionParts;
            playerAction = PlayerEntryTitleCase();
            playerActionParts = playerAction.Split(' ');

            Console.WriteLine();
            
            return playerActionParts;
        }

        public string PlayerEntryTitleCase()
        {
            string playerAction;
            playerAction = Console.ReadLine().Trim().ToLower();
            playerAction = Function.titleCase(playerAction);
            return playerAction;
        }

        public void LookAtHand()
        {
            hand.lookAtDeck();
        }

        public bool IsCardInHand(int index)
        {
            return hand.isCardInDeck(index);
        }

        public bool SayUno()
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

        public void ResetSaidUnoField()
        {
            saidUno = false;
        }
    }
}
