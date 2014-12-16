using CentreLocationOutils.exception.db;
using System;
//using System.Data.Common;
//using Oracle.DataAccess.Client;
using Oracle.DataAccess.Client;

namespace CentreLocationOutils.db
{
    /// <summary>
    /// Classe de connexion
    /// </summary>
    public class Connection
    {
        //private OracleConnection connection;

        //DbProviderFactory provider = DbProviderFactories.GetFactory("Oracle.DataAccess.Client");
        //DbConnection connection;
        //OracleClientFactory provider = OracleClientFactory.Instance;
        private OracleClientFactory oracleProvider = OracleClientFactory.Instance;
        public OracleConnection ConnectionOracle { get; set; }

        private static   string TYPE_SERVEUR_LOCAL = "local";

        //private static   string TYPE_SERVEUR_DISTANT = "distant";

        //private static   string TYPE_SERVEUR_POSTGRES = "postgres";

        //private static   string TYPE_SERVEUR_ACCESS = "access";

        //private static   string SERVEUR_DISTANT_CLASS = "com.mysql.jdbc.Driver";

        //private static   string SERVEUR_LOCAL_CLASS = "oracle.jdbc.driver.OracleDriver";

        //private static   string SERVEUR_POSTGRES_CLASS = "org.postgresql.Driver";

        //private static   string SERVEUR_ACCESS_CLASS = "org.postgresql.Driver";

        //private static   string SERVEUR_DISTANT_URL = "jdbc:mysql://localhost:3306/";

        //private static   string SERVEUR_LOCAL_URL = "jdbc:oracle:thin:@localhost:1521:";

        //	private static final string SERVEUR_DISTANT_URL = "jdbc:oracle:thin:@collegeahunstic.info:1521:";

        //private static   string SERVEUR_POSTGRES_URL = "jdbc:postgresql:";

        //private static   string SERVEUR_ACCESS_URL = "jdbc:postgresql:";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeServeur"></param>
        /// <param name="nomUtilisateur"></param>
        /// <param name="motPasse"></param>
        /// <inheritdoc />
        public Connection(string typeServeur,
            //string schema,
        string nomUtilisateur,
        string motPasse)
        {
            //string urlBD = null;

            try
            {
                // DbConnectionStringBuilder csb = new DbConnectionStringBuilder();
                if (typeServeur.Equals(Connection.TYPE_SERVEUR_LOCAL))
                {
                    //connection = provider.CreateConnection();
                    //connection.ConnectionString = @"Data Source=xe;User ID=" + nomUtilisateur + ";Password=" + motPasse + ";"; /*Min Pool Size=10; Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5;Decr Pool Size=2";*/
                    ConnectionOracle = new OracleConnection();
                    ConnectionOracle.ConnectionString = @"Data Source=xe;User ID=" + nomUtilisateur + ";Password=" + motPasse + ";Min Pool Size=10; Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5;Decr Pool Size=2;";
                }

            }
            catch (OracleException dbException)
            {
                throw new ConnectionException(dbException.Message);
            }
        }

        /// <inheritdoc />
        public void close()
        {
            try
            {
                ConnectionOracle.Close();
                Console.WriteLine("\nConnexion fermée"
                    + " "
                    + ConnectionOracle);
            }
            catch (OracleException dbException)
            {
                throw new ConnectionException(dbException.Message);
            }

        }

    }
}
