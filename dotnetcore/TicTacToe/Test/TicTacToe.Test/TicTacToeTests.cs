using System;
using Xunit;
using Hollyathome.Games.TicTacToe.Lib;

namespace TicTacToe.Test
{
    public class TicTacToeTests
    {
        public const int NEW_GAME = 99;

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

            g.Run();

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol() == "O");
        }

        [Fact]
        public void TestCrossesWinsAfterNoughtsWins()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7, NEW_GAME, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            g.Run();

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol() == "X");
        }

        [Theory]
        [InlineData(new int[]{1, 2, 3, 5, 4, 7, 6, 9, 8, NEW_GAME, 8, 6, 7, 4, 5, 3, 2, 1})]
        [InlineData(new int[]{8, 9, 6, 7, 4, 5, 3, 2, 1, NEW_GAME, 1, 3, 5, 4, 7, 6, 9, 8})]
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

            g.Run();

            Assert.True(fakeUi.IsDrawnGame);
        }

        [Fact]
        public void TestAlternateStartingPlayer()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7, NEW_GAME, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var g = new Game(
                new Player[]{
                    new Player("O", fakeUi),
                    new Player("X", fakeUi)
                },
                fakeUi
            );

            g.Run();

            Assert.True(fakeUi.Winner.Symbol() == "X");
        }

        [Theory]
        [InlineData(new int[]{1, 1, 2, 3, 4, 5 ,6, 7})]
        [InlineData(new int[]{1, 10, 20, 2, 3, 4, 5 ,6, 7})]
        [InlineData(new int[]{8, 9, 6, 7, 4, 5, 3, 2, 1, NEW_GAME, 1, 1, 3, 5, 4, 7, 6, 9, 8})]
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

            g.Run();

            Assert.EndsWith("Please try again.", fakeUi.LastError);
        }
    }
}
