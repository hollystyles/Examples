using System;
using System.Linq;
using System.Collections.Generic;

public class Player
{
    private readonly string _symbol;
    public Player(string symbol)
    {
        _symbol = symbol;
    }

    public string Symbol()
    {
        return _symbol;
    }

    public Grid Play(Grid grid)
    {
        while(true){

            Console.Write($"Player '{_symbol}' choose a free cell (1-9): ");
            var input = Console.ReadLine();
            Console.WriteLine();

            var num = 0;
            if(int.TryParse(input, out num) && num > 0 && num < 10)
            {                
                if(grid.CellAt(num).IsEmpty())
                {
                    return new Grid(
                        Enumerable.Range(1, 9)
                            .Select(i => 
                                (i == num) ? new Cell(_symbol) : new Cell(grid.CellAt(i).Content()))
                        .ToArray()
                    );
                }
                else
                {
                    Console.WriteLine("That cell is not empty, try again.");                    
                }
            }
            else
            {
                Console.WriteLine($"{input} is not a valid cell, try again.");
            }
        }
    }
}