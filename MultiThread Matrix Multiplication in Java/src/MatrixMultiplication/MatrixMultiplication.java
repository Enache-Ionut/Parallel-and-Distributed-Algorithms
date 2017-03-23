package MatrixMultiplication;

public class MatrixMultiplication 
{
	public Matrix MultiThread(Matrix firstMatrix, Matrix secondMatrix, ThreadPool threadPool) throws Exception
	{
		if( firstMatrix.GetNumberOfColumns() != secondMatrix.GetNumberOfRows() )
			throw new Exception("You can not multiply this matrices !");
		
		Matrix resultMatrix = new Matrix(firstMatrix.GetNumberOfRows(), secondMatrix.GetNumberOfColumns());
		for (int row = 0; row < firstMatrix.GetNumberOfRows(); row++) 
			for (int col = 0; col < secondMatrix.GetNumberOfColumns(); col++) 
			{
				MultiplicationWorker worker = new MultiplicationWorker(firstMatrix, secondMatrix, resultMatrix, row, col);
				threadPool.AddWorker(worker);
			}
		return resultMatrix;
	}
	
	public Matrix SingleThread( int[][] firstMatrix, int[][] secondMatrix) throws Exception
	{
		if( firstMatrix[0].length != secondMatrix.length )
			throw new Exception("You can not multiply this matrices !");
		
		int[][] resultMatrix = new int[firstMatrix.length][secondMatrix[1].length];
		
		for (int row = 0; row < firstMatrix.length; ++row)
            for (int col = 0; col < secondMatrix[1].length; ++col)
                for (int k = 0; k < secondMatrix[1].length; ++k)
                     resultMatrix[row][col] += firstMatrix[row][k] * secondMatrix[k][col];
		
		return new Matrix(resultMatrix);
	}
}
