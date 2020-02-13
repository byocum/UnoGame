using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Factories;
using UnoGame.Intermediaries;

namespace UnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardFactory factory = new CardFactory();
            Deck drawDeck = new DrawDeck(factory);
            Console.WriteLine("-------------Deck First Created----------------------");
            drawDeck.lookAtDeck();
            Console.WriteLine("-------------Deck Ordered----------------------");
            drawDeck.sort();
            drawDeck.lookAtDeck();
            DiscardDeck discardDeck = new DiscardDeck();
            Turn turn = new Turn();
            turn.addPlayer("Bill", discardDeck);
            turn.addPlayer("Briony", discardDeck);
            turn.addPlayer("Aidan", discardDeck);
            Console.WriteLine(turn.Players[0].Name);
            Console.WriteLine(turn.Players[1].Name);
            Console.WriteLine(turn.Players[2].Name);



        }
    }
}
