using System;
using Hollyathome.Games.TicTacToe.Lib;

namespace Hollyathome.Games.TicTacToe.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleUiContext();

            var g = new Game(
                new Player[]{
                    new Player("O", console),
                    new Player("X", console)
                },
                console
            );

            g.Run();
        }
    }
}
