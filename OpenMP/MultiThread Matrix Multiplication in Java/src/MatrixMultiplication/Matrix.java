package MatrixMultiplication;

public class Matrix 
{
	private int numberOfRows;
	private int numberOfColumns;
	private int[][] matrix;
	
	public Matrix(int numberOfRows, int numberOfColumns)
	{
		this.numberOfRows = numberOfRows;
		this.numberOfColumns = numberOfColumns;
		matrix = new int[this.numberOfRows][this.numberOfColumns];
	}
	
	public Matrix(int[][] matrix)
	{
		numberOfRows = matrix.length;
		numberOfColumns = matrix[0].length;
		this.matrix = matrix;
	}
	
	public void Display()
	{
		for (int row = 0; row < numberOfRows; ++row) 
		{
			for (int col = 0; col < numberOfColumns; ++col) 
				System.out.print(matrix[row][col] + " ");
			System.out.println();
		}
	}
	
	public int[][] GetMatrix()
	{
		return matrix;
	}
	
	public int GetNumberOfRows()
	{
		return numberOfRows;
	}
	
	public int GetNumberOfColumns()
	{
		return numberOfColumns;
	}
}
