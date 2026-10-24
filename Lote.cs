
using System;

namespace Medicamentos
{
    public class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id
        {
            get { return id; }
        }

        public int Qtde
        {
            get { return qtde; }
            set { qtde = value; }
        }

        public DateTime Venc
        {
            get { return venc; }
        }

        public Lote()
        {
            id = 0;
            qtde = 0;
            venc = DateTime.MinValue;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        public override string ToString()
        {
            return id + "-" + qtde + "-" +
                   venc.ToString("dd/MM/yyyy");
        }
    }
}
