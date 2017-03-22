using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    public class MatricesMultiplier : IMatricesMultiplier
    {

        public int[,] MultiThreadMultiplicationParallelFor(int[,] firstMatrix, int[,] secondMatrix)
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

        private void ComputeElement(Element elem, int[,] resultMatrix, int[,] firstMatrix, int[,] secondMatrix)
        {
            resultMatrix[elem.x, elem.y] = 0;
            for (int i = 0; i < secondMatrix.GetLength(1); ++i)
            {
                resultMatrix[elem.x, elem.y] += firstMatrix[elem.x, i] * secondMatrix[i, elem.y];
            }
        }


        public int[,] MultiThreadMultiplicationThreads(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
                throw new Exception("You can not multiply this matices !");

            int numberOfRows = firstMatrix.GetLength(0);
            int numberOfColumns = secondMatrix.GetLength(1);
            int[,] resultMatrix = new int[numberOfRows, numberOfColumns];

            Thread[,] th = new Thread[numberOfRows, numberOfColumns];
            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    Element elem = new Element();
                    elem.x = i;
                    elem.y = j;
                    th[i, j] = new Thread(() => ComputeElement(elem, resultMatrix, firstMatrix, secondMatrix));
                    th[i, j].Start();
                }
            }

            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    th[i, j].Join();
                }
            }

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
