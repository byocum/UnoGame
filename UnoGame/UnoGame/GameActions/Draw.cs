using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Intermediaries;
using UnoGame.Players;
using UnoGame.Enums;

namespace UnoGame.GameActions
{
    class Draw : GameAction
    {
        Player currentPlayer;
        GameAction sayUno;

        public Draw(Deck drawDeck, Deck discardDeck, Turn turn, GameAction sayUno)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
            this.sayUno = sayUno;
        }

        public override bool PerformAction()
        {
            this.currentPlayer = TurnOrder.Players[TurnOrder.CurrentPlayerIndex];

            DrawAndPlayCard();
            return true;
        }

        private void DrawAndPlayCard()
        {
            int cardDrawnIndex = DrawDeck.topCardIndex();

            DrawDeck.TimeToRefreshDeck(DiscardDeck);
            BasicCard cardDrawn = DrawDeck.CardDeck[cardDrawnIndex];
            DrawDeck.removeCard(cardDrawnIndex);

            if (!PlayDrawnCard(cardDrawn))
            {
                TurnOrder.GoToNextTurn();
            }
        }

        private bool PlayDrawnCard(BasicCard cardDrawn)
        {
            bool playedCard = false;

            Console.WriteLine("You drew a " + cardDrawn.lookAtCard() + ".");

            if (DiscardDeck.isCardPlayable(cardDrawn))
            {
                Console.WriteLine("The card you drew is playable.");
                Console.WriteLine("Would you like to play this card?");

                PerformActionEnteredYesNoOrUno(cardDrawn);
            }
            else
            {
                currentPlayer.AddCardToHand(cardDrawn);
            }

            return playedCard;
        }

        private bool PerformActionEnteredYesNoOrUno(BasicCard cardDrawn)
        {
            string playerInput;
            bool isValidInput = false;
            bool playedCard = false;

            do
            {
                playerInput = PromptPlayerInputYesOrNo();
                bool isPlayerActionEnum = Enum.TryParse<PlayerActionEnum>(playerInput, out PlayerActionEnum action);

                if (string.IsNullOrEmpty(playerInput))
                {
                    isValidInput = false;
                }
                else if (playerInput[0] == 'y')
                {
                    currentPlayer.PlayCard(cardDrawn);
                    playedCard = true;
                    isValidInput = true;
                }
                else if (playerInput[0] == 'n')
                {
                    currentPlayer.AddCardToHand(cardDrawn);
                    isValidInput = true;
                }
                else if (isPlayerActionEnum)
                {
                    if (action == PlayerActionEnum.Uno)
                    {
                        sayUno.PerformAction();
                        currentPlayer.PlayCard(cardDrawn);
                        playedCard = true;
                        isValidInput = true;
                    }
                }

            } while (isValidInput);


            return playedCard;

        }
    }
}
