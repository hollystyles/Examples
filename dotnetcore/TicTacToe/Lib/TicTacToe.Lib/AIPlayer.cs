using System;
using System.Linq;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public class AIPlayer : Player
    {
        public AIPlayer(string symbol, UiContext ui)
            : base(symbol, ui)
        { }

        internal override void Play(Grid grid)
        {
            var move = DecideMove(grid);

            AttemptMove(grid, move);
        }

        private int DecideMove(Grid grid)
        {
            for(var i = 1; i < 10; i++)
            {
                if(grid.CellAt(i).Content() == string.Empty)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}