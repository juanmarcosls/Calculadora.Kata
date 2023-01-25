using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{

    public class Calculadora
    {

        public int Calculator(string caracter)
        {
            if (string.IsNullOrEmpty(caracter))
            {
                return 0;
            }

            var numeros = caracter.Split(',', ';', ':', '|', ' ');

            var numerosNoValidos = numeros.Where(numero => !int.TryParse(numero, out int numeroInvalido))
                                          .Any();

            if (numerosNoValidos)
            {
                throw new ArgumentException("Caracteres invalidos");
            }

            var numerosNegativos = numeros.Select(int.Parse)
                                          .Where(numero => numero < 0)
                                          .Any();

            if (numerosNegativos)
            {
                throw new ArgumentException("No utilizar numeros negativos");
            }




            return numeros.Select(int.Parse)
                          .Sum();

        }
    }
}