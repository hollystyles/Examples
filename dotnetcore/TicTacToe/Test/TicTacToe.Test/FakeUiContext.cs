using System;
using Hollyathome.Games.TicTacToe.Lib;

namespace TicTacToe.Test
{
    internal class FakeUiContext : UiContext
    {
        private int _nextMove;
        private int[] _moves;
        private string _lastError;
        private Player _winner;
        private bool _isDrawnGame;

        public FakeUiContext(int[] moves)
        {
            _nextMove = -1;

            _moves = moves;
        }

        public string LastError
        {
            get
            {
                return _lastError;
            }
        }

        public Player Winner
        {
            get
            {
                return _winner;
            }
        }

        public bool IsDrawnGame
        {
            get
            {
                return _isDrawnGame;
            }
        }

        public override void Draw(Grid grid)
        {}

        public override void TakeTurn(Grid grid, Player player)
        {
            _nextMove++;

            if(_nextMove < _moves.Length )
                player.AttemptMove(grid, _moves[_nextMove]);
        }

        public override void Error(string message)
        {
            _lastError = message;
        }
        
        public override void DeclareWinner(Player winner)
        {
            _winner = winner;
        }

        public override void DeclareDrawnGame()
        {
            _isDrawnGame = true;
        }

        public bool HasMoreMoves()
        {
            return _nextMove + 1 < _moves.Length;
        }
    }
}