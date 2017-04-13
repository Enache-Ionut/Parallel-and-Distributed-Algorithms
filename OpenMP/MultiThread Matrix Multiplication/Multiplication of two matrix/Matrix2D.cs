using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    public class Matrix2D
    {
        public int[,] GetMatrix { get; }

        public Matrix2D(int[,] matrix)
        {
            this.GetMatrix = matrix;
        }

        public void Display()
        {
            for (int row = 0; row < GetMatrix.GetLength(0); ++row)
            {
                for (int col = 0; col < GetMatrix.GetLength(1); ++col)
                    Console.Write("{0} ", GetMatrix[row, col]);
                Console.WriteLine();
            }
        }
    }
}
