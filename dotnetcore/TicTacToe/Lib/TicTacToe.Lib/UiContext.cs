using System;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public abstract class UiContext
    {
        public abstract void Draw(Grid grid);

        public abstract int GetPlayerMove(Player player);

        public abstract void Error(string message);

        public abstract void DeclareWinner(Player winner);

        public abstract void DeclareDrawnGame();

        public abstract bool StartNewGame();
    }
}