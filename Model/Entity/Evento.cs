using System;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Entity
{
	public class Evento
	{
		public string descEvento{get;set;}
		public Unidade unidade{get;set;}
		public List<Area> area{get; set;}
		public int tempoMinParaReserva{get;set;}
		public int limitadorDeAreas{get; set;}
		public string responsavel{get;set;}
		public DateTime data{get;set;}

		public Evento(string descEvento, Unidade unidade, int tempMin, string responsavel, DateTime data)
		{

		}
	}

}

