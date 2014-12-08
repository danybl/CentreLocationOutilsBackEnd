using System.Collections.Generic;
using CentreLocationOutils.db;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.dao;
using System.Data;
using CentreLocationOutils.dto;
using System.Data.Common;
using System.Data.OracleClient;
using CentreLocationOutils.dao.interfaces;

namespace CentreLocationOutils.dao.implementations
{
    public class CategorieDAO : DAO, ICategorieDAO
    {
        private static string ADD_REQUEST = "INSERT INTO categorie (idCategorie, nom, description) "
      + "VALUES (:idCategorie, :idCategorie, :nom, :numSerie, :dateAqcuisition, :prixLocation, :description)";

        private static string READ_REQUEST = "SELECT idCategorie, nom, description "
           + "FROM categorie "
           + "WHERE idCategorie = :idCategorie";

        private static string UPDATE_REQUEST = "UPDATE categorie "
            + "SET idCategorie = :idCategorie, nom = :nom, description = :description "
            + "WHERE idCategorie = :idCategorie";

        private static string DELETE_REQUEST = "DELETE FROM categorie "
            + "WHERE idCategorie = :idCategorie";

        private static string GET_ALL_REQUEST = "SELECT idCategorie, nom, description "
            + "FROM categorie";

        private static string FIND_BY_NOM = "SELECT idCategorie, nom, description "
            + "FROM categorie "
            + "where nom like :nom";

        private static string CREATE_PRIMARY_KEY = "SELECT SEQ_CATEG_ID.NEXTVAL from DUAL";

        //public CategorieDAO(CategorieDTO categorieDTOClass) : base(categorieDTOClass) { }
        public CategorieDAO() : base() { }

        /// <inheritdoc />
        public void add(Connection connection,
        CategorieDTO categorieDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (categorieDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            //if (!dto.GetType().Equals(getDtoClass()))
            //{
            //    throw new InvalidDTOClassException("Le DTO doit être un "
            //        + getDtoClass().getName());
            //}
            //CategorieDTO categorieDTO = categorieDTO;//(CategorieDTO) dto;
            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = CategorieDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idCategorie", categorieDTO.IdCategorie));
                command.Parameters.Add(new OracleParameter(":nom", categorieDTO.Nom));
                command.Parameters.Add(new OracleParameter(":description", categorieDTO.Description));

                command.ExecuteNonQuery();
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }

        /// <inheritdoc />
        public CategorieDTO get(Connection connection,
        string primaryKey)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (primaryKey == null)
            {
                throw new InvalidPrimaryKeyException("La clef primaire ne peut être null");
            }
            string idCategorie = primaryKey.ToString();
            CategorieDTO categorieDTO = null;
            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = CategorieDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idCategorie", idCategorie));

                    DbDataReader dataReader = command.ExecuteReader();
                    if (dataReader.NextResult())
                    {
                        categorieDTO = new CategorieDTO();
                        categorieDTO.IdCategorie = dataReader.GetString(1);
                        categorieDTO.Nom = dataReader.GetString(2);
                        categorieDTO.Description = dataReader.GetString(3);

                    }
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
            return categorieDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection,
        CategorieDTO categorieDTO)
        {
            if (connection == null)
            {
                //throw new InvalidHibernateSessionException("La connexion ne peut être null");
            }
            if (categorieDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            //if (!dto.GetType().Equals(getDtoClass()))
            //{
            //    throw new InvalidDTOClassException("Le DTO doit être un "
            //        + getDtoClass().getName());
            //}
            //CategorieDTO categorieDTO = (CategorieDTO)dto;
            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = CategorieDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":nom", categorieDTO.Nom));
                command.Parameters.Add(new OracleParameter(":description", categorieDTO.Description));
                command.Parameters.Add(new OracleParameter(":idCategorie", categorieDTO.IdCategorie));

                command.ExecuteNonQuery();
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }

        /// <inheritdoc />
        public void delete(Connection connection,
        CategorieDTO categorieDTO)
        {
            if (connection == null)
            {
                //throw new InvalidHibernateSessionException("La connexion ne peut être null");
            }
            if (categorieDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            //if (!dto.GetType().Equals(getDtoClass()))
            //{
            //    throw new InvalidDTOClassException("Le DTO doit être un "
            //        + getDtoClass().getName());
            //}
           // CategorieDTO categorieDTO = (CategorieDTO)dto;

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = CategorieDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idCategorie", categorieDTO.IdCategorie));

                command.ExecuteNonQuery();
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }

        /// <inheritdoc />
        public List<CategorieDTO> getAll(Connection connection,
        string sortByPropertyName)
        {
            if (connection == null)
            {
                //throw new InvalidHibernateSessionException("La connexion ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<CategorieDTO> categories = new List<CategorieDTO>();

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = CategorieDAO.GET_ALL_REQUEST;

                DbDataReader dataReader = command.ExecuteReader();
                CategorieDTO categorieDTO= null;

                if (dataReader.NextResult())
                {
                    categorieDTO = new CategorieDTO();
                    do{
                        command.Parameters.Add(new OracleParameter(":idCategorie", categorieDTO.IdCategorie));
                        command.Parameters.Add(new OracleParameter(":nom", categorieDTO.Nom));
                        command.Parameters.Add(new OracleParameter(":description", categorieDTO.Description));
                        categories.Add(categorieDTO);
                    }
                        while(dataReader.NextResult());
                    }
                }catch(DbException dbException){
                    throw new DAOException(dbException);
                }
            return categories;
        }

        /// <inheritdoc />
        public List<CategorieDTO> findByNom(Connection connection, string nom,
        string sortByPropertyName)
        {
            if (connection == null)
            {
                //throw new InvalidHibernateSessionException("La connexion ne peut être null");
            }
            if (nom == null)
            {
                throw new InvalidCriterionException("Le nom ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<CategorieDTO> categories = new List<CategorieDTO>();

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = CategorieDAO.FIND_BY_NOM;

                DbDataReader dataReader = command.ExecuteReader();
                CategorieDTO categorieDTO = null;

                if (dataReader.NextResult())
                {
                    categorieDTO = new CategorieDTO();
                    do
                    {
                        categorieDTO.IdCategorie = dataReader.GetString(1);
                        categorieDTO.Nom = dataReader.GetString(2);
                        categorieDTO.Description = dataReader.GetString(3);
                        categories.Add(categorieDTO);
                    }
                    while (dataReader.NextResult());
                }
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
            return categories;
        }
    }
}
