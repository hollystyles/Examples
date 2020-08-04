using System;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public class EndTurnEventArgs : EventArgs
    {
        public readonly Grid Grid;

        public EndTurnEventArgs(Grid grid)
        {
            Grid = grid;
        }
    }
}