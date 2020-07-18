using System;
using System.Linq;
namespace Hollyathome.Games.TicTacToe.Lib
{
    public class Grid
    {
        private readonly Cell[] _cells;
        public Grid(Cell[] cells)
        {
            _cells = cells;
        }

        public Cell CellAt(int position)
        {
            return _cells[position - 1];
        }

        public Cell[] CellsAt(int[] positions)
        {
            return positions.Select(pos => _cells[pos - 1]).ToArray();
        }
    }
}