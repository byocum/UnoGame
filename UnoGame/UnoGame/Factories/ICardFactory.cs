using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Cards;
using UnoGame.Enums;

namespace UnoGame.Factories
{
    interface ICardFactory
    {
        public BasicCard CreateCard(CardColor color, CardType type);
    }
}
