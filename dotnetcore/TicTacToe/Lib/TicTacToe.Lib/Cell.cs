namespace Hollyathome.Games.TicTacToe.Lib
{
    public class Cell
    {
        private readonly string _content;

        public Cell(string content)
        {
            _content = content;
        }

        public string Content()
        {
            return _content;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(_content);
        }
    }
}