using System;
using UnoGame.Intermediaries;
using UnoGame.Decks;
using UnoGame.Cards;

namespace UnoGame.PlayerActions
{
    public class Deal : PlayerAction
    {
        public Deal(DrawDeck drawDeck, DiscardDeck discardDeck, Turn turn)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }
        public override bool performAction()
        {
            dealCards();
            return true;
        }
        private void dealCards()
        {
            Console.WriteLine("Dealing Cards...");

            dealEachPlayerSevenCards();
        }

        private void dealEachPlayerSevenCards()
        {
            for (int numCardsEachPersonHas = 0; numCardsEachPersonHas < 7; numCardsEachPersonHas++)
            {
                dealEachPlayerOneCard();
            }
        }

        private void dealEachPlayerOneCard()
        {
            for (int player = 0; player < TurnOrder.Players.Count; player++)
            {
                dealCard(player);
            }

        }

        private void dealCard(int playerIndex)
        {
            int drawDeckTopCardIndex = DrawDeck.topCardIndex();

            BasicCard cardDealing = DrawDeck.CardDeck[drawDeckTopCardIndex];

            DrawDeck.removeCard(drawDeckTopCardIndex);
            TurnOrder.Players[playerIndex].addCardToHand(cardDealing);
        }
    }
}
