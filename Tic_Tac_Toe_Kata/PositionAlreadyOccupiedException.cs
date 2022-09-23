using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Kata
{
    public class PositionAlreadyOccupiedException : Exception
    {
        public PositionAlreadyOccupiedException()
        {
        }

        public PositionAlreadyOccupiedException(string message) : base(message)
        {
                
        }
    }
}
