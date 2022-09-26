using System.Security.Cryptography.X509Certificates;

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

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                if (VerticalWinCheck(token, columnIndex))
                    return VerticalWinCheck(token, columnIndex);

            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
                if(HorizontalWinCheck(token, rowIndex))
                    return HorizontalWinCheck(token, rowIndex);

            if (!BoardHasEmptySquare()) throw new NoWinnerException();

            return false;
        }

        protected virtual bool VerticalWinCheck(string token, int columnNumber)
        {
            return _board[columnNumber, 0] == token && 
                   _board[columnNumber, 1] == token && 
                   _board[columnNumber, 2] == token;
        }

        private bool HorizontalWinCheck(string token, int rowNumber)
        {
            return _board[0, rowNumber] == token && 
                   _board[1, rowNumber] == token && 
                   _board[2, rowNumber] == token;
        }

        private bool BoardHasEmptySquare()
        {
            foreach (var boardSquare in _board)
                if (string.IsNullOrWhiteSpace(boardSquare))
                    return true;

            return false;
        }
    }
}