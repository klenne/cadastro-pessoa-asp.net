using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using teste5.connector;

namespace teste5.model.model.dao
{
    public class TesteDAO
    {
        private Connector con = new Connector();
        private SqlCommand querry = null;

        public List<Teste> GetAllData()
        {

            List<Teste> testeList = new List<Teste>();

            try
            {
                querry = new SqlCommand("select * from teste", con.getConection());
                SqlDataReader dr = querry.ExecuteReader();
                while (dr.Read())
                {
                    Teste testModel = new Teste();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {

                        testModel.Id = (int)dr.GetValue(0);
                        testModel.Nome = dr.GetValue(1).ToString();

                    }
                    testeList.Add(testModel);

                }

                dr.Close();
                dr.Dispose();
                querry.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                con.closeConnection();
            }

            return testeList;
        }


        public List<Teste> GetData(string campo, string valor)
        {

            List<Teste> testeList = new List<Teste>();
          string sql = null;
            if (campo == "nome")
            {
                sql = $"select * from teste where {campo} LIKE'%{valor}%'";
            }
            else if (campo == "id")
            {
                sql = $"select * from teste where {campo}={valor}";
            }
                try
                {

                    querry = new SqlCommand(sql, con.getConection());
                    SqlDataReader dr = querry.ExecuteReader();
                    while (dr.Read())
                    {
                        Teste testModel = new Teste();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {

                            testModel.Id = (int)dr.GetValue(0);
                            testModel.Nome = dr.GetValue(1).ToString();

                        }
                        testeList.Add(testModel);

                    }

                    dr.Close();
                    dr.Dispose();
                    querry.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                finally
                {
                    con.closeConnection();
                }

            return testeList;
        }





        public void ExcluirRegistro(int id)
        {

            try
            {

                SqlDataAdapter dr = new SqlDataAdapter();
                dr.DeleteCommand = new SqlCommand($"DELETE FROM teste WHERE id = {id};", con.getConection());
                dr.DeleteCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                con.closeConnection();
            }



        }
        public void AtualizarRegistro(int id, string novoValor)
        {

            string sql = "UPDATE teste SET  nome= @Nome WHERE id = @Id;";
            SqlCommand command = new SqlCommand(sql, con.getConection());

            command.Parameters.AddWithValue("@Nome", novoValor);
            command.Parameters.AddWithValue("@Id", id);

            command.CommandType = CommandType.Text;
            try

            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                command.Dispose();
                con.closeConnection();
            }


        }



        public void InserirNovo(string nome)
        {

            string sql = "Insert Into teste values(@Nome);";
            SqlCommand command = new SqlCommand(sql, con.getConection());

            command.Parameters.AddWithValue("@Nome", nome);

            command.CommandType = CommandType.Text;
            try

            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                command.Dispose();
                con.closeConnection();
            }





        }









    }
}