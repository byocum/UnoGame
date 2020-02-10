using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Card;

namespace UnoGame.Deck
{
    public class DiscardDeck:Deck
    {
        public DiscardDeck()
        {
            this.CardDeck = new List<BasicCard>(); 
        }

    }
}
