using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Enums;
using UnoGame.Cards;
using UnoGame.Functions;

namespace UnoGame.Cards.CardBehaviors
{
    public class SetCardColor:CardBehavior
    {
        private Nullable<CardColor> color;
        public SetCardColor(BasicCard card)
        {
            this.BasicCard = card;
            setColor(BasicCard.Color);
            Type = BasicCard.Type;
            PerformCardAction = BasicCard.PerformCardAction;
            CardWithNoActions = false;
            card.CardWithNoActions = false;
        }
        public override void playCard()
        {
            Console.WriteLine("What color would you like the " + this.Type + " card to be?");
            string playerInput = Console.ReadLine().Trim().ToLower();
            playerInput = Function.titleCase(playerInput);
            //ToDo: Need exception handling here.
            CardColor color = (CardColor)Enum.Parse(typeof(CardColor), playerInput, true);
            setColor(color);
            BasicCard.playCard();

        }
    }
}
