using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Propiedad que solo permite setear el atributo, primero validandolo.
        /// </summary>
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Constructor por defecto, asignandole 0 al atributo numero.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor con tipo double.
        /// </summary>
        /// <param name="numero">Valor a ser asignado al Operando.</param>
        public Operando(double numero)
        {

            this.numero = numero;
        }

        /// <summary>
        /// Constructor con tipo string. Transformando dicho valor a double.
        /// </summary>
        /// <param name="strNumero">Valor a ser asignado.</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Valida que el operando sea un numero y lo parsea, sino le asigna un 0 a dicho valor.
        /// </summary>
        /// <param name="strNumero">Valor a ser validado y parseado.</param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double valorRecibido))
            {
                return valorRecibido;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida que el valor sea un binario.
        /// </summary>
        /// <param name="binario">String a ser validado</param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte el valor absoluto de un numero en base 10 (decimal) a un numero en base 2 (binario).
        /// </summary>
        /// <param name="numero">Valor a ser convertido.</param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            double residuo;

            numero = Math.Round(numero);
            numero = Math.Abs(numero);

            if (numero == 0)
            {
                return "0000";
            }

            if (numero > 0)
            {
                while (numero >= 1)
                {
                    residuo = (int)numero % 2;
                    numero /= 2;
                    binario = residuo.ToString() + binario;
                }
                return binario;
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Convierte el valor absoluto de un numero en base 10 (decimal) a un numero en base 2 (binario).
        /// </summary>
        /// <param name="numero">Valor a ser convertido.</param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double.TryParse(numero, out double numeroParseado);
            return DecimalBinario(numeroParseado);
        }

        /// <summary>
        /// Convierte un numero de base 2 (binario) a un numero en base 10 (decimal).
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            double numeroEnDecimal = 0;
            char[] valores = binario.ToCharArray();
            Array.Reverse(valores);

            if (!EsBinario(binario))
            {
                return "Valor Invalido";
            }
            else
            {
                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i] == '1')
                    {
                        numeroEnDecimal += Math.Pow(2, i);
                    }
                }
                return numeroEnDecimal.ToString();
            }
        }

        /// <summary>
        /// Realiza una resta entre los dos operandos.
        /// </summary>
        /// <param name="n1">Operando</param>
        /// <param name="n2">Valor a ser restado del operando.</param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Realiza una suma entre los dos operandos.
        /// </summary>
        /// <param name="n1">Operando 1</param>
        /// <param name="n2">Operando 2</param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza una multiplicacion entre los dos operandos.
        /// </summary>
        /// <param name="n1">Operando 1</param>
        /// <param name="n2">Operando 2</param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza una division entre los dos operandos.
        /// </summary>
        /// <param name="n1">Operando a ser dividido.</param>
        /// <param name="n2">Divisor</param>
        /// <returns></returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }

    }
}
