using Model.Entity;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Model.DAO.Especifico
{
	public class BlocoDAO
	{
        #region Observa��es

        //Por padr�o, todas as buscas ser�o WHERE STS_ATIVO = 1, exceto a verifica��o se j� existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. N�o vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

		public bool cadastra(Bloco bloco)
		{
            query = null;
            CondominioDAO cond = new CondominioDAO();
            try
            {
                query = "INSERT INTO BLOCO (IDENTIFICACAO, QTD_ANDARES, ID_COND, QTD_UNIDADES, STS_ATIVO) VALUES ("
                    + bloco.nome + ", " + (bloco.qtAndares).ToString() + ", " + (cond.buscaNome()).ToString()
                    + ", " + (bloco.qtApto).ToString() + ", 1)";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public List<Bloco> buscaPorNome(string nome)
		{
            query = null;
            List<Bloco> lstBloco = new List<Bloco>();
            try
            {
                query = "SELECT B.IDENTIFICACAO, B.QTD_ANDARES, C.ID_COND, B.QTD_UNIDADES FROM BLOCO AS B "
                         + " INNER JOIN CONDOMINIO AS C ON B.ID_COND = C.ID_COND "
                         + " WHERE B.STS_ATIVO = 1 AND B.IDENTIFICACAO LIKE '%" + nome + "%'";
                lstBloco.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstBloco;	
        }

		public List<Bloco> busca()
		{
            query = null;
            List<Bloco> lstBloco = new List<Bloco>();
            try
            {
                query = "SELECT B.IDENTIFICACAO, B.QTD_ANDARES, C.NOME, B.QTD_UNIDADES FROM BLOCO AS B "
                        + " INNER JOIN CONDOMINIO AS C ON C.ID_COND = B.ID_COND"
                         + " WHERE B.STS_ATIVO = 1";
                lstBloco.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstBloco;		
        }

        public bool altera(Bloco bloco)
        {
            query = null;
            try
            {
                query = "UPDATE BLOCO SET IDENTIFICACAO = '" + bloco.nome + "', QT_ANDARES = " + (bloco.qtAndares).ToString()
                        + " WHERE ID_BLOCO = " + (bloco.id_bloco).ToString();
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE BLOCO SET STS_ATIVO = 0 WHERE ID_BLOCO = " + id.ToString();
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }	
        }

        #endregion

        #region M�todos

        public Bloco setarObjeto(SqlDataReader dr)
        {
            Bloco obj = new Bloco();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "ID_BLOCO":
                            obj.id_bloco = Convert.ToInt32(dr[idx]); 
                            break;
                        case "IDENTIFICACAO":
                            obj.nome = Convert.ToString(dr[idx]);
                            break;
                        case "QTD_ANDARES":
                            obj.qtAndares = Convert.ToInt32(dr[idx]);
                            break;
                        case "QTD_UNIDADES":
                            obj.qtApto = Convert.ToInt32(dr[idx]);
                            break;
                        case "NOME":
                            obj.condominio.nome = Convert.ToString(dr[idx]);  //Verificar esse objeto...
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return obj;
        }

        #endregion

	}

}

