using System;

namespace UnoGame.GameActions
{
    public class Pause:GameAction
    {
        public Pause() { }

        public override bool PerformAction()
        {
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            return false;
        }
    }
}
