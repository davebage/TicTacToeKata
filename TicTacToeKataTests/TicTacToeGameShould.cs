using System;
using NUnit.Framework;
using Tic_Tac_Toe_Kata;

namespace TicTacToeKataTests
{
    public class TicTacToeGameShould
    {

        private TicTacToeGame _ticTacToeGame;

        private const int BOTTOM_ROW = 0;
        private const int MIDDLE_ROW = 1;
        private const int TOP_ROW = 2;

        private const int FIRST_COLUMN = 0;
        private const int MIDDLE_COLUMN = 1;
        private const int LAST_COLUMN = 2;

        [SetUp]
        public void Setup()
        {
            _ticTacToeGame = new TicTacToeGame();
        }
        
        [Test]
        public void Prevent_O_From_Going_First()
        {
            Assert.Throws<TokenPlacedOutOfOrderException>(() => 
                _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW));
        }

        [Test]
        public void Allow_X_To_Go_First()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
        }

        [Test]
        public void Prevent_X_From_Going_Twice_In_A_Row()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.Throws<TokenPlacedOutOfOrderException>(() =>
                _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW));
        }

        [Test]
        public void Prevent_O_From_Going_Twice_In_A_Row()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.Throws<TokenPlacedOutOfOrderException>(() => 
                _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW));
        }

        [Test]
        public void Allow_O_To_Be_Placed_Second()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);

            // Assert no exception is thrown.
        }

        [Test]
        public void Allow_X_To_Be_Placed_Third()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);

            // Assert no exception is thrown.
        }

        [Test]
        public void Prevent_X_Being_Placed_in_An_Occupied_Position()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.Throws<PositionAlreadyOccupiedException>(() => 
                _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW));
        }

        [Test]
        public void Prevent_O_Being_Placed_in_An_Occupied_Position()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.Throws<PositionAlreadyOccupiedException>(() =>
                _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW));
        }

        [Test]
        public void Mark_X_As_Winner_On_Top_Row_After_Three_Moves()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, TOP_ROW);
            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, TOP_ROW);

            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_X_As_Winner_On_Top_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_Top_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));
        }


        [Test]
        public void Mark_X_As_Winner_On_Middle_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, MIDDLE_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_Middle_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, MIDDLE_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));
        }


        [Test]
        public void Mark_X_As_Winner_On_Bottom_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }


        [Test]
        public void Mark_O_As_Winner_On_Bottom_Row_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));
        }

        [Test]
        public void Mark_X_As_Winner_On_First_Column_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_First_Column_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));
        }

        [Test]
        public void Mark_X_As_Winner_On_Middle_Column_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_Middle_Column_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));
        }

        [Test]
        public void Mark_X_As_Winner_On_Last_Column_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_Last_Column_After_Three_Moves_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));
        }

        [Test]
        public void Mark_X_As_Winner_On_Bottom_Left_To_Top_Right_Diagnal_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_Bottom_Left_To_Top_Right_Diagnal_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, TOP_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));

        }

        [Test]
        public void Mark_X_As_Winner_On_Top_Left_To_Bottom_Right_Diagonal_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("X"));
        }

        [Test]
        public void Mark_O_As_Winner_On_Top_Left_To_Bottom_Right_Diagonal_And_Not_Before()
        {
            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, BOTTOM_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", FIRST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", FIRST_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", MIDDLE_COLUMN, MIDDLE_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("O"));

            _ticTacToeGame.PlaceToken("X", LAST_COLUMN, TOP_ROW);
            Assert.IsFalse(_ticTacToeGame.CheckWinner("X"));

            _ticTacToeGame.PlaceToken("O", LAST_COLUMN, BOTTOM_ROW);
            Assert.IsTrue(_ticTacToeGame.CheckWinner("O"));

        }


    }
}