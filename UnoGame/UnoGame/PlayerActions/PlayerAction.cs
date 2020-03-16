using System;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;

namespace UnoGame.PlayerActions
{
    public abstract class PlayerAction
    {
        private Deck drawDeck;
        private Deck discardDeck;
        private Turn turnOrder;

        protected Deck DrawDeck
        {
            get { return drawDeck; }
            set { drawDeck = value; }
        }

        protected Deck DiscardDeck
        {
            get { return discardDeck; }
            set { discardDeck = value; }
        }

        protected Turn TurnOrder
        {
            get { return turnOrder; }
            set { turnOrder = value; }
        }
        
        public virtual bool performAction()
        {
            return false;
        }
        public virtual bool performAction(int index)
        {
            return false;
        }

        protected bool playerEnterYesOrNo()
        {
            string playCardDrawn;
            bool isYes = false;

            Console.WriteLine("Enter y for yes or another character for no");
            playCardDrawn = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(playCardDrawn))
            {
                isYes = false;
            }
            else if (playCardDrawn[0] == 'y')
            {
                isYes = true;
            }
            else
            {
                isYes = false;
            }

            return isYes;
        }

        protected bool isPlayerInputACardInDeck(int cardIndex, Deck deckToPlayFrom)
        {
            bool isCardInDeck = false;
            Player currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            if (currentPlayer.isCardInHand(cardIndex))
            {
                isCardInDeck = true;
            }

            return isCardInDeck;
        }
    }
}
