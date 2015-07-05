using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace carrinhoDeCompras
{
    class DbClass
    {
        private const string server = "(LocalDB)\\v11.0";
        private string database = Environment.CurrentDirectory + "\\dbloja.mdf;";
        private const string uid = null;
        private const string password = null;


        public SqlConnection abrir()
        {
            string connString = "Data Source=" + server + ";AttachDbFilename=" + database + "Integrated Security=True;Connect Timeout=30;";
            SqlConnection conexao = new SqlConnection(connString);
            return conexao;
        }

        public SqlDataReader selecionar(string tabela, string coluna = "*", string spColuna = null, string op = null, string valor = null)
        {
            string comando = "SELECT " + coluna + " FROM " + tabela;
            if(spColuna != null){
                comando = comando + " WHERE " + spColuna + " " + op + " '" + valor + "'";
            }
            comando+=";";
           SqlConnection conexao = abrir();
            try { 
            conexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO: " + ex.Message);
            }
            SqlCommand cmd = new SqlCommand(comando, conexao);
            try
            {
                SqlDataReader rdm = cmd.ExecuteReader();
                Console.WriteLine(comando);
                return rdm;
            }
            catch (Exception ex) { throw new Exception("ERRO:"+ ex.Message);}
            conexao.Close();
           
        }

        public bool deletar(string tabela, string spColuna, string valor)
        {
            string comando = "DELETE FROM "+tabela+" WHERE "+spColuna+ " = "+valor+";";
            SqlConnection conn = abrir();
            try
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = comando;
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO: " + ex.Message);
                return false;
            }
            conn.Close();
            
        }

        public bool inserir(string tabela, string[] valores, string[]colunas = null)
        {
            if (colunas != null)
            {
                tabela = tabela+"(" + string.Join(", ", colunas) + ") ";
            }
            string valor = string.Join("', '", valores);
            string comando = "INSERT INTO " + tabela + " VALUES(" + valor + ");";

            SqlConnection conn = abrir();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = comando;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO: " + ex.Message);
            }
            conn.Close();
        }
        public bool update(string tabela, string[] colunas, string[] valores, string spColuna, string valor){
            string[] preComm = new string[colunas.Length];
            foreach (string coluna in colunas)
            {
                preComm[Array.IndexOf(colunas, coluna)] = coluna + " = '" + valores[Array.IndexOf(colunas, coluna)]+"'";
                
            }
            string comando ="UPDATE "+tabela+" SET " + string.Join(", ", preComm)+" WHERE "+spColuna+" = "+valor+";";
            
           SqlConnection conn = abrir();
            try
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = comando;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO: " + ex.Message);
                return false;
            }
            conn.Close();
        }
    }
}
