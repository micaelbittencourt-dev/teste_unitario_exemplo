using System;
using System.Collections.Generic;
using System.Text;

namespace NewTalents
{
    public class Calculadora
    {
        private List<string> historicoOperacoes;
        private string data;
        public Calculadora(string data)
        {
            historicoOperacoes = new List<string>();
            this.data = data;
        }
        public int somar(int val1, int val2)
        {
            int res = val1 + val2;
            addHistorico(res);
            return res;
        }

        public int subtrair(int val1, int val2)
        {
            int res = val1 - val2;
            addHistorico(res);
            return res;
        }

        public int multiplicar(int val1, int val2)
        {
            int res = val1 * val2;
            addHistorico(res);
            return res;
        }

        public int dividir(int val1, int val2)
        {
            int res = val1 / val2;
            addHistorico(res);
            return res;
        }

        public List<string> historico()
        {
            historicoOperacoes.RemoveRange(3, historicoOperacoes.Count - 3);
            return historicoOperacoes;
        }

        public void addHistorico(int val)
        {
            historicoOperacoes.Insert(0, $"RES: {val} - {data}");
        }
    }
}
