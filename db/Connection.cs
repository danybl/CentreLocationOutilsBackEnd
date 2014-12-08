using CentreLocationOutils.exception.db;
using System;
using System.Data.Common;

namespace CentreLocationOutils.db
{
    public class Connection
    {
        //private OracleConnection connection;

        DbProviderFactory provider = DbProviderFactories.GetFactory("System.Data.OracleClient");
        DbConnection connection;

        private static   string TYPE_SERVEUR_LOCAL = "local";

        //private static   string TYPE_SERVEUR_DISTANT = "distant";

        //private static   string TYPE_SERVEUR_POSTGRES = "postgres";

        //private static   string TYPE_SERVEUR_ACCESS = "access";

        //private static   string SERVEUR_DISTANT_CLASS = "com.mysql.jdbc.Driver";

        private static   string SERVEUR_LOCAL_CLASS = "oracle.jdbc.driver.OracleDriver";

        //private static   string SERVEUR_POSTGRES_CLASS = "org.postgresql.Driver";

        //private static   string SERVEUR_ACCESS_CLASS = "org.postgresql.Driver";

        //private static   string SERVEUR_DISTANT_URL = "jdbc:mysql://localhost:3306/";

        private static   string SERVEUR_LOCAL_URL = "jdbc:oracle:thin:@localhost:1521:";

        //	private static final string SERVEUR_DISTANT_URL = "jdbc:oracle:thin:@collegeahunstic.info:1521:";

        //private static   string SERVEUR_POSTGRES_URL = "jdbc:postgresql:";

        //private static   string SERVEUR_ACCESS_URL = "jdbc:postgresql:";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeServeur"></param>
        /// <param name="nomUtilisateur"></param>
        /// <param name="motPasse"></param>
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
                    connection = provider.CreateConnection();
                    connection.ConnectionString = @"Data Source=xe;User ID=" + nomUtilisateur + ";Password=" + motPasse + ";Unicode=True; Min Pool Size=10; Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5;Decr Pool Size=2";
                }

            }
            catch (DbException dbException)
            {
                throw new ConnectionException(dbException.Message);
            }
        }

        /// <summary>
        /// Getter de la variable d'insctance
        /// </summary>
        /// <returns>La variable d'instance</returns>
        public DbConnection getConnection()
        {
            return this.connection;
        }
        /// <summary>
        /// Setter de la variable d'instance
        /// </summary>
        /// <param name="connection">Valeur de la variable d'instance</param>
        private void setConnection(DbConnection connection)
        {
            this.connection = connection;
        }


        /// <summary>
        /// Effectue un Close sur la connexion
        /// </summary>
        public void close()
        {
            try
            {
                getConnection().Close();
                Console.WriteLine("\nConnexion fermée"
                    + " "
                    + getConnection());
            }
            catch (DbException dbException)
            {
                throw new ConnectionException(dbException.Message);
            }

        }

    }
}
