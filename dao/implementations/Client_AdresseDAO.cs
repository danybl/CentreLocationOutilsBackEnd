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
    public class Client_AdresseDAO : DAO
    {
        private static   string ADD_REQUEST = "INSERT INTO Client (idClient, idAdresse) "
       + "VALUES (:idClient, :idAdresse)";

        private static   string READ_REQUEST = "SELECT idClient, idAdresse "
            + "FROM client "
            + "WHERE idClient = :idClient";

        private static string UPDATE_REQUEST = "UPDATE client_Adresse"; // TODO 

        private static   string DELETE_REQUEST = "DELETE FROM client "
            + "WHERE idClient = :idClient";

        private static   string GET_ALL_REQUEST = "SELECT idClient, idAdresse "
            + "FROM client";

        private static   string CREATE_PRIMARY_KEY = "SELECT SEQ_CLIENT_ID.NEXTVAL from DUAL";

        /// <summary>
        /// Crée le DAO de la table Client_Adresse <code>client_Adresse</code>
        /// </summary>
        /// <param name="client_AdresseDTOClass">La classe de client_AdresseDTO à utiliser</param>
        public Client_AdresseDAO() : base() { }

        /// <inheritdoc />
        public void add(Connection connection,
        Client_AdresseDTO client_AdresseDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (client_AdresseDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = Client_AdresseDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", client_AdresseDTO.IdClient));
                command.Parameters.Add(new OracleParameter(":idAdresse", client_AdresseDTO.IdAdresse));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
        }

        /// <inheritdoc />
        public Client_AdresseDTO get(Connection connection,
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
            string idClient = primaryKey.ToString();
            Client_AdresseDTO client_AdresseDTO = null;
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = Client_AdresseDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", idClient));

                OracleDataReader dataReader = command.ExecuteReader();
                if (dataReader.NextResult())
                {
                    client_AdresseDTO = new Client_AdresseDTO();
                    client_AdresseDTO.IdClient = dataReader.GetString(1);
                    client_AdresseDTO.IdAdresse = dataReader.GetString(2);

                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
            return client_AdresseDTO;
        }

        public void update(Connection connection, Client_AdresseDTO client_AdresseDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (client_AdresseDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = Client_AdresseDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", client_AdresseDTO.IdClient));

            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
        }

        /// <inheritdoc />
        public void delete(Connection connection,
        Client_AdresseDTO client_AdresseDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (client_AdresseDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = Client_AdresseDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", client_AdresseDTO.IdClient));

            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
        }

        /// <inheritdoc />
        public List<Client_AdresseDTO> getAll(Connection connection,
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
            List<Client_AdresseDTO> client_Adresses = new List<Client_AdresseDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = Client_AdresseDAO.GET_ALL_REQUEST;

                OracleDataReader dataReader = command.ExecuteReader();
                Client_AdresseDTO client_AdresseDTO = null;

                if (dataReader.NextResult())
                {
                    client_AdresseDTO = new Client_AdresseDTO();
                    do
                    {
                        client_AdresseDTO.IdClient = dataReader.GetString(1);
                        client_AdresseDTO.IdAdresse = dataReader.GetString(2);

                        client_Adresses.Add(client_AdresseDTO);
                    }
                    while (dataReader.NextResult());
                }
            }
            catch (OracleException OracleException)
            {
                throw new DAOException(OracleException);
            }
            return client_Adresses;
        }

    }
}
