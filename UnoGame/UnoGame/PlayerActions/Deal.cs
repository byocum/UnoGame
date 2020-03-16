using System;
using UnoGame.Intermediaries;
using UnoGame.Decks;
using UnoGame.Cards;

namespace UnoGame.PlayerActions
{
    public class Deal : PlayerAction
    {
        public Deal(Deck drawDeck, Deck discardDeck, Turn turn)
        {
            DrawDeck = drawDeck;
            DiscardDeck = discardDeck;
            TurnOrder = turn;
        }
        public override bool PerformAction()
        {
            DealCards();
            return true;
        }
        private void DealCards()
        {
            Console.WriteLine("Dealing Cards...");

            DealEachPlayerSevenCards();
        }

        private void DealEachPlayerSevenCards()
        {
            for (int numCardsEachPersonHas = 0; numCardsEachPersonHas < 7; numCardsEachPersonHas++)
            {
                DealEachPlayerOneCard();
            }
        }

        private void DealEachPlayerOneCard()
        {
            for (int player = 0; player < TurnOrder.Players.Count; player++)
            {
                DealCard(player);
            }

        }

        private void DealCard(int playerIndex)
        {
            int drawDeckTopCardIndex = DrawDeck.topCardIndex();

            BasicCard cardDealing = DrawDeck.CardDeck[drawDeckTopCardIndex];

            DrawDeck.removeCard(drawDeckTopCardIndex);
            TurnOrder.Players[playerIndex].AddCardToHand(cardDealing);
        }
    }
}
