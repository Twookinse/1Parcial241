using System;
using Calculadora;

namespace CalculadorConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpresionEvaluator evaluator = new ExpresionEvaluator();

            Console.WriteLine("Ingrese la expresión infija:");
            string infija = Console.ReadLine();
            double resultadoInfija = evaluator.EvaluarInfija(infija);
            Console.WriteLine($"Resultado de la expresión infija: {resultadoInfija}");

            Console.WriteLine("Ingrese la expresión prefija:");
            string prefija = Console.ReadLine();
            double resultadoPrefija = evaluator.EvaluarPrefija(prefija);
            Console.WriteLine($"Resultado de la expresión prefija: {resultadoPrefija}");

            Console.ReadKey();
        }
    }
}
