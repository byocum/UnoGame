using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Card;

namespace UnoGame.Deck
{
    public class PlayerHand:Deck
    {
        public PlayerHand()
        {
            this.CardDeck = new List<BasicCard>();
        }
    }
}
