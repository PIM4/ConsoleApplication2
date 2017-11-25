using Model.Entity;
using System;

namespace Model.Entity
{
	public class ContaReceber
	{
		public Condominio condominio{get;set;}
		public Unidade unidade{get;set;}
		public DateTime data{get;set;}
		public string observacao{set;get;}
		public float valor{get;set;}

		public ContaReceber(Condominio condominio, float valor, Unidade uni, float valor)
		{

		}
	}

}

