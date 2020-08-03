using System;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public abstract class UiContext
    {
        protected Game _game;

        internal void Start(Game game)
        {
            _game = game;
        }

        internal void TurnOver(Grid grid)
        {
            _game.NextTurn(grid);
        }

        public abstract void Draw(Grid grid);

        public abstract void TakeTurn(Grid grid, Player player);

        public abstract void Error(string message);

        public abstract void DeclareWinner(Player winner);

        public abstract void DeclareDrawnGame();
    }
}