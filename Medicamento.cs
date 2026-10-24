
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medicamentos
{
    public class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
        }

        public string Laboratorio
        {
            get { return laboratorio; }
        }

        public Queue<Lote> Lotes
        {
            get { return new Queue<Lote>(lotes); }
        }

        public Medicamento()
        {
            id = 0;
            nome = "";
            laboratorio = "";
            lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome,
                           string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }

        public int qtdeDisponivel()
        {
            int total = 0;

            foreach (Lote lote in lotes)
            {
                total += lote.Qtde;
            }

            return total;
        }

        public void comprar(Lote lote)
        {
            if (lote == null || lote.Qtde <= 0)
            {
                throw new ArgumentException(
                    "O lote deve possuir quantidade positiva.");
            }

            // Ordena os lotes pelo vencimento mais próximo.
            List<Lote> lista = lotes.ToList();

            lista.Add(lote);

            lista = lista.OrderBy(l => l.Venc).ToList();

            lotes = new Queue<Lote>(lista);
        }

        public bool vender(int qtde)
        {
            // Não permite venda de quantidade inválida
            // ou superior ao estoque disponível.
            if (qtde <= 0 || qtde > qtdeDisponivel())
            {
                return false;
            }

            int restante = qtde;

            while (restante > 0)
            {
                Lote lote = lotes.Peek();

                if (lote.Qtde <= restante)
                {
                    restante -= lote.Qtde;
                    lotes.Dequeue();
                }
                else
                {
                    lote.Qtde -= restante;
                    restante = 0;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return id + "-" + nome + "-" +
                   laboratorio + "-" + qtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Medicamento))
            {
                return false;
            }

            Medicamento outro = (Medicamento)obj;

            return id == outro.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
