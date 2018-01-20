using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Ports;
using WebApplication3.App.Model;

namespace WebApplication3.App.Banco
{
    public class DispositivoBanco
    {

        public DispositivoBanco()
        {
            
        }

        public List<Arduino> buscarTodosId()
        {
            string consulta = "SELECT id FROM dispositivo";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(consulta, conexao.ObterConexao());
            var objDataReader = objCommand.ExecuteReader();
            var listaId = new List<Arduino>();
            if (objDataReader.HasRows)
            {
                    
                while (objDataReader.Read())
                {
                        
                    var arduino = new Arduino();
                    arduino.Id = int.Parse(objDataReader["id"].ToString());
                    listaId.Add(arduino);
                }
            }
            conexao.ObterConexao().Close();
            return listaId;
        }

        public List<Arduino> ConsultarArduino()
        {
            string consulta = "SELECT * FROM dispositivo";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(consulta, conexao.ObterConexao());
            var objDataReader = objCommand.ExecuteReader();
            var listaArduino = new List<Arduino>();
            if (objDataReader.HasRows)
            {
                    
                while (objDataReader.Read())
                {
                        
                    var arduino = new Arduino();
                    arduino.Id = int.Parse(objDataReader["id"].ToString());
                    arduino.Temperatura = objDataReader["temperatura"].ToString();
                    listaArduino.Add(arduino);
                }
            }
            conexao.ObterConexao().Close();
            return listaArduino;
        }

        public List<Arduino> consultarTemperaturaPorIntervalo(string d1, string d2)
        {

            string sql = "SELECT * FROM dispositivo WHERE dataRegistro BETWEEN @t1 AND @t2;";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            objCommand.Parameters.AddWithValue("@t1", d1);
            objCommand.Parameters.AddWithValue("@t2", d2);
            var objDataReader = objCommand.ExecuteReader();
            var listaArduino = new List<Arduino>();
            if (objDataReader.HasRows)
            {
                    
                while (objDataReader.Read())
                {
                        
                    var arduino = new Arduino();
                    arduino.Id = int.Parse(objDataReader["id"].ToString());
                    arduino.Temperatura = objDataReader["temperatura"].ToString();
                    arduino.DataRegistro = objDataReader["dataRegistro"].ToString();
                    listaArduino.Add(arduino);
                }
            }
            conexao.ObterConexao().Close();
            return listaArduino;
        }

        public int obterIdUltimaTemperatura()
        {
            
            string sql = "SELECT MAX(id) FROM dispositivo";
            int id = 0;
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            SqlDataReader reader = objCommand.ExecuteReader();
            while (reader.Read())
            {

                id = reader.GetInt32(0);
            }
            conexao.ObterConexao().Close();
            reader.Close();
            return id;
        }

        public String obterTemperatura()
        {
            
            int id = obterIdUltimaTemperatura();
            string sql = "SELECT temperatura FROM dispositivo WHERE id=@id";
            string temperatura = "";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            objCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = objCommand.ExecuteReader();
            while (reader.Read())
            {

                temperatura = reader.GetString(0);
            }
            conexao.ObterConexao().Close();
            reader.Close();
            return temperatura + "°";
        }
    }
}