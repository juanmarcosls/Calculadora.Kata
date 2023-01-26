using Xunit;
using Calculadora;

namespace UnitTest1
{
    public class TestCalculadora
    {
        [Fact]
        public void CaracterVacioRetornaCero()
        {
            var calculadora = new Calculator();
            var caracter = "";

            var resultado = calculadora.Calcular(caracter);
            Assert.Equal(0, resultado);
        }

        [Theory]
        [InlineData("5,6", 11)]
        [InlineData("1,25", 26)]
       
        
        public void DosNumerosSeparadosPorComaSeSuman(string numeros, int esperado)
        {
            var calculadora = new Calculator();
            var resultado = calculadora.Calcular(numeros);

            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("10,10,10,10", 40)]
        [InlineData("1,9,10,60", 80)]
        [InlineData("10,20,30,100,120", 280)]
       
        
        public void NumerosSeparadosPorComaSeSuman(string caracter, int esperado)
        {
            var calculadora = new Calculator();
            var resultado = calculadora.Calcular(caracter);

            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("8;4:2", 14)]
        [InlineData("500|100|900;100", 1600)]
        [InlineData("7,3,5;5:5", 25)]
       
        
        public void NumerosSeparadosPorCualquierDelimitadorSeSuman(string caracter, int esperado)
        {
            var calculadora = new Calculator();
            var resultado = calculadora.Calcular(caracter);

            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("-4,8,-9,-1")]
        [InlineData("1,-6,-5,-3,-101")]
        
       
        public void LosNumerosNegativosLanzanExcepcion(string caracter)
        {
            var calculadora = new Calculator();

            Exception exception = null;
            try
            {
                calculadora.Calcular(caracter);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }
            Assert.Contains("No se pueden utilizar numeros negativos", exception.Message);

        }
        [Theory]
        [InlineData("a,b,c,d,1,2,3,4")]
        [InlineData("9,10,1,c,z")]
     
        
        public void CaracteresInvalidosLanzaExcepcion(string caracter)
        {
            var calculadora = new Calculator();

            Exception exception = null;
            try
            {
                calculadora.Calcular(caracter);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }

            Assert.Contains("Caracteres invalidos", exception.Message);
        }
    }
}