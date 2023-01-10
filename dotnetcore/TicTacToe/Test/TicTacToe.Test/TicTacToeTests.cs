using Xunit;
using Hollyathome.Games.TicTacToe.Lib;

namespace TicTacToe.Test
{
    public class TicTacToeTests
    {
        private const string NOUGHTS = "O";
	    private const string CROSSES = "X";
	
        [Fact]
        public void TestNoughtsWins()
        {
            /*
                 O | X | O
                -------/---
                 X | O | X
                ---/-------
                 O |   |  
            */
            var setOfMoves = new int[] {1, 2, 3, 4, 5 ,6, 7};
            var fakeUi = new FakeUiContext(setOfMoves);
            var players = new Player[] {
                new Player(NOUGHTS, fakeUi),
                new Player(CROSSES, fakeUi)
            };

            var game = new Game(players, fakeUi);

            while(fakeUi.HasMoreMoves())
            {
                game.Start();
            }

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol().Equals(NOUGHTS));
        }

        [Fact]
        public void TestCrossesWinsAfterNoughtsWins()
        {
            /*
                  Game 1         Game 2

                 O | X | O      X | O | X
                -------/---    -------/---
                 X | O | X      O | X | O
                ---/-------    ---/-------
                 O |   |        X |   |  
            */
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var game = new Game(
                new Player[]{
                    new Player(NOUGHTS, fakeUi),
                    new Player(CROSSES, fakeUi)
                },
                fakeUi
            );

            game.Start();

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol().Equals(NOUGHTS));

            game.Start();

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol().Equals(CROSSES));
        }

        [Theory]
        [InlineData(new int[]{1, 2, 3, 5, 4, 7, 6, 9, 8, 8, 9, 6, 7, 4, 5, 3, 2, 1})]
        [InlineData(new int[]{8, 9, 6, 7, 4, 5, 3, 2, 1, 1, 2, 3, 5, 4, 7, 6, 9, 8})]
        public void TestDrawnGame(int[] moves)
        {
            //Play four drawn games back to back
            /*
                 Game 1/4        Game 2/4      Game 3/4      Game 4/4

                 O | X | O      X | O | X     O | X | O     X | O | X
                -----------    -----------   -----------   -----------
                 O | X | O      X | O | X     O | X | O     X | O | X
                -----------    -----------   -----------   -----------
                 X | O | X      O | X | O     X | O | X     O | X | O
            */
            
            var fakeUi = new FakeUiContext(moves);
            
            var game = new Game(
                new Player[]{
                    new Player(NOUGHTS, fakeUi),
                    new Player(CROSSES, fakeUi)
                },
                fakeUi
            );
            
            while(fakeUi.HasMoreMoves())
            {
                game.Start();
                Assert.True(fakeUi.IsDrawnGame);
            }
        }

        [Fact]
        public void TestAlternateStartingPlayer()
        {
            var fakeUi = new FakeUiContext(new int[]{
                    1, 2, 3, 4, 5 ,6, 7, 1, 2, 3, 4, 5 ,6, 7
                });
            
            var game = new Game(
                new Player[]{
                    new Player(NOUGHTS, fakeUi),
                    new Player(CROSSES, fakeUi)
                },
                fakeUi
            );

            while(fakeUi.HasMoreMoves())
            {
                game.Start();
            }

            Assert.False(fakeUi.IsDrawnGame);
            Assert.True(fakeUi.Winner.Symbol().Equals(CROSSES));
        }

        [Theory]
        [InlineData(new int[]{1, 1, 2, 3, 4, 5 ,6, 7})]
        [InlineData(new int[]{1, 10, 20, 2, 3, 4, 5 ,6, 7})]
        [InlineData(new int[]{8, 9, 6, 7, 4, 5, 3, 8, 1, 1, 2, 3, 5, 3, 7, 6, 9, 8})]
        public void TestInvalidMoves(int[] moves)
        {
            var fakeUi = new FakeUiContext(moves);
            
            var game = new Game(
                new Player[]{
                    new Player(NOUGHTS, fakeUi),
                    new Player(CROSSES, fakeUi)
                },
                fakeUi
            );

            while(fakeUi.HasMoreMoves())
            {
                game.Start();
                Assert.EndsWith("Please try again.", fakeUi.LastError);
            }            
        }
    
        [Fact]
        public void TestAIPlayer()
        {
            var fakeUi = new FakeUiContext(new int[]{});
            
            var game = new Game(
                new Player[]{
                    new AIPlayer(NOUGHTS, fakeUi),
                    new AIPlayer(CROSSES, fakeUi)
                },
                fakeUi
            );

            game.Start();
            
            Assert.True(fakeUi.Winner.Symbol().Equals(NOUGHTS));
        }
    }
}
