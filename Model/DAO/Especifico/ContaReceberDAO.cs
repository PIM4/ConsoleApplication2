using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;
using System.Data;

namespace Model.DAO.Especifico
{
	public class ContaReceberDAO
    {
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

        public bool cadastra(ContaReceber cr)
		{
            query = null;
            try
            {
                query = "INSERT INTO CONTA_RECEBER (DT_CONTA_RECEBER, VALOR, ID_COND, ID_UNIDADE, STS_ATIVO) VALUES ('"
                        + (cr.data).ToShortDateString() + "', " + (cr.valor).ToString() + ", " 
                        + (cr.condominio.id_cond).ToString()  + ", " + (cr.unidade.id_unidade).ToString() + ", 1;";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }	
        }

		public List<ContaReceber> buscaPorValor(int v1, int v2)
		{
            query = null;
            List<ContaReceber> lstCR = new List<ContaReceber>();
            try
            {
                query = "SELECT TC.DESCRICAO, F.RAZAO_SOCIAL, CP.VALOR, CP.DT_PAGTO FROM CONTA_PAGAR AS CP "
                        + "INNER JOIN TIPO_CONTA AS TC ON CP.ID_TIPO_CONTA = TC.ID_TIPO_CONTA "
                        + "INNER JOIN FORNECEDOR AS F ON CP.ID_FORNECEDOR = F.ID_FORNECEDOR "
                        + "WHERE CP.VALOR BETWEEN " + v1.ToString() + " AND " + v2.ToString() + " AND CP.STS_ATIVO = 1;";
                lstCR = setarObjeto(banco.MetodoSelect(query));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstCR;
        }

		public List<ContaReceber> buscaPorData(DateTime dt1, DateTime dt2)
		{
	return	}		

		public List<ContaReceber> buscaPorCondominio(Condominio condominio)
		{
	return	}		

		public List<ContaReceber> buscaPorUnidade(Unidade unidade)
		{
	return	}

		public List<ContaReceber> busca()
		{
	return	}

		public bool remove()
		{
	return	}
        
        #endregion


        #region Métodos

        public List<ContaReceber> setarObjeto(ContaReceber dr)
        {
            ContaPagar obj = new ContaPagar();
            List<ContaReceber> lstCR = new List<ContaReceber>();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.id_cp = Convert.ToInt32(dr["ID_CONTA_PAGAR"].ToString());
                        obj.valor = Convert.ToDecimal(dr["VALOR"].ToString());
                        obj.data = Convert.ToDateTime(dr["DT_PAGTO"].ToString());

                        obj.id_tipo = Convert.ToInt32(dr["ID_TIPO_CONTA"].ToString());
                        obj.desc_conta = Convert.ToString(dr["DESCRICAO"].ToString());

                        obj.fornecedor.id_fornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"].ToString());
                        obj.fornecedor.nomeEmpresa = Convert.ToString(dr["RAZAO_SOCIAL"].ToString());

                        obj.condominio.id_cond = Convert.ToInt32(dr["ID_COND"].ToString());

                        lstCP.Add(obj);
                    }
                }

                //for (int idx = 0; idx < dr.FieldCount; idx++)
                //{
                //    dr.GetName(idx).ToString();

                //    switch (dr.GetName(idx).ToUpper())
                //    {
                //        case "DESCRICAO":
                //            obj.desc_conta = Convert.ToString(dr[idx]);
                //            break;
                //        case "RAZAO_SOCIAL":
                //            obj.fornecedor.nomeEmpresa = Convert.ToString(dr[idx]);
                //            break;
                //        case "VALOR":
                //            obj.valor = Convert.ToDecimal(dr[idx]);
                //            break;
                //        case "DT_PAGTO":
                //            obj.data = Convert.ToDateTime(dr[idx]);
                //            break;
                //        case "ID_FORNECEDOR":
                //            obj.fornecedor.id_fornecedor = Convert.ToInt32(dr[idx]);
                //            break;
                //        case "ID_TIPO_CONTA":
                //            obj.id_tipo = Convert.ToInt32(dr[idx]);
                //            break;
                //    }
                //}
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lstCR;
        }

        #endregion
	}

}

