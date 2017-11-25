using Model.Entity;
using System;

namespace Model.Entity
{
	public class Correspondencia
	{
        public int id_correspondencia { get; set; }
		public string descCorespondencia{get;set;}
		public int destinatario{get;set;}
		public DateTime dtEntrada{get;set;}
		public DateTime dtSaida{get;set;}
		public int responsavelRetirada{get;set;}    //Mudei o tipo
		public string obsDeCancelamento{get;set;}

		public Correspondencia(string descCorespondencia, string destinatario, DateTime dtEntrada)
		{
			
		}
        public Correspondencia()
        {

        }

		public void entregaCorrespondencia(DateTime dtSaida, string responsavelRetirada)
		{

		}
	}

}

