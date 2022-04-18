using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la correspondiente operacion entre el operador, num1 y num2. 
        /// Si no hubiera un operador valido por defecto se asigna el "+".
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {            
            switch (ValidarOperador(operador))
            {
                case '+':
                    return num1 + num2;
                    
                case '-':
                    return num1 - num2;
                    
                case '*':
                    return num1 * num2;
                    
                case '/':
                    return num1 / num2;
                    
                default:
                    return num1 + num2;
                    
            }            
        }

        /// <summary>
        /// Valida que los operadores +, -, * o /. Sino por defecto asigna +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                return '+';
            }
            else
            {
                return operador;
            }

        }
    }
}
