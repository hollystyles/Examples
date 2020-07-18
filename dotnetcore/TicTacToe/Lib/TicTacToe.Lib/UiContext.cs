using System;

namespace Hollyathome.Games.TicTacToe.Lib
{
    public abstract class UiContext
    {
        public virtual void Draw(Grid grid)
        {}

        public virtual int GetPlayerMove(Player player)
        {
            return 0;
        }

        public virtual void Error(string message)
        {}

        public virtual void DeclareWinner(Player winner)
        {}

        public virtual void DeclareDrawnGame()
        {}

        public virtual bool StartNewGame()
        {
            return false;
        }
    }
}