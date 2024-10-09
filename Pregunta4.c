//Estudiante: CARLOS ALEXANDER ILALUQUE HUANCA
//Pregunta: 4
#include <stdio.h>

void calcular_pi_iterativo(int n, double *resultado) {
    double suma = 0.0;
    for (int i = 0; i < n; i++) {
        suma += (i % 2 == 0 ? 1.0 : -1.0) / (2.0 * i + 1.0);
    }
    *resultado = suma * 4.0; 
}

int main() {
    int n = 1000000;
    double pi;

    calcular_pi_iterativo(n, &pi);
    printf("El valor aproximado de p (iterativo) es: %.15f\n", pi);

    return 0;
}
