using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace CentreLocationOutils.dao.implementations
{
    public class AdresseDAO : DAO, IAdresseDAO
    {

        private static string CREATE_PRIMARY_KEY = "SELECT SEQ_ADRESSE_ID.NEXTVAL "
        + "FROM DUAL";

        private static string ADD_REQUEST = "INSERT INTO adresse (idAdresse, numero, rue, appartement, codePostal, ville, province, pays) "
            + "VALUES (:idAdresse, :numero, :rue, :appartement, :codePostal, :ville, :province, :pays";

        private static string READ_REQUEST = "SELECT idAdresse, numero, rue, appartement, codePostal, ville, province, pays "
            + "FROM adresse "
            + "WHERE idAdresse = :idAdresse";

        private static string UPDATE_REQUEST = "UPDATE adresse "
            + "SET numero = :numero, rue = :rue, appartement = :appartement, codePostal = :codePostal, ville = :ville, province = :province, pays = :pays "
            + "WHERE idAdresse = :idAdresse";

        private static string DELETE_REQUEST = "DELETE FROM adresse "
            + "WHERE idAdresse = :idAdresse";

        private static string GET_ALL_REQUEST = "SELECT idAdresse, numero, rue, appartement, codePostal, ville, province, pays "
            + "FROM adresse";

        private static string FIND_BY_VILLE = "SELECT idAdresse, numero, rue, appartement, codePostal, ville, province, pays "
            + "FROM adresse "
            + "WHERE ville = :ville";

        /// <summary>
        /// Crée le DAO de la table adresse
        /// </summary>
        /// <param name="adresseDTOClass">La classe de adresseDTO à utiliser</param>
        public AdresseDAO() : base() { }

        /// <inheritdoc />
        private static string getPrimaryKey(Connection connection)
        {
            return DAO.getPrimaryKey(connection,
                AdresseDAO.CREATE_PRIMARY_KEY);
        }

        /// <inheritdoc />
        public void add(Connection connection, AdresseDTO adresseDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut etre null");
            }
            if (adresseDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut etre null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = AdresseDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idAdresse", getPrimaryKey(connection, AdresseDAO.CREATE_PRIMARY_KEY)));
                command.Parameters.Add(new OracleParameter(":numero", adresseDTO.Numero));
                command.Parameters.Add(new OracleParameter(":rue", adresseDTO.Rue));
                command.Parameters.Add(new OracleParameter(":appartement", adresseDTO.Appartement));
                command.Parameters.Add(new OracleParameter(":codePostal", adresseDTO.CodePostal));
                command.Parameters.Add(new OracleParameter(":ville", adresseDTO.Ville));
                command.Parameters.Add(new OracleParameter(":province", adresseDTO.Province));
                command.Parameters.Add(new OracleParameter(":pays", adresseDTO.Pays));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }


        /// <inheritdoc />
        public AdresseDTO get(Connection connection, string primaryKey)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut etre null");
            }
            if (primaryKey == null)
            {
                throw new InvalidPrimaryKeyException("La clef primaire ne peut etre null");
            }
            AdresseDTO adresseDTO = null;
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = AdresseDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idReservation", primaryKey));

                OracleDataReader dataReader = command.ExecuteReader();
                if (dataReader.NextResult())
                {
                    adresseDTO = new AdresseDTO();
                    adresseDTO.IdAdresse = dataReader.GetString(1);
                    adresseDTO.Numero = dataReader.GetString(2);
                    adresseDTO.Rue = dataReader.GetString(3);
                    adresseDTO.Appartement = dataReader.GetString(4);
                    adresseDTO.CodePostal = dataReader.GetString(5);
                    adresseDTO.Ville = dataReader.GetString(6);
                    adresseDTO.Province = dataReader.GetString(7);
                    adresseDTO.Pays = dataReader.GetString(8);

                }
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            
            return adresseDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection, AdresseDTO adresseDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut etre null");
            }
            if (adresseDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut etre null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = AdresseDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":numero", adresseDTO.Numero));
                command.Parameters.Add(new OracleParameter(":rue", adresseDTO.Rue));
                command.Parameters.Add(new OracleParameter(":appartement", adresseDTO.Appartement));
                command.Parameters.Add(new OracleParameter(":codePostal", adresseDTO.CodePostal));
                command.Parameters.Add(new OracleParameter(":ville", adresseDTO.Ville));
                command.Parameters.Add(new OracleParameter(":province", adresseDTO.Province));
                command.Parameters.Add(new OracleParameter(":pays", adresseDTO.Pays));

                command.Parameters.Add(new OracleParameter(":idAdresse", adresseDTO.IdAdresse));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
        }

        /// <inheritdoc />
        public void delete(Connection connection, AdresseDTO adresseDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut etre null");
            }
            if (adresseDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut etre null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = AdresseDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idAdresse", adresseDTO.IdAdresse));
                command.ExecuteNonQuery();
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
        }

        /// <inheritdoc />
        public List<AdresseDTO> getAll(Connection connection, string sortByPropertyName)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut etre null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriete utilisee pour classer ne peut etre null");
            }
            List<AdresseDTO> adresses = new List<AdresseDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = AdresseDAO.FIND_BY_VILLE;

                OracleDataReader dataReader = command.ExecuteReader();
                AdresseDTO adresseDTO = null;

                if (dataReader.NextResult())
                {
                    adresseDTO = new AdresseDTO();
                    do
                    {
                        adresseDTO = new AdresseDTO();
                        adresseDTO.IdAdresse = dataReader.GetString(1);
                        adresseDTO.Numero = dataReader.GetString(2);
                        adresseDTO.Rue = dataReader.GetString(3);
                        adresseDTO.Appartement = dataReader.GetString(4);
                        adresseDTO.CodePostal = dataReader.GetString(5);
                        adresseDTO.Ville = dataReader.GetString(6);
                        adresseDTO.Province = dataReader.GetString(7);
                        adresseDTO.Pays = dataReader.GetString(8);

                        adresses.Add(adresseDTO);
                    }
                    while (dataReader.NextResult());
                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
            return adresses;
        }

        /// <inheritdoc />
        public List<AdresseDTO> findByVille(Connection connection, string ville, string sortByPropertyName)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut etre null");
            }
            if (ville == null)
            {
                throw new InvalidCriterionException("La ville ne peut etre null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriete utilisee pour classer ne peut etre null");
            }

            List<AdresseDTO> adresses = new List<AdresseDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = AdresseDAO.FIND_BY_VILLE;
                command.Parameters.Add(new OracleParameter(":ville", ville));

                OracleDataReader dataReader = command.ExecuteReader();
                AdresseDTO adresseDTO = null;

                if (dataReader.NextResult())
                {
                    adresseDTO = new AdresseDTO();
                    do
                    {
                        adresseDTO = new AdresseDTO();
                        adresseDTO.IdAdresse = dataReader.GetString(1);
                        adresseDTO.Numero = dataReader.GetString(2);
                        adresseDTO.Rue = dataReader.GetString(3);
                        adresseDTO.Appartement = dataReader.GetString(4);
                        adresseDTO.CodePostal = dataReader.GetString(5);
                        adresseDTO.Ville = dataReader.GetString(6);
                        adresseDTO.Province = dataReader.GetString(7);
                        adresseDTO.Pays = dataReader.GetString(8);

                        adresses.Add(adresseDTO);
                    }
                    while (dataReader.NextResult());
                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
            return adresses;
        }
    }
}
