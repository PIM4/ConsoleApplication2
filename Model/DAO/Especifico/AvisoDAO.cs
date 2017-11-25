using Model.Entity;
using System.Collections.Generic;
using System;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;

namespace Model.DAO.Especifico  
{
	public class AvisoDAO
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

        public bool cadastra(Aviso aviso)
		{
            query = null;

            try
            {
                query = "INSERT INTO AVISO (TITULO, DESCRICAO, DATA, ID_COND, STS_ATIVO) VALUES ('" + aviso.titulo + "', '"
                        + aviso.descricao + "', '" + (aviso.data).ToString() + "', "+ (aviso.cond.id_cond).ToString() + ", 1);";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
		}

		public List<Aviso> buscaPorData(DateTime dtinicio, DateTime dtfinal)
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.ID_AVISO, A.TITULO, A.DESCRICAO, A.DATA, C.NOME as [Aviso] FROM AVISO AS A " 
                        + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "                     
                        + " WHERE A.STS_ATIVO = 1 AND DATA BETWEEN '" + dtinicio 
                        + "' AND '" + (dtfinal).ToString() + "';";        
                lstAviso.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

		public List<Aviso> buscaPorTitulo(string titulo)
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.TITULO, A.DESCRICAO, A.DATA, C.NOME FROM AVISO AS A "
                         + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "
                         + " WHERE A.STS_ATIVO = 1 AND A.TITULO LIKE '%" + titulo + "%'";   
                lstAviso.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

		public List<Aviso> buscaPorCondominio(Condominio condominio)
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.TITULO, A.DESCRICAO, A.DATA, C.NOME FROM AVISO AS A "
                        + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "
                        + " WHERE A.STS_ATIVO = 1 AND C.NOME LIKE '%" + condominio + "%'";   
                lstAviso.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

		public List<Aviso> busca()      //Tirei o parametro condominio pq se n�o ia ficar identico ao m�todo buscaPorCondominio()
		{
            query = null;
            List<Aviso> lstAviso = new List<Aviso>();
            try
            {
                query = "SELECT A.TITULO, A.DESCRICAO, A.DATA, C.NOME FROM AVISO AS A "
                        + " INNER JOIN CONDOMINIO AS C ON A.ID_COND = C.ID_COND "
                        + " WHERE A.STS_ATIVO = 1";
                lstAviso.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstAviso;
        }

        public bool altera(Aviso aviso)
        {
            query = null;
            try
            {   //N�o vai alterar data do aviso. Lembrar de bloquear o campo.
                query = "UPDATE AVISO SET TITULO = '" + aviso.titulo + "', DESCRICAO = '" + aviso.descricao + "' WHERE ID_AVISO = " 
                        + (aviso.id_aviso).ToString();
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
                query = "UPDATE AVISO SET STS_ATIVO = 0 WHERE ID_AVISO = " + id.ToString();
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

        public Aviso setarObjeto(SqlDataReader dr)
        {
            Aviso obj = new Aviso();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "TITULO":
                            obj.titulo = Convert.ToString(dr[idx]);
                            break;
                        case "DESCRICAO":
                            obj.descricao = Convert.ToString(dr[idx]);
                            break;
                        case "DATA":
                            obj.data = Convert.ToDateTime(dr[idx]);
                            break;
                        case "ID_AVISO":
                            obj.id_aviso = Convert.ToInt32(dr[idx]);  
                            break;
                        case "NOME":
                            obj.nome_cond = Convert.ToString(dr[idx]);
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

