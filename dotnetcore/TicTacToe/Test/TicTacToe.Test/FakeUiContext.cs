using System;
using Hollyathome.Games.TicTacToe.Lib;

namespace TicTacToe.Test
{
    internal class FakeUiContext : UiContext
    {
        private int _nextMove;
        private int[] _moves;
	private string _lastMessage;
        private string _lastError;
        private Player _winner;
        private bool _isDrawnGame;

        public FakeUiContext(int[] moves)
        {
            _nextMove = -1;

            _moves = moves;
        }

	public string LastMessage
	{
	    get
	    {
		return _lastMessage;
	    }
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
        {
            /*-------------------------+
            |   I'm a fake UI LOL :)   |
            +-------------------------*/
        }

        public override void OnPlayerTakeTurn(object sender, TakeTurnEventArgs args)
        {
            _nextMove++;

            if(_nextMove < _moves.Length )
                args.Player.AttemptMove(args.Grid, _moves[_nextMove]);
        }

	public override void Message(string message)
	{
	    _lastMessage = message;
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
