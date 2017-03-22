using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixGenerator matrixGenerator = new MatrixGenerator();

            try
            {
                //Matrix2D firstMatrix = new Matrix2D(new int[,] { { 1, 1 }, { 1, 1 } });
                //Matrix2D secondMatrix = new Matrix2D(new int[,] { { 1, 1 }, { 1, 1 } });

                Matrix2D firstMatrix = new Matrix2D(matrixGenerator.Generate(4, 4));
                Matrix2D secondMatrix = new Matrix2D(matrixGenerator.Generate(4, 4));

                MatricesMultiplier matricesMultiplier = new MatricesMultiplier();
               
                Matrix2D resultMatrixSingleThread = new Matrix2D(
                    matricesMultiplier.SingleThreadMultiplication(firstMatrix.GetMatrix, secondMatrix.GetMatrix));

                Matrix2D resultMatrixMultiThread = new Matrix2D(
                    matricesMultiplier.MultiThreadMultiplicationThreads(firstMatrix.GetMatrix, secondMatrix.GetMatrix));

                Matrix2D resultMatrixMultiThreadParallelFor = new Matrix2D(
                    matricesMultiplier.MultiThreadMultiplicationParallelFor(firstMatrix.GetMatrix, secondMatrix.GetMatrix));

                Console.WriteLine("\n\nSingle Thread Matrix\n\n");
                resultMatrixSingleThread.Display();

                Console.WriteLine("\n\nMultiThread Matrix \n\n");
                resultMatrixMultiThread.Display();

                Console.WriteLine("\n\nMultiThreadParallelFor Matrix\n\n");
                resultMatrixMultiThreadParallelFor.Display();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.Read();
        }
    }
}
