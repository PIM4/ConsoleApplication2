using Model.Entity;
using System;

namespace Model.DAO.Configuracao
{
    public class Configuracoes
    {
        public string LeStringConexao()
        {
            //string strConexao = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\bruna\\Documents\\bancoTestePim.mdf;Integrated Security=True;Connect Timeout=30";
            string strConexao = null;
            try
            {
                strConexao = "Data Source=(localdb)\v11.0;Initial Catalog=SMARTDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;";
                //strConexao = "Server=(localdb)\\mssqllocaldb;Database=SMARTDB;Trusted_Connection=true;";
                //strConexao = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\\bruna\\Documents\\bancoTestePim.mdf;Integrated Security=True;Connect Timeout=30";
            }
            catch(Exception ex)
            {
                strConexao = null;
            }
            return strConexao;
        }
    }
}
