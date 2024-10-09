using System;
using System.Collections.Generic;

namespace Calculadora
{
    public class ExpresionEvaluator
    {
        private bool EsOperador(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;
            if (operador == '*' || operador == '/')
                return 2;
            return 0;
        }
        private double Operacion(char operador, double b, double a)
        {
            switch (operador)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                default: throw new ArgumentException("Operador inválido");
            }
        }
        public double EvaluarInfija(string expresion)
        {
            Stack<double> valores = new Stack<double>();
            Stack<char> operadores = new Stack<char>();

            for (int i = 0; i < expresion.Length; i++)
            {
                if (char.IsDigit(expresion[i]))
                {
                    valores.Push(double.Parse(expresion[i].ToString()));
                }
                else if (expresion[i] == '(')
                {
                    operadores.Push(expresion[i]);
                }
                else if (expresion[i] == ')')
                {
                    while (operadores.Peek() != '(')
                    {
                        valores.Push(Operacion(operadores.Pop(), valores.Pop(), valores.Pop()));
                    }
                    operadores.Pop();
                }
                else if (EsOperador(expresion[i]))
                {
                    while (operadores.Count > 0 && Prioridad(operadores.Peek()) >= Prioridad(expresion[i]))
                    {
                        valores.Push(Operacion(operadores.Pop(), valores.Pop(), valores.Pop()));
                    }
                    operadores.Push(expresion[i]);
                }
            }

            while (operadores.Count > 0)
            {
                valores.Push(Operacion(operadores.Pop(), valores.Pop(), valores.Pop()));
            }

            return valores.Pop();
        }

        public double EvaluarPrefija(string expresion)
        {
            Stack<double> valores = new Stack<double>();

            for (int i = expresion.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(expresion[i]))
                {
                    valores.Push(double.Parse(expresion[i].ToString()));
                }
                else if (EsOperador(expresion[i]))
                {
                    double valor1 = valores.Pop();
                    double valor2 = valores.Pop();
                    valores.Push(Operacion(expresion[i], valor1, valor2));
                }
            }

            return valores.Pop();
        }
    }
}
