using System;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Enums;
using UnoGame.Cards;

namespace UnoGame.GameActions
{
    public abstract class GameAction
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
        
        public virtual bool PerformAction()
        {
            return false;
        }

        protected bool PlayerEnterYesOrNo()
        {
            string playCardDrawn;
            bool isYes;
            bool isNo;

            do
            {
                playCardDrawn = PromptPlayerInputYesOrNo();

                if (string.IsNullOrEmpty(playCardDrawn))
                {
                    isYes = false;
                    isNo = false;
                }
                else if (playCardDrawn[0] == 'y')
                {
                    isYes = true;
                    isNo = false;
                }
                else if (playCardDrawn[0] == 'n')
                {
                    isYes = false;
                    isNo = true;
                }
                else
                {
                    isYes = false;
                    isNo = false;
                }

            } while (isYes == false && isNo == false);
          

            return isYes;
        }

        protected string PromptPlayerInputYesOrNo()
        {
            Console.WriteLine("Enter \"y\" for yes or \"n\" for no.");


            return Console.ReadLine().Trim().ToLower();
        }

    }
}
