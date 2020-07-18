using System;
using Xunit;
using Hollyathome.Games.TicTacToe.Lib;

namespace Hollyathome.Games.TicTacToe.Test
{
    public class TicTacToeTests
    {
        [Fact]
        public void TestNoughtsWins()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    0, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            g.Run();

            Assert.True(fakeUi.Winner.Symbol() == "O");
        }
    }
}
