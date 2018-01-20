using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication3.App.Model;

namespace WebApplication3.App.Banco
{
    public class UsuarioBanco
    {

        public UsuarioBanco()
        {
            
            
        }

        public List<Usuario> buscarUsuario()
        {
            string sql = "SELECT id,nome_usuario FROM usuario;";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            var objDataReader = objCommand.ExecuteReader();
            var listaUsuario = new List<Usuario>();
            if (objDataReader.HasRows)
            {
                    
                while (objDataReader.Read())
                {
                        
                    var usuario = new Usuario();
                    usuario.Id = int.Parse(objDataReader["id"].ToString());
                    usuario.Nome = objDataReader["nome_usuario"].ToString();
                    listaUsuario.Add(usuario);
                }
            }
            conexao.ObterConexao().Close();
            return listaUsuario;
        }

        public string validarLogin(string usuario, string senha)
        {

            try
            {
                string nomeUsuario;
                string consulta = "SELECT nome_usuario" +
                                  " FROM usuario" +
                                  " WHERE nome_usuario=@usuario" +
                                  " AND senha=@senha";
                Conexao conexao = new Conexao();
                conexao.ObterConexao().Open();
                SqlCommand objCommand = new SqlCommand(consulta, conexao.ObterConexao());
                objCommand.Parameters.AddWithValue("@usuario", usuario);
                objCommand.Parameters.AddWithValue("@senha", senha);
                var objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        nomeUsuario = objDataReader["nome_usuario"].ToString();
                        return nomeUsuario;
                    }
                }
                    
                return "";
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        
        public string obterIdUsuario(string usuario)
        {

            try
            {
                string id;
                string consulta = "SELECT id" +
                                  " FROM usuario" +
                                  " WHERE nome_usuario=@usuario";
                Conexao conexao = new Conexao();
                conexao.ObterConexao().Open();
                SqlCommand objCommand = new SqlCommand(consulta, conexao.ObterConexao());
                objCommand.Parameters.AddWithValue("@usuario", usuario);
                var objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {

                        id = objDataReader["id"].ToString();
                        return id;
                    }
                }
                    
                return "";
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        
        public bool validarNomeUsuario(string nome)
        {

            try
            {
                string consulta = "SELECT id" +
                                  " FROM usuario" +
                                  " WHERE nome_usuario=@nome";
                Conexao conexao = new Conexao();
                conexao.ObterConexao().Open();
                SqlCommand objCommand = new SqlCommand(consulta, conexao.ObterConexao());
                objCommand.Parameters.AddWithValue("@nome", nome);
                var objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)
                {

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool inserir(string nome, string senha) {

            string sql = "insert into usuario (nome_usuario,senha) values(@nome,@senha)";

            if (validarNomeUsuario(nome))
            {

                return false;
            }
            
               
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            objCommand.Parameters.AddWithValue("@nome", nome);
            objCommand.Parameters.AddWithValue("@senha", senha);
            objCommand.CommandType = System.Data.CommandType.Text;
            objCommand.ExecuteNonQuery();

            return true;
        }
        
        public bool deletar(int id)
        {

            string sql = "DELETE FROM usuario WHERE id = @id";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            objCommand.Parameters.AddWithValue("@id", id);
            try
            {
                objCommand.ExecuteNonQuery();
                conexao.ObterConexao().Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        
        public bool atualizarNomeUsuario(string nomeUsuario, int id)
        {

            string sql = "UPDATE usuario SET nome_usuario = @nomeUsuario WHERE id=@id";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            objCommand.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
            objCommand.Parameters.AddWithValue("@id", id);
            try
            {
                objCommand.ExecuteNonQuery();
                conexao.ObterConexao().Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        
        public bool atualizarSenha(string senha, int id)
        {

            string sql = "UPDATE usuario SET senha = @senha WHERE id=@id";
            Conexao conexao = new Conexao();
            conexao.ObterConexao().Open();
            SqlCommand objCommand = new SqlCommand(sql, conexao.ObterConexao());
            objCommand.Parameters.AddWithValue("@senha", senha);
            objCommand.Parameters.AddWithValue("@id", id);
            try
            {
                objCommand.ExecuteNonQuery();
                conexao.ObterConexao().Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

    }
}