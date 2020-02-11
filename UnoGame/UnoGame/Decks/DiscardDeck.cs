using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Decks
{
    public class DiscardDeck:Deck
    {
        public DiscardDeck()
        {
            this.CardDeck = new List<BasicCard>(); 
        }

    }
}
