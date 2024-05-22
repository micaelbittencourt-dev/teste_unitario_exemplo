using System;
using Xunit;
using NewTalents;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace TestNewTalents
{
    public class CalculadoraTest
    {
        private readonly ITestOutputHelper _output;

        public CalculadoraTest(ITestOutputHelper output)
        {
            _output = output;
        }

        public Calculadora construirClasse()
        {
            string data = "22/05/2024";
            Calculadora calc = new Calculadora(data);
            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(12, 2, 14)]
        [InlineData(21, 13, 34)]
        public void TestSomar(int v1, int v2, int res)
        {
            Calculadora calc = construirClasse();

            int result = calc.somar(v1, v2);

            Assert.Equal(res, result);
        }

        [Theory]
        [InlineData(4, 3, 1)]
        [InlineData(12, 2, 10)]
        [InlineData(21, 13, 8)]
        public void TestSubtrair(int v1, int v2, int res)
        {
            Calculadora calc = construirClasse();

            int result = calc.subtrair(v1, v2);

            Assert.Equal(res, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(12, 2, 24)]
        [InlineData(21, 10, 210)]
        public void TestMultiplicar(int v1, int v2, int res)
        {
            Calculadora calc = construirClasse();

            int result = calc.multiplicar(v1, v2);

            Assert.Equal(res, result);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(12, 2, 6)]
        [InlineData(28, 7, 4)]
        public void TestDividir(int v1, int v2, int res)
        {
            Calculadora calc = construirClasse();

            int result = calc.dividir(v1, v2);

            Assert.Equal(res, result);
        }

        [Fact]
        public void TestDivisaoPorZero()
        {
            Calculadora calc = construirClasse();

            Assert.Throws<DivideByZeroException>(() => calc.dividir(3, 0));
        }

        [Fact]
        public void TestHistorico_RetornaListaComAsUltumas3Operacoes()
        {
            Calculadora calc = construirClasse();

            calc.somar(2, 3);
            calc.multiplicar(2, 3);
            calc.somar(4, 3);
            calc.somar(2, 7);

            List<string> lista = calc.historico();

            lista.ForEach(x => {
                _output.WriteLine($"{x}");
            }) ;
            
            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
