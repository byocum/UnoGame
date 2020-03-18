using System;
using System.Collections.Generic;
using System.Text;

namespace UnoGame.GameActions
{
    public class Pause:GameAction
    {
        public Pause() { }

        public override bool PerformAction()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return false;
        }
    }
}
