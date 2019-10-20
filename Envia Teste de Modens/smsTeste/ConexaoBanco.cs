using System;
using System.Data.SqlClient;

namespace smsTeste
{
    class ConexaoBanco
    {

        // representa a conexão com o banco
        private static SqlConnection conn = null;

        // método que puxa os parametros
        public static SqlConnection conectarBanco()
        {
            //cria string de conexao
            string connString = "SERVER =  ; USER ID =; PASSWORD = ; DATABASE =";
            // vamos criar a conexão
            conn = new SqlConnection(connString);
            
            // a conexão foi feita com sucesso?
            try
            {
                // abre a conexão e a devolve ao chamador do método
                conn.Open();
            }
            catch (SqlException sqle)
            {
                throw new Exception("Falha ao tentar se conectar com o banco de dados.\n Detalhes: " + sqle.Message);
            }

            return conn;
        }

        //fechar conexao
        public static void desconectarBanco()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
