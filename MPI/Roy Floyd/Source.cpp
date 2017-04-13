#include "mpi.h"
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <fstream>

#define MAX_SIZE 6
#define INF 10000000

using namespace std;

int main(int argc, char *argv[])
{
	int error;
	int processRank;
	int numberOfProcesses;

	int matrix[MAX_SIZE][MAX_SIZE];
	int resultMatrix[MAX_SIZE][MAX_SIZE];

	error = MPI_Init(&argc, &argv);
	if (error != MPI_SUCCESS)
	{
		printf("Error starting MPI program. Terminating.\n");
		MPI_Abort(MPI_COMM_WORLD, error);
	}

	MPI_Comm_rank(MPI_COMM_WORLD, &processRank);
	MPI_Comm_size(MPI_COMM_WORLD, &numberOfProcesses);

	if (processRank == 0)
	{
		ifstream inputStream("file.txt");

		for (int i = 0; i < MAX_SIZE; i++)
			for (int j = 0; j < MAX_SIZE; j++)
				inputStream >> matrix[i][j];
			
		inputStream.close();
		MPI_Bcast(matrix, MAX_SIZE * MAX_SIZE, MPI_INT, 0, MPI_COMM_WORLD);
	}
	
	MPI_Barrier(MPI_COMM_WORLD);

	for (int k = 0; k < MAX_SIZE; k++)
	{
		for (int i = processRank; i < MAX_SIZE; i += numberOfProcesses)
			for (int j = 0; j < MAX_SIZE; j++)
				if (matrix[i][j] > matrix[i][k] + matrix[k][j])
					matrix[i][j] = matrix[i][k] + matrix[k][j];

		MPI_Allreduce(matrix, resultMatrix, MAX_SIZE*MAX_SIZE, MPI_INT, MPI_MIN, MPI_COMM_WORLD);
		
		if (processRank == 0) 
		{
			for (int i = 0; i < MAX_SIZE; i++)
				for (int j = 0; j < MAX_SIZE; j++)
					matrix[i][j] = resultMatrix[i][j];

			MPI_Bcast(matrix, MAX_SIZE * MAX_SIZE, MPI_INT, 0, MPI_COMM_WORLD);
		}
		MPI_Barrier(MPI_COMM_WORLD);
	}

	if (processRank == 0)
	{
		for (int i = 0; i < MAX_SIZE; i++)
		{
			for (int j = 0; j < MAX_SIZE; j++)
				printf("%d ", matrix[i][j]);
			printf("\n");
		}
	}

	MPI_Finalize();
}