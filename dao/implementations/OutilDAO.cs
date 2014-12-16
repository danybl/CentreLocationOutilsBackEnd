using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace CentreLocationOutils.dao.implementations
{
    public class OutilDAO : DAO, IOutilDAO
    {
        private static   string ADD_REQUEST = "INSERT INTO outil (idOutil, idCategorie ,nom, numSerie, dateAqcuisition, prixLocation, description) "
      + "VALUES (:idOutil, :idCategorie, :nom, :numSerie, :dateAqcuisition, :prixLocation, :description)";

        private static string READ_REQUEST = "SELECT idOutil, idCategorie ,nom, numSerie, dateAqcuisition, prixLocation, description "
           + "FROM outil "
           + "WHERE idOutil = :idOutil";

        private static string UPDATE_REQUEST = "UPDATE outil "
            + "SET idCategorie = :idCategorie, nom = :nom, numSerie = :numSerie, dateAcquisition = :dateAcquisition, prixLocation = :prixLocation, description = :description "
            + "WHERE idOutil = :idOutil";

        private static string DELETE_REQUEST = "DELETE FROM outil "
            + "WHERE idOutil = :idOutil";

        private static string GET_ALL_REQUEST = "SELECT idOutil, idCategorie ,nom, numSerie, dateAqcuisition, prixLocation, description "
            + "FROM outil";

        private static string FIND_BY_NOM = "SELECT idOutil, idCategorie ,nom, numSerie, dateAqcuisition, prixLocation, description "
            + "FROM outil "
            + "where nom like :nom";

        private static string CREATE_PRIMARY_KEY = "SELECT SEQ_OUTIL_ID.NEXTVAL from DUAL";


        /// <summary>
        /// Crée le DAO de la table Outil <code>outil</code>
        /// </summary>
        /// <param name="outilDTOClass">La classe de outil DTO à utiliser</param>

        public OutilDAO() : base() { }

        /// <inheritdoc />
        public void add(Connection connection,
        OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = OutilDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idOutil", getPrimaryKey(connection, OutilDAO.CREATE_PRIMARY_KEY)));
                command.Parameters.Add(new OracleParameter(":idCategorie", outilDTO.CategorieDTO.IdCategorie));
                command.Parameters.Add(new OracleParameter(":nom", outilDTO.Nom));
                command.Parameters.Add(new OracleParameter(":numSerie", outilDTO.NumSerie));
                command.Parameters.Add(new OracleParameter(":dateAcquisition", outilDTO.DateAcquisition));
                command.Parameters.Add(new OracleParameter(":prixLocation", outilDTO.PrixLocation));
                command.Parameters.Add(new OracleParameter(":description", outilDTO.Description));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public OutilDTO get(Connection connection,
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
            OutilDTO outilDTO = null;
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = OutilDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idOutil", primaryKey));

                    OracleDataReader dataReader = command.ExecuteReader();
                    if (dataReader.NextResult())
                    {
                        outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(1);
                        CategorieDTO categorieDTO = new CategorieDTO();
                        categorieDTO.IdCategorie = dataReader.GetString(2);
                        outilDTO.CategorieDTO = categorieDTO;
                        outilDTO.Nom = dataReader.GetString(3);
                        outilDTO.NumSerie = dataReader.GetString(4); 
                        outilDTO.PrixLocation = dataReader.GetString(5);
                        outilDTO.DateAcquisition = dataReader.GetString(6);
                        outilDTO.Description = dataReader.GetString(7);

                    }
                    dataReader.Dispose();
                    command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return outilDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection,
        OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = OutilDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idCategorie", outilDTO.CategorieDTO.IdCategorie));
                command.Parameters.Add(new OracleParameter(":nom", outilDTO.Nom));
                command.Parameters.Add(new OracleParameter(":numSerie", outilDTO.NumSerie));
                command.Parameters.Add(new OracleParameter(":dateAcquisition", outilDTO.DateAcquisition));
                command.Parameters.Add(new OracleParameter(":prixLocation", outilDTO.PrixLocation));
                command.Parameters.Add(new OracleParameter(":description", outilDTO.Description));
                command.Parameters.Add(new OracleParameter(":idOutil", outilDTO.IdOutil));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public void delete(Connection connection,
        OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = OutilDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idOutil", outilDTO.IdOutil));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public List<OutilDTO> getAll(Connection connection,
        string sortByPropertyName)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<OutilDTO> outils = new List<OutilDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = OutilDAO.GET_ALL_REQUEST;

                OracleDataReader dataReader = command.ExecuteReader();
                OutilDTO outilDTO= null;

                if (dataReader.NextResult())
                {
                    outilDTO = new OutilDTO();
                    do{
                        command.Parameters.Add(new OracleParameter(":idOutil", outilDTO.IdOutil));
                        command.Parameters.Add(new OracleParameter(":idCategorie", outilDTO.CategorieDTO.IdCategorie));
                        command.Parameters.Add(new OracleParameter(":nom", outilDTO.Nom));
                        command.Parameters.Add(new OracleParameter(":numSerie", outilDTO.NumSerie));
                        command.Parameters.Add(new OracleParameter(":dateAcquisition", outilDTO.DateAcquisition));
                        command.Parameters.Add(new OracleParameter(":prixLocation", outilDTO.PrixLocation));
                        command.Parameters.Add(new OracleParameter(":description", outilDTO.Description));
                        outils.Add(outilDTO);
                    }
                        while(dataReader.NextResult());
                    }
                dataReader.Dispose();
                command.Dispose();
                }catch(OracleException oracleException){
                    throw new DAOException(oracleException);
                }
            return outils;
        }

        /// <inheritdoc />
        public List<OutilDTO> findByNom(Connection connection, string nom,
        string sortByPropertyName)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (nom == null)
            {
                throw new InvalidCriterionException("Le nom ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<OutilDTO> outils = new List<OutilDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = OutilDAO.FIND_BY_NOM;
                command.Parameters.Add(new OracleParameter(":nom", nom));

                OracleDataReader dataReader = command.ExecuteReader();
                OutilDTO outilDTO = null;

                if (dataReader.NextResult())
                {
                    outilDTO = new OutilDTO();
                    do
                    {
                        outilDTO.IdOutil = dataReader.GetString(1);
                        CategorieDTO categorieDTO = new CategorieDTO();
                        categorieDTO.IdCategorie = dataReader.GetString(2);
                        outilDTO.CategorieDTO = categorieDTO;
                        outilDTO.Nom = dataReader.GetString(3);
                        outilDTO.NumSerie = dataReader.GetString(4);
                        outilDTO.PrixLocation = dataReader.GetString(5);
                        outilDTO.DateAcquisition = dataReader.GetString(6);
                        outilDTO.Description = dataReader.GetString(7);
                        outils.Add(outilDTO);
                    }
                    while (dataReader.NextResult());
                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return outils;
        }

    }
}
