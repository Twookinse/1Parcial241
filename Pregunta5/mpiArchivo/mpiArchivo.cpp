#include <stdio.h>
#include <stdlib.h>
#include <mpi.h>

double calcular_pi(int n_inicios, int n_terminos) {
    double suma = 0.0;
    for (int i = n_inicios; i < n_inicios + n_terminos; i++) {
        suma += ((i % 2 == 0 ? 1.0 : -1.0) / (2.0 * i + 1.0));
    }
    return suma;
}

int main(int argc, char** argv) {
    int rank, size;
    const int num_terminos = 1000000; 
    double pi_total, pi_local;

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int n_terminos_por_proceso = num_terminos / size;
    int n_inicios = rank * n_terminos_por_proceso; 

    pi_local = calcular_pi(n_inicios, n_terminos_por_proceso);

    MPI_Reduce(&pi_local, &pi_total, 1, MPI_DOUBLE, MPI_SUM, 0, MPI_COMM_WORLD);

    if (rank == 0) {
        pi_total *= 4.0;
        printf("El valor aproximado de pi es: %.12f\n", pi_total);
    }

    MPI_Finalize();
    return 0;
}
