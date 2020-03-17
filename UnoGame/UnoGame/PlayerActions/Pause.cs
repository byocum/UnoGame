using System;
using System.Collections.Generic;
using System.Text;

namespace UnoGame.PlayerActions
{
    public class Pause:PlayerAction
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
