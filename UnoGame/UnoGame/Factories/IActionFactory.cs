using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enums;
using UnoGame.Decks;
using UnoGame.PlayerActions;

namespace UnoGame.Factories
{
    public interface IActionFactory
    {
        public PlayerAction createPlayCardAction(Deck deckToPlayFrom);
    }

}
