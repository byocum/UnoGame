using System;
using System.Collections.Generic;
using System.Text;
using UnoGame.Decks;
using UnoGame.Intermediaries;

namespace UnoGame.PlayerActions
{
    public class Rules:PlayerAction
    {
        public Rules() { }

        public override bool performAction()
        {
            string welcome = "Welcome to the game of UNO.           \n\n";
            Console.WriteLine(welcome.PadLeft(Console.WindowWidth - welcome.Length));

            Console.WriteLine("PLAYING A CARD \n");
            Console.WriteLine("When playing a card type in the number to the left of the card.");
            Console.Write("For Example: If the card displays as: \"3 Green Draw 2\" type in \"3\".\n");

            //ToDo: Write functionality for declaring uno. Then rewrite the directions.
            Console.WriteLine("SAY UNO\n");
            Console.WriteLine("In order to say UNO when playing your second to last card, type \"Uno\"");
            Console.WriteLine("You will then be asked what card you want to play. See rules for playing a card.");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();

            Console.WriteLine("CALL A PLAYER OUT FOR NOT SAYING UNO\n");
            Console.WriteLine("If you want to call a player out for not saying Uno when they are playing");
            Console.WriteLine("their second to last card type \"Uno\".  You will then be asked which player you want to pick. ");
            Console.WriteLine("Type the number next to the players name to select a player.");

            Console.WriteLine("If a player is called out for not saying Uno when they play their second to last");
            Console.WriteLine("card they have to draw 2 cards.\n");

            Console.WriteLine("DRAW A CARD\n");
            Console.WriteLine("Type \"Draw\" to draw a card.You may draw a card on your turn whether or");
            Console.WriteLine("not you have a playable card. Once you have drawn a card, you will have the");
            Console.WriteLine("option to play the card you drew if it is a playable card. However, you will");
            Console.WriteLine("not have the option to play a card in your hand.\n");

            Console.WriteLine("SEE GAME RULES\n");
            Console.WriteLine("If you want to see these instructions again during the game type \"Rules\".");

            Console.WriteLine("\nPress any key to enter players and start the game.");
            Console.ReadLine();

            return true;
        }
    }
}
