using System;
using NUnit.Framework;
using Tic_Tac_Toe_Kata;

namespace TicTacToeKataTests
{
    public class TicTacToeGameShould
    {
        private TicTacToeGame _ticTacToeGame;
        
        [SetUp]
        public void Setup()
        {
            _ticTacToeGame = new TicTacToeGame();
        }
        
        [Test]
        public void Prevent_O_From_Going_First()
        {
            Assert.Throws<InvalidOperationException>(() => _ticTacToeGame.PlaceToken("O", 0, 0));
        }

        [Test]
        public void Allow_X_To_Go_First()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
        }

        [Test]
        public void Prevent_X_From_Going_Twice_In_A_Row()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            Assert.Throws<InvalidOperationException>(() => _ticTacToeGame.PlaceToken("X", 0, 0));
        }

        [Test]
        public void Prevent_O_From_Going_Twice_In_A_Row()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            _ticTacToeGame.PlaceToken("O", 0, 0);
            Assert.Throws<InvalidOperationException>(() => _ticTacToeGame.PlaceToken("O", 0, 0));
        }

        [Test]
        public void Allow_O_To_Be_Placed_Second()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            _ticTacToeGame.PlaceToken("O", 0, 0);

            // Assert no exception is thrown.
        }

        [Test]
        public void Allow_X_To_Be_Placed_Third()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            _ticTacToeGame.PlaceToken("O", 0, 1);
            _ticTacToeGame.PlaceToken("X", 0, 2);

            // Assert no exception is thrown.
        }

        [Test]
        public void Prevent_X_Being_Placed_in_An_Occupied_Position()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            _ticTacToeGame.PlaceToken("O", 0, 1);
            Assert.Throws<InvalidOperationException>(() => _ticTacToeGame.PlaceToken("X", 0, 0));
        }
    }
}