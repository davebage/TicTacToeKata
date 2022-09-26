namespace Tic_Tac_Toe_Kata
{
    public class TicTacToeGame
    {
        private string _lastToken = string.Empty;
        private string[,] _board = new string[3, 3];

        public void PlaceToken(string token, int xCoordinate, int yCoordinate)
        {
            if (!string.IsNullOrEmpty(_board[xCoordinate, yCoordinate])) throw new PositionAlreadyOccupiedException();

            if (token == "X" && token != _lastToken)
            {
                _board[xCoordinate, yCoordinate] = token;
                _lastToken = token;
                return;
            }

            if (token == "O" && token != _lastToken && _lastToken != string.Empty)
            {
                _board[xCoordinate, yCoordinate] = token;
                _lastToken = token;
                return;
            }

            throw new TokenPlacedOutOfOrderException();
        }

        public bool CheckWinner(string token)
        {
            if (token == "X" && _board[0, 2] == "X" && _board[1, 2] == "X" && _board[2, 2] == "X")
                return true;

            if (token == "O" && _board[0, 2] == "O" && _board[1, 2] == "O" && _board[2, 2] == "O")
                return true;

            if (token == "X" && _board[0, 1] == "X" && _board[1, 1] == "X" && _board[2, 1] == "X")
                return true;

            if (token == "O" && _board[0, 1] == "O" && _board[1, 1] == "O" && _board[2, 1] == "O")
                return true;

            if (token == "X" && _board[0, 0] == "X" && _board[1, 0] == "X" && _board[2, 0] == "X")
                return true;


            if (token == "O" && _board[0, 0] == "O" && _board[1, 0] == "O" && _board[2, 0] == "O")
                return true;



            return false;
        }
    }
}