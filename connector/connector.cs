using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace teste5.connector
{
    public class Connector
    {

        private string host = @".\SQLEXPRESS";
        private string usuario = "test";
        private string senha = "123";
        private string banco = "teste";
        public SqlConnection conexao = null;
        public SqlConnection getConection()
        {
            try
            {
                conexao = new SqlConnection($"Data Source={host};DATABASE={banco};UID={usuario};PWD={senha};");
                conexao.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return conexao;

        }
        public void closeConnection()
        {
            conexao.Close();
            conexao.Dispose();
        }




    }
}