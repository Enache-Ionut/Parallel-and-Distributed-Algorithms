using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    public interface IMatricesMultiplier
    {
        int[,] SingleThreadMultiplication(int[,] firstMatrix, int[,] secondMatrix);
        int[,] MultiThreadMultiplicationParallelFor(int[,] firstMatrix, int[,] secondMatrix);
        int[,] MultiThreadMultiplicationThreads(int[,] firstMatrix, int[,] secondMatrix);
    }
}
