using UnoGame.Intermediaries;

namespace UnoGame
{
    class Program
    {
        static void Main()
        {
            Mediator mediator = new Mediator();
            mediator.SetupGame();
            mediator.PlayGame();
        }
    }
}
