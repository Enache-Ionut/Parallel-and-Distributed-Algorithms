package MatrixMultiplication;

import java.util.Random;

public class MatrixGenerator 
{
	private int MAXIMUM_NUMBER = 50;
	
	public Matrix Generate(int numberOfRows, int numberOfColumns)
	{
		Random random = new Random();
		int[][] matrix = new int[numberOfRows][numberOfColumns];
		
		for(int row = 0 ; row < numberOfRows ; ++row)
			for( int col = 0 ; col < numberOfColumns ; ++col)
				matrix[row][col] = random.nextInt(MAXIMUM_NUMBER);
		
		return new Matrix(matrix);
	}
}
