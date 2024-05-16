using Calculadora;

namespace TestsCalculadora
{
    public class UnitTest1
    {
        public Calculadora1 ConstruirClasse()
        {
            string data = "15/05/2024";
            Calculadora1 calc = new Calculadora1("15/05/2024");

            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int num1, int num2, int resultado)
        {
            Calculadora1 calc = ConstruirClasse();

            int resultadoCalculadora = calc.Somar(num1, num2);
            
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int num1, int num2, int resultado)
        {
            Calculadora1 calc = ConstruirClasse();

            int resultadoCalculadora = calc.Multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int num1, int num2, int resultado)
        {
            Calculadora1 calc = ConstruirClasse();

            int resultadoCalculadora = calc.Dividir(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int num1, int num2, int resultado)
        {
            Calculadora1 calc = ConstruirClasse();

            int resultadoCalculadora = calc.Subtrair(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDividisaoPorZero() 
        {
            Calculadora1 calc = ConstruirClasse();

            Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0));
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora1 calc = ConstruirClasse();

            calc.Somar(3, 5);
            calc.Somar(6, 8);
            calc.Somar(4, 6);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}