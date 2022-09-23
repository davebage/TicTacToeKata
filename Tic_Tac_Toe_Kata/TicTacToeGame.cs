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
                _lastToken = token;
                return;
            }

            throw new TokenPlacedOutOfOrderException();
        }
    }
}