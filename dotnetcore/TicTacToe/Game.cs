using System;
using System.Linq;
using System.Collections.Generic;

public class Game
{
    private readonly Player[] _players;
    private readonly Stack<Grid> _gridStack;
    private List<int[]> _winLines;

    public Game(Player[] players)
    {
        _players = players;

        _gridStack = new Stack<Grid>();

        _winLines = new List<int[]>(8);

        _winLines.Add(new int[]{1,2,3});
        _winLines.Add(new int[]{4,5,6});
        _winLines.Add(new int[]{7,8,9});

        _winLines.Add(new int[]{1,5,9});
        _winLines.Add(new int[]{3,5,7});

        _winLines.Add(new int[]{1,4,7});
        _winLines.Add(new int[]{2,5,8});
        _winLines.Add(new int[]{3,6,9});
    }

    public void Run()
    {
        var grid = NewGame();

        while(true)
        {
            foreach(var player in _players)
            {
                if(GameOver(grid))
                {
                    if(!PlayAgain())
                        return;
                    else
                        grid = NewGame();
                }
                else{
                    grid = TakeTurn(player, grid);
                }
            }   
        }
    }

    private Grid TakeTurn(Player player, Grid grid)
    {
        grid = player.Play(grid);
        _gridStack.Push(grid);
        Draw(grid);

        return grid;
    }

    private bool PlayAgain()
    {
        while(true)
        {
            Console.Write("New game (y/n): ");
            var input = Console.ReadLine();

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
                Console.WriteLine();
                Console.WriteLine($"Is '{input}' a Yes or a No? I can't tell.");
            } 
        }
    }

    private Grid NewGame()
    {
        _gridStack.Clear();
        var grid = NewGrid();
        _gridStack.Push(grid);
        Draw(grid);

        return grid;
    }
    private void Draw(Grid grid)
    {
        Console.Clear();
        Console.Write("\t");

        for(var i = 1; i <= 9; i++)
        {
            Console.Write(grid.CellAt(i).Content() + "\t");

            if(i % 3 == 0)
            {
                Console.WriteLine();

                if(i < 7)
                    Console.WriteLine("------------------------------------------------");

                Console.Write("\t");    
            }
            else
            {
                Console.Write("|\t");
            }
        }

        Console.WriteLine();
    }

    private bool GameOver(Grid grid)
    {
        var fullLines = new List<int[]>();

        foreach(var line in _winLines)
        {
            var gridLine = grid.CellsAt(line);
            
            foreach(var player in _players){

                var symbol = player.Symbol();
                
                if(gridLine.Where(c => c.Content() == symbol).Count() == 3)
                {
                    Console.WriteLine($"Player '{symbol}' is the winner!");
                    return true;
                }
            }

            if(gridLine.Where(c => !c.IsEmpty()).Count() == 3)
            {
                fullLines.Add(line);
            }
        }

        foreach(var fullLine in fullLines)
        {
            _winLines.Remove(fullLine);
        }

        if(_winLines.Count() == 0)
        {
            Console.WriteLine("The game is a draw.");
            return true;
        }

        return false;
    }

    private Grid NewGrid()
    {
        return new Grid(
            Enumerable.Range(1, 9).Select(i => new Cell(String.Empty)).ToArray()
        );
    }
}