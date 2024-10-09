//Estudiante: CARLOS ALEXANDER ILALUQUE HUANCA
//Pregunta: 3
#include <stdio.h>

int main()
{
   int a, b;  
   float division; 
   int suma, resta, multiplicacion;
   int *p_a, *p_b; 
   int i, j;

   p_a = &a;
   p_b = &b;


   printf("\t\t EJ punteros ");
   printf("\t\n Introduzca el primer numero: ");
   scanf("%d", p_a); 
   printf("\t\n Introduzca el segundo numero: ");
   scanf("%d", p_b);  

   j = *p_a; 

   suma = (*p_a) + (*p_b); 
   printf("\t La suma es: %d \n", suma);

   resta = (*p_a) - (*p_b);
   printf("\t La resta es: %d \n", resta);

   if (*p_b != 0) {
      division = (float)(*p_a) / (*p_b);
      printf("\t La division es: %.4f \n", division);
   } else {
      printf("\t Error: División por cero no permitida\n");
   }

   
   multiplicacion = 0;
   for (i = 0; i < j; i++) {
      multiplicacion += (*p_b);
      
   printf("\t La multiplicacion es: %d \n", multiplicacion);

   return 0;
}

