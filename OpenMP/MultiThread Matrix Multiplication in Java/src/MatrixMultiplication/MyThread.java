package MatrixMultiplication;

import java.util.concurrent.LinkedBlockingQueue;

public class MyThread extends Thread
{
	private Runnable work;
	private LinkedBlockingQueue queueOfWorkers;
	
	public MyThread(LinkedBlockingQueue queueOfWorkers)
	{
		this.queueOfWorkers = queueOfWorkers;
	}
	
	public void run() 
	{	
		while (true) 
		{
			synchronized (queueOfWorkers) 
			{
				while (queueOfWorkers.isEmpty()) 
				{
					try
					{
						queueOfWorkers.wait();
					} 
					catch (InterruptedException e) 
					{
						System.out.println( e.getMessage());
					}
				}
				work = queueOfWorkers.peek() instanceof Runnable ? (Runnable)queueOfWorkers.poll() : null;
			}
			try 
			{
				if( work != null )
					work.run();
			} 
			catch (RuntimeException e) 
			{
				System.out.println( e.getMessage());
			}
		}
	}
}


