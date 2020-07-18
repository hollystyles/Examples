using System;
using Hollyathome.Games.TicTacToe.Lib;

namespace Hollyathome.Games.TicTacToe.Console
{
    internal class ConsoleUiContext : UiContext
    {
        public override void Draw(Grid grid)
        {
            System.Console.Clear();
            System.Console.Write("\t");

            for(var i = 1; i <= 9; i++)
            {
                System.Console.Write(grid.CellAt(i).Content() + "\t");

                if(i % 3 == 0)
                {
                    System.Console.WriteLine();

                    if(i < 7)
                        System.Console.WriteLine("------------------------------------------------");

                    System.Console.Write("\t");    
                }
                else
                {
                    System.Console.Write("|\t");
                }
            }

            System.Console.WriteLine();
        }

        public override int GetPlayerMove(Player player)
        {
            var move = 0;
            
            System.Console.Write($"Player '{player.Symbol()}' choose a free cell (1-9): ");
            var input =  System.Console.ReadLine();
            
            int.TryParse(input, out move);
            
            return move;
        }

        public override void Error(string message)
        {
            System.Console.WriteLine(message);
        }

        public override void DeclareWinner(Player winner)
        {
            System.Console.WriteLine($"Player '{winner.Symbol()}' is the winner!");
        }

        public override void DeclareDrawnGame()
        {
            System.Console.WriteLine("The game is a draw.");
        }

        public override bool StartNewGame()
        {
            while(true)
            {
                System.Console.Write("New game (y/n): ");
                var input = System.Console.ReadLine();

                if(input.ToLower() == "y")
                {
                    return true;
                }
                else if(input.ToLower() == "n")
                {
                    return false; 
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Is '{input}' a Yes or a No? I can't tell.");
                } 
            }
        }
    }
}