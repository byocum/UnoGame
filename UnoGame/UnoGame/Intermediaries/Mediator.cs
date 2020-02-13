using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Factories;
using UnoGame.Cards;

namespace UnoGame.Intermediaries
{
    public class Mediator
    {
        Turn turn;
        DrawDeck drawDeck;
        DiscardDeck discardDeck;

        public Mediator()
        {
            CardFactory cardFactory = new CardFactory();
            turn = new Turn();
            drawDeck = new DrawDeck(cardFactory);
            discardDeck = new DiscardDeck();
        }

        private void dealCards()
        {
            for(int numCardsEachPersonHas = 0; numCardsEachPersonHas < 7; numCardsEachPersonHas++)
            {
                for(int player = 1; player < turn.Players.Count; player++)
                {
                    int drawDeckTopCardIndex = drawDeck.CardDeck.Count - 1;
                    BasicCard cardDealing = drawDeck.CardDeck[drawDeckTopCardIndex];

                    drawDeck.removeCard(drawDeckTopCardIndex);
                    turn.Players[player].addCardToHand(cardDealing);
                }
            }
        }
    }
}
