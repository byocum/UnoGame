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
            bool playerInputValid = false;

            do
            {
                object cardColor;
                string playerInput;

                Console.WriteLine("What color would you like the " + this.Type + " card to be?");

                playerInput = Console.ReadLine().Trim().ToLower();
                playerInput = Function.titleCase(playerInput);
                
                playerInputValid = Enum.TryParse(typeof(CardColor), playerInput, true, out cardColor);
                if (playerInputValid)
                {
                    setColor((CardColor)cardColor);
                    BasicCard.playCard();
                }
                else
                {
                    Console.WriteLine(playerInput + " is not a color option. Color options are: ");
                    foreach(CardColor color in Enum.GetValues(typeof(CardColor)))
                    {
                        Console.WriteLine(color);
                    }

                }

            } while (!playerInputValid);



        }
    }
}
