using Model.Entity;
using System;

namespace Model.Entity
{
	public class ContaReceber
	{
        public ContaReceber()
        {

        }

        public ContaReceber(Condominio condominio, float valor, Unidade uni)
        {

        }

        public int id_cr { get; set; }

        public string observacao { set; get; }

        public float valor { get; set; }

        public DateTime data { get; set; }

		public Condominio condominio{ get; set; }

		public Unidade unidade{ get; set; }

	}

}

