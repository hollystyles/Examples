using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Game(
                new Player[]{
                    new Player("O"),
                    new Player("X")
                }
            );

            g.Run();
        }
    }
}
