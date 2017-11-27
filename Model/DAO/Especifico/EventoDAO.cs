using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;

namespace Model.DAO.Especifico
{
	public class EventoDAO
	{
        #region Observa��es

        //Por padr�o, todas as buscas ser�o WHERE STS_ATIVO = 1, exceto a verifica��o se j� existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. N�o vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

		public bool cadastraEvento(Evento ev)
		{
            query = null;
            try
            {
                query = "INSERT INTO EVENTO (TITULO, ID_UNIDADE, STS_ATIVO) VALUES ('"
                        + ev.descEvento + "', " + ev.unidade.id_unidade.ToString() 
                        + ", 1;";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            } 
		}

        public bool cadastraAreaEvento(Evento ev)
        {
            query = null;
            try
            {
                query = "INSERT INTO AREA_EVENTO (ID_EVENTO, ID_AREA, STS_ATIVO) VALUES ("
                        + ev.id_evento.ToString() + ", " + ev.area.id_area.ToString() + ", 1;";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Evento> buscaPorData(DateTime dt1, DateTime dt2)
		{
	        return	
        }		

		public List<Evento> buscaPorArea(Area area)
		{
	        return	
        }

		public List<Evento> buscaPorResponsavel(string resp)
		{
	        return	
        }	

		public List<Evento> buscaPorUnidade(Unidade unidade)
		{
	        return	
        }			

		public List<Evento> busca()
		{
	        return	
        }

		public bool remove()
		{
	        return	
        }

	}

}

