using Hollyathome.Games.TicTacToe.Lib;

namespace TicTacToe.Blazor
{
    public class BlazorUiContext : UiContext
    {
        public Player currentPlayer;

        public Grid currentGrid;

        public string prompt;

        public string error;

        public bool gameOver;

        private int nextMove;

        public override void Draw(Grid grid)
        { 
            currentGrid = grid;
        }

        public override void OnPlayerTakeTurn(object sender, TakeTurnEventArgs args)
        { 
            currentPlayer = args.Player;
            currentGrid = args.Grid;

            prompt = $"Player '{args.Player.Symbol()}' choose a free cell (1-9): ";
        }

        public void AcceptMove(int move)
        {
            nextMove = move;
            currentPlayer.AttemptMove(currentGrid, move);
        }

        public override void Error(string message)
        {
            error = message;
        }

        public override void DeclareWinner(Player winner)
        {
            prompt = $"Player '{winner.Symbol()}' is the winner.";
            gameOver = true;
        }

        public override void DeclareDrawnGame()
        {
            prompt = $"The game is a draw.";
            gameOver = true;
        }
    }
}