using System;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public abstract class UiContext
    {
        public abstract void Draw(Grid grid);

        public abstract void OnPlayerTakeTurn(object sender, TakeTurnEventArgs args);

        public abstract void Error(string message);

        public abstract void DeclareWinner(Player winner);

        public abstract void DeclareDrawnGame();
    }
}