namespace Tic_Tac_Toe_Kata
{
    public class TicTacToeGame
    {
        private string _lastToken = string.Empty;
        private string[,] _board = new string[3, 3];

        public void PlaceToken(string token, int column, int row)
        {
            if (!string.IsNullOrEmpty(_board[column, row])) throw new PositionAlreadyOccupiedException();

            if (token == "X" && token != _lastToken)
            {
                _board[column, row] = token;
                _lastToken = token;
                return;
            }

            if (token == "O" && token != _lastToken && _lastToken != string.Empty)
            {
                _board[column, row] = token;
                _lastToken = token;
                return;
            }

            throw new TokenPlacedOutOfOrderException();
        }

        public bool CheckWinner(string token)
        {
            if (_board[0, 2] == token && _board[1, 1] == token && _board[2, 0] == token)
                return true;
            if (_board[0, 0] == token && _board[1, 1] == token && _board[2, 2] == token)
                return true;

            if (_board[0, 0] == token && _board[0, 1] == token && _board[0, 2] == token )
                return true;
            if (_board[1, 0] == token && _board[1, 1] == token && _board[1, 2] == token)
                return true;
            if (_board[2, 0] == token && _board[2, 1] == token && _board[2, 2] == token)
                return true;


            if (_board[0, 2] == token && _board[1, 2] == token && _board[2, 2] == token)
                return true;

            if (_board[0, 1] == token && _board[1, 1] == token && _board[2, 1] == token)
                return true;

            if (_board[0, 0] == token && _board[1, 0] == token && _board[2, 0] == token)
                return true;


            return false;
        }
    }
}