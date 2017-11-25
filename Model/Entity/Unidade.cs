using Model.Entity;
using System;

namespace Model.Entity
{
	public class Unidade
	{
		public string identificacao{get;set;}
		public Proprietario proprietario{get;set;}
		public Bloco bloco{get;set;}
		public int vagas{get;set;}
		
		public Unidade(Bloco bl, string identificacao, int vagas, Proprietario proprietario)
		{

		}

	}

}

