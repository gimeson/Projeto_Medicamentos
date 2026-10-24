
using System.Collections.Generic;

namespace Medicamentos
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void adicionar(Medicamento medicamento)
        {
            if (medicamento != null &&
                pesquisar(medicamento).Id == 0)
            {
                listaMedicamentos.Add(medicamento);
            }
        }

        public bool deletar(Medicamento medicamento)
        {
            Medicamento encontrado = pesquisar(medicamento);

            if (encontrado.Id == 0)
            {
                return false;
            }

            if (encontrado.qtdeDisponivel() != 0)
            {
                return false;
            }

            listaMedicamentos.Remove(encontrado);

            return true;
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento item in listaMedicamentos)
            {
                if (item.Equals(medicamento))
                {
                    return item;
                }
            }

            return new Medicamento();
        }

        public List<Medicamento> listar()
        {
            return new List<Medicamento>(listaMedicamentos);
        }
    }
}
