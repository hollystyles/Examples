using System;
using System.Linq;
using System.Collections.Generic;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public class Game
    {
        private readonly Player[] _players;
        private readonly UiContext _ui;
        private readonly Stack<Grid> _gridStack;
        private List<int[]> _winLines;

        public Game(Player[] players, UiContext ui)
        {
            _players = players;

            _ui = ui;

            _gridStack = new Stack<Grid>();

            _winLines = new List<int[]>(8);

            _winLines.Add(new int[]{1,2,3});
            _winLines.Add(new int[]{4,5,6});
            _winLines.Add(new int[]{7,8,9});

            _winLines.Add(new int[]{1,5,9});
            _winLines.Add(new int[]{3,5,7});

            _winLines.Add(new int[]{1,4,7});
            _winLines.Add(new int[]{2,5,8});
            _winLines.Add(new int[]{3,6,9});
        }

        public void Run()
        {
            var grid = NewGame();

            while(true)
            {
                foreach(var player in _players)
                {
                    if(GameOver(grid))
                    {
                        if(!PlayAgain())
                            return;
                        else
                            grid = NewGame();
                    }
                    
                    grid = TakeTurn(player, grid);
                }   
            }
        }

        private Grid TakeTurn(Player player, Grid grid)
        {
            grid = player.Play(grid);
            _gridStack.Push(grid);
            _ui.Draw(grid);

            return grid;
        }

        private bool PlayAgain()
        {
            return _ui.StartNewGame();
        }

        private Grid NewGame()
        {
            _gridStack.Clear();
            var grid = NewGrid();
            _gridStack.Push(grid);
            _ui.Draw(grid);

            return grid;
        }

        private bool GameOver(Grid grid)
        {
            var fullLines = new List<int[]>();

            foreach(var line in _winLines)
            {
                var gridLine = grid.CellsAt(line);
                
                foreach(var player in _players){

                    var symbol = player.Symbol();
                    
                    if(gridLine.Where(c => c.Content() == symbol).Count() == 3)
                    {
                        _ui.DeclareWinner(player);
                        return true;
                    }
                }

                if(gridLine.Where(c => !c.IsEmpty()).Count() == 3)
                {
                    fullLines.Add(line);
                }
            }

            foreach(var fullLine in fullLines)
            {
                _winLines.Remove(fullLine);
            }

            if(_winLines.Count() == 0)
            {
                _ui.DeclareDrawnGame();
                return true;
            }

            return false;
        }

        private Grid NewGrid()
        {
            return new Grid(
                Enumerable.Range(1, 9).Select(i => new Cell(String.Empty)).ToArray()
            );
        }
    }
}