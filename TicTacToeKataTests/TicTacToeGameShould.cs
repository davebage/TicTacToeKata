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

        }
        
        [Test]
        public void Prevent_O_From_Going_First()
        {
            var ticTacToeGame = new TicTacToeGame();

            Assert.Throws<InvalidOperationException>(() => ticTacToeGame.PlaceToken("O", 0, 0));
        }

        [Test]
        public void Allow_X_To_Go_First()
        {
            var ticTacToeGame = new TicTacToeGame();

            ticTacToeGame.PlaceToken("X", 0, 0);
        }

        [Test]
        public void Prevent_X_From_Going_Twice_In_A_Row()
        {
            var ticTacToeGame = new TicTacToeGame();
        
            ticTacToeGame.PlaceToken("X", 0, 0);
            Assert.Throws<InvalidOperationException>(() => ticTacToeGame.PlaceToken("X", 0, 0));
        }

        [Test]
        public void Prevent_O_From_Going_Twice_In_A_Row()
        {
            var ticTacToeGame = new TicTacToeGame();

            ticTacToeGame.PlaceToken("X", 0, 0);
            ticTacToeGame.PlaceToken("O", 0, 0);
            Assert.Throws<InvalidOperationException>(() => ticTacToeGame.PlaceToken("O", 0, 0));
        }

        [Test]
        public void Allow_O_To_Be_Placed_Second()
        {
            var ticTacToeGame = new TicTacToeGame();

            ticTacToeGame.PlaceToken("X", 0, 0);
            ticTacToeGame.PlaceToken("O", 0, 0);

            // Assert no exception is thrown.
        }

        [Test]
        public void Allow_X_To_Be_Placed_Third()
        {
            var ticTacToeGame = new TicTacToeGame();

            ticTacToeGame.PlaceToken("X", 0, 0);
            ticTacToeGame.PlaceToken("O", 0, 1);
            ticTacToeGame.PlaceToken("X", 0, 2);

            // Assert no exception is thrown.
        }

        [Test]
        public void Prevent_X_Being_Placed_in_An_Occupied_Position()
        {
            var ticTacToeGame = new TicTacToeGame();

            ticTacToeGame.PlaceToken("X", 0, 0);
            ticTacToeGame.PlaceToken("O", 0, 1);
            Assert.Throws<InvalidOperationException>(() => ticTacToeGame.PlaceToken("X", 0, 0));
        }
    }
}