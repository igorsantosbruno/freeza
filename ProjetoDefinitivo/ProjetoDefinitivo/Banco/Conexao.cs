using System;
using System.CodeDom;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.App.Banco
{
    public class Conexao
    {

        private SqlConnection objConexao;
        private string strStringConexao;
        
        public Conexao()
        {

            strStringConexao = "Server=freeza.database.windows.net;Database=dbfreeza;Uid=freeza;Pwd=@Bandtec;";
            objConexao = new SqlConnection(strStringConexao);
        }

        public SqlConnection ObterConexao()
        {

            return objConexao;
        }
    }
}