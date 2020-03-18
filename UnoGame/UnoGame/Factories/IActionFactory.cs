using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enums;
using UnoGame.Decks;
using UnoGame.GameActions;

namespace UnoGame.Factories
{
    public interface IActionFactory
    {
        public GameActions.GameAction createPlayCardAction(Deck deckToPlayFrom);
    }

}
