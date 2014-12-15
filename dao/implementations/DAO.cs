using CentreLocationOutils.db;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using System;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace CentreLocationOutils.dao.implementations 
{
    public class DAO
    {
        private dynamic dtoClass;

        /// <summary>
        /// Le DAO.
        /// </summary>
        protected DAO() :base() { }

        /// <inheritdoc />
        protected dynamic getDtoClass()
        {
            return this.dtoClass;
        }

        /// <inheritdoc />
        private void setDtoClass(dynamic dtoClass)
        {
            this.dtoClass = dtoClass;
        }

        /// <inheritdoc />
        protected static string getPrimaryKey(Connection connection,
        string createPrimaryKeyRequest)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (createPrimaryKeyRequest == null)
            {
                throw new InvalidPrimaryKeyRequestException("La requête de création de clef primaire ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = createPrimaryKeyRequest;
                DbDataReader dataReader = command.ExecuteReader();

                if (dataReader.NextResult())
                {
                    return dataReader.GetString(1);
                }
                throw new DAOException("Impossible de lire la séquence");

            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }
    }
}
