using System;
using UnoGame.Cards;
using UnoGame.Decks;
using UnoGame.Factories;

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
            drawDeck.order();
            drawDeck.lookAtDeck();

        }
    }
}
