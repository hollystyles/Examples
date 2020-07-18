using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public class Player
    {
        private readonly string _symbol;
        private readonly UiContext _ui;

        public Player(string symbol, UiContext ui)
        {
            _symbol = symbol;
            _ui = ui;
        }

        public string Symbol()
        {
            return _symbol;
        }

        public Grid Play(Grid grid)
        {
            while(true)
            {
                var move = _ui.GetPlayerMove(this);

                if(IsValidMove(grid, move))
                {
                    return ApplyMove(grid, move);
                }
                else
                {
                    _ui.Error($"Your choice was not a valid cell or the cell is already taken. Please try again.");
                }
            }
        }

        private bool IsValidMove(Grid grid, int move)
        {
            return  move > 0 
                    && move < 10
                    && grid.CellAt(move).IsEmpty();
        }

        private Grid ApplyMove(Grid grid, int move)
        {
            return new Grid(
                        Enumerable.Range(1, 9)
                            .Select(cellPos => 
                                (cellPos == move) ? new Cell(_symbol) : new Cell(grid.CellAt(cellPos).Content()))
                        .ToArray()
                    );
        }
    }
}