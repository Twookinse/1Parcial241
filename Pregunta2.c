// Estudiante: CARLOS ALEXANDER ILALUQUE HUANCA
// Pregunta 2
 
#include <stdio.h>

void main(){ 
	int a;
   int b;
	printf("Ingresa el primer numero: ");
	scanf("%d", &a); 
	printf("Ingresa el segundo numero: ");
	scanf("%d", &b);  
   int suma = a + b;   
   int resta = a - b;  
   int multiplicacion = a * b; 
   float division = (float)a / b;
   printf("El resultado de la suma es: %d\n", suma);
   printf("El resultado de la resta es: %d\n", resta);
   printf("El resultado de la multiplicacion es: %d\n", multiplicacion);
   printf("El resultado de la division es: %.4f\n", division);
   return 0;
}