using System;
using System.Collections.Generic;
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
                //Matrix2D firstMatrix = new Matrix2D(new double[,]{ { 1, 1 }, { 1, 1 }});
                //Matrix2D secondMatrix = new Matrix2D(new double[,] { { 1, 1 }, { 1, 1 } });

                Matrix2D firstMatrix = new Matrix2D(matrixGenerator.Generate(5, 10));
                Matrix2D secondMatrix = new Matrix2D(matrixGenerator.Generate(10, 9));

                MatricesMultiplier matricesMultiplier = new MatricesMultiplier();

                Matrix2D resultMatrixSingleThread = new Matrix2D(
                    matricesMultiplier.SingleThreadMultiplication(firstMatrix.GetMatrix, secondMatrix.GetMatrix));

                Matrix2D resultMatrixMultiThread = new Matrix2D(
                    matricesMultiplier.MultiThreadMultiplication(firstMatrix.GetMatrix, secondMatrix.GetMatrix));

                Console.WriteLine("\n\nSingle Thread Matrix\n\n");
                resultMatrixSingleThread.Display();

                Console.WriteLine("\n\nMultiThread Matrix\n\n");
                resultMatrixMultiThread.Display();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.Read();
        }
    }
}
