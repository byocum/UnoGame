using System;


namespace UnoGame.GameActions
{
    public class Rules:GameAction
    {
        private readonly GameAction pause;
        public Rules(GameAction pause) 
        {
            this.pause = pause;
        }

        public override bool PerformAction()
        {
            string welcome = "Welcome to the game of UNO.           \n\n";
            Console.WriteLine(welcome.PadLeft(Console.WindowWidth - welcome.Length));

            Console.WriteLine("PLAYING A CARD \n");
            Console.WriteLine("When playing a card type in the number to the left of the card.");
            Console.WriteLine("For Example: If the card displays as: \"3 Green Draw 2\" type in \"3\". \n");

            Console.WriteLine("SORT CARDS IN YOUR HAND \n");
            Console.WriteLine("To sort the cards in your hand type \"Sort\"");
            Console.WriteLine("This will sort your cards by color first then by number and display your sorted hand. \n");

            Console.WriteLine("SAY UNO\n");
            Console.WriteLine("In order to say UNO when playing your second to last card, type \"Uno\"");
            Console.WriteLine("You will then be asked what card you want to play. See rules for playing a card. \n");

            pause.PerformAction();

            Console.WriteLine("SHOW HOW MANY CARDS ARE IN EACH PLAYER'S HAND\n");
            Console.WriteLine("To see how many cards are in each players hand type \"Hands\". \n");

            Console.WriteLine("CALL OUT A PLAYER FOR NOT SAYING UNO\n");
            Console.WriteLine("If you want to call out a player for not saying Uno when they are playing");
            Console.WriteLine("their second to last card type \"Call Uno\".");
            Console.WriteLine("You will then be asked which player you want to pick.");
            Console.WriteLine("Type the number next to the players name to select a player. \n");

            Console.WriteLine("If a player did not say Uno when they play their second to last");
            Console.WriteLine("card and another player calls them out, they have to draw 2 cards.\n");

            Console.WriteLine("DRAW A CARD\n");
            Console.WriteLine("Type \"Draw\" to draw a card.You may draw a card on your turn whether or");
            Console.WriteLine("not you have a playable card. Once you have drawn a card, you will have the");
            Console.WriteLine("option to play the card you drew if it is a playable card. However, you will");
            Console.WriteLine("not have the option to play a card in your hand.\n");

            Console.WriteLine("SEE GAME RULES\n");
            Console.WriteLine("If you want to see these instructions again during the game type \"Rules\". \n");

            pause.PerformAction();

            return true;
        }
    }
}
