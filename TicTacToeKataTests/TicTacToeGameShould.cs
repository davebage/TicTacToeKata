using System;
using NUnit.Framework;
using Tic_Tac_Toe_Kata;

namespace TicTacToeKataTests
{
    public class TicTacToeGameShould
    {
        [Test]
        public void ThrowExceptionIfOGoesFirst()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();

            Assert.Throws<InvalidOperationException>(() => ticTacToeGame.PlaceToken("O", 0, 0));
        }
    }
}