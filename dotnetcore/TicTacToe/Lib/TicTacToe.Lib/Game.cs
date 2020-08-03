using System;
using System.Linq;
using System.Collections.Generic;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public class Game
    {
        private readonly Player[] _players;
        private readonly UiContext _ui;
        private List<int[]> _winLines;

        private int _playerIndex;

        public Game(Player[] players, UiContext ui)
        {
            _players = players;

            _playerIndex = 0;

            _ui = ui;
        }

        public virtual void Start()
        {
            var grid = NewGame();

            _ui.Start(this);

            _players[_playerIndex].Play(grid);
        }

        public virtual void NextTurn(Grid grid)
        {
            _playerIndex = (_playerIndex == 0 ) ? 1 : 0;
            
            _ui.Draw(grid);

            if(!GameOver(grid))
            {
                _players[_playerIndex].Play(grid);
            }
        }

        private Grid NewGame()
        {
            _winLines = new List<int[]>(8);

            _winLines.Add(new int[]{1,2,3});
            _winLines.Add(new int[]{4,5,6});
            _winLines.Add(new int[]{7,8,9});

            _winLines.Add(new int[]{1,5,9});
            _winLines.Add(new int[]{3,5,7});

            _winLines.Add(new int[]{1,4,7});
            _winLines.Add(new int[]{2,5,8});
            _winLines.Add(new int[]{3,6,9});

            var grid = NewGrid();

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