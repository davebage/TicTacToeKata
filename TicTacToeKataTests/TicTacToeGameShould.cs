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
            Assert.Throws<TokenPlacedOutOfOrderException>(() => 
                _ticTacToeGame.PlaceToken("O", 0, 0));
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
            Assert.Throws<TokenPlacedOutOfOrderException>(() =>
                _ticTacToeGame.PlaceToken("X", 0, 1));
        }

        [Test]
        public void Prevent_O_From_Going_Twice_In_A_Row()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            _ticTacToeGame.PlaceToken("O", 0, 1);
            Assert.Throws<TokenPlacedOutOfOrderException>(() => 
                _ticTacToeGame.PlaceToken("O", 0, 2));
        }

        [Test]
        public void Allow_O_To_Be_Placed_Second()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            _ticTacToeGame.PlaceToken("O", 0, 1);

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
            Assert.Throws<PositionAlreadyOccupiedException>(() => 
                _ticTacToeGame.PlaceToken("X", 0, 0));
        }

        [Test]
        public void Prevent_O_Being_Placed_in_An_Occupied_Position()
        {
            _ticTacToeGame.PlaceToken("X", 0, 0);
            Assert.Throws<PositionAlreadyOccupiedException>(() =>
                _ticTacToeGame.PlaceToken("O", 0, 0));
        }

        [Test]
        public void Mark_X_As_Winner_On_Top_Row_After_Three_Moves()
        {
            _ticTacToeGame.PlaceToken("X", 0, 2);
            _ticTacToeGame.PlaceToken("O", 0, 0);
            _ticTacToeGame.PlaceToken("X", 1, 2);
            _ticTacToeGame.PlaceToken("O", 0, 1);
            _ticTacToeGame.PlaceToken("X", 2, 2);

            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_X_As_Winner_On_Top_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", 0, 2);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", 0, 0);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("X", 1, 2);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", 0, 1);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("X", 2, 2);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }
    }
}