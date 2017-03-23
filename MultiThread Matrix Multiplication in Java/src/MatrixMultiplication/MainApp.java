package MatrixMultiplication;

import java.util.concurrent.TimeUnit;
import MatrixMultiplication.ThreadPool;

public class MainApp 
{
	public static void main(String[] args) 
	{
		int numberOfRows = 50;
		int numberOfColumns = 50;
		long start;
		long stop;
		
		MatrixGenerator matrixGenerator = new MatrixGenerator();
		Matrix firstMatrix = matrixGenerator.Generate(numberOfRows, numberOfColumns);
		Matrix secondMatrix = matrixGenerator.Generate(numberOfRows, numberOfColumns);
		
		MatrixMultiplication matrixMultiplication = new MatrixMultiplication();
		
		try
		{
			start = System.currentTimeMillis();
			Matrix resultMatrixSingleThread = matrixMultiplication.SingleThread(firstMatrix.GetMatrix(), secondMatrix.GetMatrix());
			stop = System.currentTimeMillis();
			
			System.out.println("SingleThreadMatrix -> " + (stop - start) + "\n" );
			resultMatrixSingleThread.Display();
			System.out.println("\n");
		}
		catch (Exception e) 
		{
			System.out.println(e.getMessage());
		}
		
		try
		{
			ThreadPool threadPool = new ThreadPool(4);
			
			start = System.currentTimeMillis();
			Matrix resultMatrixMultiThread = matrixMultiplication.MultiThread(firstMatrix, secondMatrix, threadPool);
			stop = System.currentTimeMillis();
			
			System.out.println("MultiThreadMatrix -> " + (stop - start) + "\n");
			resultMatrixMultiThread.Display();
			System.out.println("\n");	
		}
		catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}
}
