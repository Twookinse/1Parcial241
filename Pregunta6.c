//Estudiante: CARLOS ALEXANDER ILALUQUE HUANCA
//Pregunta: 6
#include <stdio.h>

int main() {
    int n, i;
    int fibonacci[2];

    fibonacci[0] = 0; 
    fibonacci[1] = 1;

    printf("Ingrese el número de términos de Fibonacci a calcular: ");
    scanf("%d", &n);

    
    printf("%d\n", fibonacci[0]); 
    printf("%d\n", fibonacci[1]);

    
    for (i = 2; i < n; i++) {
        int next = fibonacci[0] + fibonacci[1];  

        fibonacci[0] = fibonacci[1]; 
        fibonacci[1] = next;        

        printf("%d\n", fibonacci[1]);
    }

    return 0;
}
