package MatrixMultiplication;

import java.util.concurrent.LinkedBlockingQueue;

import MatrixMultiplication.*;

public class ThreadPool 
{
	private int numberOfThreads;
	private MyThread[] threads;
	private LinkedBlockingQueue queueOfWorkers = new LinkedBlockingQueue();

	public ThreadPool(int numberOfThreads) 
	{
		this.numberOfThreads = numberOfThreads;
		threads = new MyThread[this.numberOfThreads];
		for(MyThread thread : threads)
			(thread = new MyThread(queueOfWorkers)).start();
	}
	
	public void AddWorker(Runnable work) 
	{
		synchronized (queueOfWorkers) 
		{
			queueOfWorkers.add(work);
			queueOfWorkers.notify();
		}
	}
}