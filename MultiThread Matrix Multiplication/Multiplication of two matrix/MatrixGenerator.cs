using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    public class MatrixGenerator : IGenerator
    {
        private const int LIMIT = 100; 
        private Random random = new Random();

        public int[,] Generate(int numberOfRows, int numberOfColumns)
        {
            if (numberOfRows == 0 || numberOfColumns == 0)
                throw new Exception("The number of rows or columns is equal with 0 !");

            int[,] matrix = new int[numberOfRows, numberOfColumns];

            for ( int row = 0; row < numberOfRows; ++row )
                for (int col = 0; col < numberOfColumns; ++col)
                    matrix[row, col] = random.Next(LIMIT);
            return matrix;
        }

    }
}
