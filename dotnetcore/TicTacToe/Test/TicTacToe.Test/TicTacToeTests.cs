using System;
using Xunit;
using Hollyathome.Games.TicTacToe.Lib;

namespace TicTacToe.Test
{
    public class TicTacToeTests
    {
        [Fact]
        public void TestNoughtsWins()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7
                });
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            while(fakeUi.HasMoreMoves())
            {
                g.Start();
            }

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol() == "O");
        }

        [Fact]
        public void TestCrossesWinsAfterNoughtsWins()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            g.Start();

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol() == "O");

            g.Start();

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol() == "X");
        }

        [Theory]
        [InlineData(new int[]{1, 2, 3, 5, 4, 7, 6, 9, 8, 8, 9, 6, 7, 4, 5, 3, 2, 1})]
        [InlineData(new int[]{8, 9, 6, 7, 4, 5, 3, 2, 1, 1, 2, 3, 5, 4, 7, 6, 9, 8})]
        public void TestDrawnGame(int[] moves)
        {
            var fakeUi = new FakeUiContext(moves);
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            //Play two drawn games back to back
            g.Start();

            Assert.True(fakeUi.IsDrawnGame);

            g.Start();

            Assert.True(fakeUi.IsDrawnGame);
        }

        [Fact]
        public void TestAlternateStartingPlayer()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            while(fakeUi.HasMoreMoves())
            {
                g.Start();
            }

            Assert.True(fakeUi.Winner.Symbol() == "X");
        }

        [Theory]
        [InlineData(new int[]{1, 1, 2, 3, 4, 5 ,6, 7})]
        [InlineData(new int[]{1, 10, 20, 2, 3, 4, 5 ,6, 7})]
        [InlineData(new int[]{8, 9, 6, 7, 4, 5, 3, 2, 1, 1, 1, 3, 5, 4, 7, 6, 9, 8})]
        public void TestInvalidMove(int[] moves)
        {
            var fakeUi = new FakeUiContext(moves);
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            while(fakeUi.HasMoreMoves())
            {
                g.Start();
            }

            Assert.EndsWith("Please try again.", fakeUi.LastError);
        }
    }
}
