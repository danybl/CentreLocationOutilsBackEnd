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
    public class ClientDAO : DAO, IClientDAO
    {

        private static string ADD_REQUEST = "INSERT INTO Client (idClient, nom, prenom, telephone, email, dateInscription, nbLocations, limiteLocations) "
       + "VALUES (:idClient, :nom, :prenom, :telephone, :email, :dateInscription, :nbLocations, :limiteLocations)";

        private static string READ_REQUEST = "SELECT idClient, nom, prenom, telephone, email, dateInscription, nbLocations, limiteLocations "
            + "FROM client "
            + "WHERE idClient = :idClient";

        private static string UPDATE_REQUEST = "UPDATE client "
            + "SET nom = :nom, prenom = :prenom, telephone = :telephone, email = :email, nbLocations = :nbLocations, limiteLocations = :limiteLocations "
            + "WHERE idClient = :idClient";

        private static string DELETE_REQUEST = "DELETE FROM client "
            + "WHERE idClient = :idClient";

        private static   string GET_ALL_REQUEST = "SELECT idClient, nom, prenom, telephone, email, dateInscription, nbLocations, limiteLocations "
            + "FROM client";

        private static string FIND_BY_NOM = "SELECT idClient, nom, prenom, telephone, email, dateInscription, nbLocations, limiteLocations "
            + "FROM client "
            + "where nom like :nom";

        private static string CREATE_PRIMARY_KEY = "SELECT SEQ_CLIENT_ID.NEXTVAL from DUAL";

        /// <summary>
        /// Crée le DAO de la table Client <code>client</code>
        /// </summary>
        /// <param name="clientDTOClass">La classe de clientDTO à utiliser</param>

        public ClientDAO() : base() { }

        /// <inheritdoc />
        private static String getPrimaryKey(Connection connection)
        {
            return DAO.getPrimaryKey(connection,
                ClientDAO.CREATE_PRIMARY_KEY);
        }

        /// <inheritdoc />
        public void add(Connection connection,
        ClientDTO clientDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (clientDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ClientDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", getPrimaryKey(connection, ClientDAO.CREATE_PRIMARY_KEY)));
                command.Parameters.Add(new OracleParameter(":nom", clientDTO.Nom));
                command.Parameters.Add(new OracleParameter(":prenom", clientDTO.Prenom));
                command.Parameters.Add(new OracleParameter(":telephone", clientDTO.Telephone));
                command.Parameters.Add(new OracleParameter(":email", clientDTO.Email));
                command.Parameters.Add(new OracleParameter("dateInscription", clientDTO.DateInscription));
                command.Parameters.Add(new OracleParameter("nbLocations", clientDTO.NbLocations));
                command.Parameters.Add(new OracleParameter("limiteLocations", clientDTO.LimiteLocations));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public ClientDTO get(Connection connection,
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
            ClientDTO clientDTO = null;
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ClientDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", idClient));

                OracleDataReader dataReader = command.ExecuteReader();
                if (dataReader.NextResult())
                {
                    clientDTO = new ClientDTO();
                    clientDTO.IdClient = dataReader.GetString(1);
                    clientDTO.Nom = dataReader.GetString(2);
                    clientDTO.Prenom = dataReader.GetString(3);
                    clientDTO.Telephone = dataReader.GetString(4);
                    clientDTO.Email = dataReader.GetString(5);
                    clientDTO.DateInscription = dataReader.GetDateTime(6).ToString();
                    clientDTO.NbLocations = dataReader.GetString(7);
                    clientDTO.LimiteLocations = dataReader.GetString(8);

                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return clientDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection,
        ClientDTO clientDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (clientDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ClientDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":nom", clientDTO.Nom));
                command.Parameters.Add(new OracleParameter(":prenom", clientDTO.Prenom));
                command.Parameters.Add(new OracleParameter(":telephone", clientDTO.Telephone));
                command.Parameters.Add(new OracleParameter(":email", clientDTO.Email));
                command.Parameters.Add(new OracleParameter(":dateInscription", clientDTO.DateInscription));
                command.Parameters.Add(new OracleParameter("nbLocations", clientDTO.NbLocations));
                command.Parameters.Add(new OracleParameter("limiteLocations", clientDTO.LimiteLocations));
                command.Parameters.Add(new OracleParameter("idClient", clientDTO.IdClient));

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
        ClientDTO clientDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (clientDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ClientDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", clientDTO.IdClient));
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public List<ClientDTO> getAll(Connection connection,
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
            List<ClientDTO> clients = new List<ClientDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ClientDAO.GET_ALL_REQUEST;

                OracleDataReader dataReader = command.ExecuteReader();
                ClientDTO clientDTO = null;

                if (dataReader.NextResult())
                {
                    clientDTO = new ClientDTO();
                    do
                    {
                        clientDTO.IdClient = dataReader.GetString(1);
                        clientDTO.Nom = dataReader.GetString(2);
                        clientDTO.Prenom = dataReader.GetString(3);
                        clientDTO.Telephone = dataReader.GetString(4);
                        clientDTO.Email = dataReader.GetString(5);
                        clientDTO.DateInscription = dataReader.GetDateTime(6).ToString();
                        clientDTO.NbLocations = dataReader.GetString(7).ToString();
                        clientDTO.LimiteLocations = dataReader.GetString(8).ToString();
                        clients.Add(clientDTO);
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
            return clients;
        }

        /// <inheritdoc />
        public List<ClientDTO> findByNom(Connection connection, string nom,
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
            List<ClientDTO> clients = new List<ClientDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ClientDAO.FIND_BY_NOM;
                command.Parameters.Add(new OracleParameter(":nom", nom));

                OracleDataReader dataReader = command.ExecuteReader();
                ClientDTO clientDTO = null;

                if (dataReader.NextResult())
                {
                    clientDTO = new ClientDTO();
                    do
                    {
                        clientDTO.IdClient = dataReader.GetString(1);
                        clientDTO.Nom = dataReader.GetString(2);
                        clientDTO.Prenom = dataReader.GetString(3);
                        clientDTO.Telephone = dataReader.GetString(4);
                        clientDTO.Email = dataReader.GetString(5);
                        clientDTO.DateInscription = dataReader.GetDateTime(6).ToString();
                        clientDTO.NbLocations = dataReader.GetString(7);
                        clientDTO.LimiteLocations = dataReader.GetString(8);
                        clients.Add(clientDTO);
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
            return clients;
        }

    }
}
