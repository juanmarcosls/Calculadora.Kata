

namespace Calculadora
{
    public class Calculator
    {
        public int Calcular(string caracter)
        {
            if (string.IsNullOrEmpty(caracter))
            {
                return 0;
            }

            var numeros = caracter.Split(',', ';', ':', '|', ' ');
            var numerosInvalidos = numeros.Where(num => !int.TryParse(num, out int numeroInvalido))
                                          .Any();

            if (numerosInvalidos)
            {
                throw new ArgumentException("Caracteres no validos");
            }

            var numerosNegativos = numeros.Select(int.Parse)
                                          .Where(num => num < 0)
                                          .Any();

            if (numerosNegativos)
            {
                throw new ArgumentException("No se pueden utilizar numeros negativos");
            }




            return numeros.Select(int.Parse)
                          .Sum();
        }
    }
}