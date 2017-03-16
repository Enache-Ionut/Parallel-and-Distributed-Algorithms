using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    public class MatricesMultiplier : IMatricesMultiplier
    {
        public int[,] MultiThreadMultiplication(int[,] firstMatrix, int[,] secondMatrix)
        {

            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
                throw new Exception("You can not multiply this matices !");

            int numberOfRows = firstMatrix.GetLength(0);
            int numberOfColumns = secondMatrix.GetLength(1);
            int[,] resultMatrix = new int[numberOfRows, numberOfColumns];

            Parallel.For(0, numberOfRows, row =>
            {
                for (int col = 0; col < numberOfColumns; ++col)
                    for (int k = 0; k < numberOfColumns; ++k)
                        resultMatrix[row, col] += firstMatrix[row, k] * secondMatrix[k, col];
            });
            return resultMatrix;
        }

        public int[,] SingleThreadMultiplication(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
                throw new Exception("You can not multiply this matices !");

            int numberOfRows = firstMatrix.GetLength(0);
            int numberOfColumns = secondMatrix.GetLength(1);
            int[,] resultMatrix = new int[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; ++row)
               for (int col = 0; col < numberOfColumns; ++col)
                   for (int k = 0; k < numberOfColumns; ++k)
                        resultMatrix[row, col] += firstMatrix[row, k] * secondMatrix[k, col];

            return resultMatrix;
        }
    }
}
