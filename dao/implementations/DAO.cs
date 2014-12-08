using CentreLocationOutils.db;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using System;
using System.Data;
using System.Data.Common;

namespace CentreLocationOutils.dao.implementations 
{
    public class DAO
    {
        private dynamic dtoClass;

        //protected DAO(dynamic dtoClass)
        //    : base()
        //{
        //    if (dtoClass == null)
        //    {
        //        throw new InvalidDTOClassException("La classe de DTO ne peut être null");
        //    }
        //    setDtoClass(dtoClass);
        //}

        protected DAO() :base() { }

        protected dynamic getDtoClass()
        {
            return this.dtoClass;
        }

        private void setDtoClass(dynamic dtoClass)
        {
            this.dtoClass = dtoClass;
        }

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
                DbCommand command = connection.getConnection().CreateCommand();
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
