using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;

namespace UnoGame.Decks
{
    public class PlayerHand:Deck
    {
        public PlayerHand()
        {
            this.CardDeck = new List<BasicCard>();
        }
    }
}
