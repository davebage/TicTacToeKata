namespace Tic_Tac_Toe_Kata;

public class NoWinnerException : Exception
{
    public NoWinnerException()
    {
            
    }

    public NoWinnerException(string message) : base(message)
    {
    }
}