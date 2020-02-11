using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Decks
{
    public class DrawDeck:Deck
    {
        public DrawDeck()
        {
            this.CardDeck = new List<BasicCard>();
            createDeck();
        }

        private void createDeck()
        {

        }
    }
}
