using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_of_two_matrix
{
    public interface IGenerator
    {
        int[,] Generate(int numberOfRows, int numberOfColumns);
    }
}
