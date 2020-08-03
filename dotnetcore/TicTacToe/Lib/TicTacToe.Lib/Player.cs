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

        internal void Play(Grid grid)
        {
            _ui.TakeTurn(grid, this);                
        }

        public virtual void AttemptMove(Grid grid, int move)
        {
            if(IsValidMove(grid, move))
            {
                grid = ApplyMove(grid, move);
                _ui.TurnOver(grid);             
            }
            else
            {
                _ui.Error($"Your choice was not a valid cell or the cell is already taken. Please try again.");
                _ui.TakeTurn(grid, this);
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