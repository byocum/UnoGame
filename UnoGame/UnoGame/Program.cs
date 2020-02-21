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
            Mediator mediator = new Mediator();
            mediator.setupGame();
            mediator.startGame();




        }
    }
}
