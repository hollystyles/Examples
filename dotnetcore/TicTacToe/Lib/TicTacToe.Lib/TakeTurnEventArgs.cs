using System;

namespace Hollyathome.Games.TicTacToe.Lib
{   
    public class TakeTurnEventArgs : EventArgs
    {
        public readonly Grid Grid;

        public readonly Player Player;

        public TakeTurnEventArgs(Grid grid, Player player)
        {
            Grid = grid;
            Player = player;
        }
    }
}