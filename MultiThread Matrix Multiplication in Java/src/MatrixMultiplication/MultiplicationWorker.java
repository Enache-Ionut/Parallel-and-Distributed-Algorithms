package MatrixMultiplication;

public class MultiplicationWorker implements Runnable 
{
	private int row;
	private int column;
	private int[][] firstMatrix;
	private int[][] secondMatrix;
	private int[][] resultMatrix;

	public MultiplicationWorker(Matrix firstMatrix, Matrix secondMatrix, Matrix resultMatrix, int row, int column) 
	{
		this.firstMatrix = firstMatrix.GetMatrix();
		this.secondMatrix = secondMatrix.GetMatrix();
		this.resultMatrix = resultMatrix.GetMatrix();
		this.row = row;
		this.column = column;
	}
	
	@Override
	public void run() 
	{
		for(int index = 0 ; index < resultMatrix[0].length ; index++)
			resultMatrix[row][column] += firstMatrix[row][index] * secondMatrix[index][column];
	}
}
