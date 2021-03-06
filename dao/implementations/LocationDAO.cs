﻿using CentreLocationOutils.db;
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
    public class LocationDAO : DAO, CentreLocationOutils.dao.interfaces.ILocationDAO
    {
         private static   String CREATE_PRIMARY_KEY = "SELECT SEQ_LOCATION_ID.NEXTVAL "
        + "FROM DUAL";

         private static   String ADD_REQUEST = "INSERT INTO location (idLocation, idClient, idEmploye, idOutil, dateLocation, dateLimite, dateRetour) "
            + "VALUES (:idLocation, :idClient, :idEmploye, :idOutil, :dateLocation, :dateLimite, :dateRetour";

         private static   String READ_REQUEST = "SELECT idLocation, idClient, idEmploye, idOutil, dateLocation, dateLimite, dateRetour "
            + "FROM location "
            + "WHERE idLocation = :idLocation";

        private static   String UPDATE_REQUEST = "UPDATE location "
            + "SET dateLimite = :dateLimite, dateRetour = :dateRetour "
            + "WHERE idLocation = :idLocation";

        private static   String DELETE_REQUEST = "DELETE FROM location "
            + "WHERE idLocation = :idLocation";

        private static   String GET_ALL_REQUEST = "SELECT idLocation, idClient, idEmploye, idOutil, dateLocation, dateLimite, dateRetour "
            + "FROM location";

        private static   String FIND_BY_CLIENT_REQUEST = "SELECT idLocation, idClient, idEmploye, idOutil, dateLocation, dateLimite, dateRetour "
            + "FROM location "
            + "WHERE idClient = :idClient";

        private static   String FIND_BY_OUTIL_REQUEST = "SELECT idLocation, idClient, idEmploye, idOutil, dateLocation, dateLimite, dateRetour "
            + "FROM location "
            + "WHERE idOutil = :idOutil "
            + "ORDER BY dateLocation ASC";

        /// <summary>
        /// Crée le DAO de la table Location <code>location</code>
        /// </summary>
        /// <param name="locationDTOClass">La classe de location DTO à utiliser</param>
        
        public LocationDAO() : base() { }


        /// <inheritdoc />
        public void add(Connection connection,
        LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idLocation", getPrimaryKey(connection, LocationDAO.CREATE_PRIMARY_KEY)));
                command.Parameters.Add(new OracleParameter(":idClient", locationDTO.ClientDTO.IdClient));
                command.Parameters.Add(new OracleParameter(":idEmploye", locationDTO.EmployeDTO.IdEmploye));
                command.Parameters.Add(new OracleParameter(":idOutil", locationDTO.OutilDTO.IdOutil));
                command.Parameters.Add(new OracleParameter(":dateLocation", locationDTO.DateLocation));
                command.Parameters.Add(new OracleParameter(":dateLimite", locationDTO.DateLimite));
                command.Parameters.Add(new OracleParameter(":dateRetour", locationDTO.DateRetour));


                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public LocationDTO get(Connection connection,
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
            string idLocation = primaryKey.ToString();
            LocationDTO locationDTO = null;
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idLocation", idLocation));

                OracleDataReader dataReader = command.ExecuteReader();
                if (dataReader.NextResult())
                {
                    locationDTO = new LocationDTO();
                    locationDTO.IdLocation = dataReader.GetString(1);
                    ClientDTO clientDTO = new ClientDTO();
                    clientDTO.IdClient = dataReader.GetString(2);
                    EmployeDTO employeDTO = new EmployeDTO();
                    employeDTO.IdEmploye = dataReader.GetString(3);
                    OutilDTO outilDTO = new OutilDTO();
                    outilDTO.IdOutil = dataReader.GetString(4);
                    locationDTO.ClientDTO = clientDTO;
                    locationDTO.OutilDTO = outilDTO;
                    locationDTO.DateLocation = dataReader.GetDateTime(5).ToString();
                    locationDTO.DateLimite = dataReader.GetDateTime(6).ToString();
                    locationDTO.DateRetour = dataReader.GetDateTime(7).ToString();

                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return locationDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection,
        LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":dateLimite", locationDTO.DateLimite));
                command.Parameters.Add(new OracleParameter(":idLocation", locationDTO.IdLocation));

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
        LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idLocation", locationDTO.IdLocation));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public List<LocationDTO> getAll(Connection connection,
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
            List<LocationDTO> locations = new List<LocationDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.GET_ALL_REQUEST;

                OracleDataReader dataReader = command.ExecuteReader();
                LocationDTO locationDTO = null;

                if (dataReader.NextResult())
                {
                    locationDTO = new LocationDTO();
                    do
                    {
                        locationDTO.IdLocation = dataReader.GetString(1);
                        ClientDTO clientDTO = new ClientDTO();
                        clientDTO.IdClient = dataReader.GetString(2);
                        EmployeDTO employeDTO = new EmployeDTO();
                        employeDTO.IdEmploye = dataReader.GetString(3);
                        locationDTO.ClientDTO = clientDTO;
                        OutilDTO outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(4);
                        locationDTO.OutilDTO = outilDTO;
                        locationDTO.DateLocation = dataReader.GetDateTime(5).ToString();
                        locationDTO.DateLimite = dataReader.GetDateTime(6).ToString();
                        locationDTO.DateRetour = dataReader.GetDateTime(7).ToString();

                        locations.Add(locationDTO);
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
            return locations;
        }

        /// <inheritdoc />
        public List<LocationDTO> findByClient(Connection connection,
        String idClient,
        String sortByPropertyName)
        {

            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (idClient == null)
            {
                throw new InvalidCriterionException("L'ID du client ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<LocationDTO> locations = new List<LocationDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.FIND_BY_CLIENT_REQUEST;
                command.Parameters.Add(new OracleParameter(":idClient", idClient));

                OracleDataReader dataReader = command.ExecuteReader();
                LocationDTO locationDTO = null;

                if (dataReader.NextResult())
                {

                    do
                    {
                        locationDTO.IdLocation = dataReader.GetString(1);
                        ClientDTO clientDTO = new ClientDTO();
                        clientDTO.IdClient = dataReader.GetString(2);
                        EmployeDTO employeDTO = new EmployeDTO();
                        employeDTO.IdEmploye = dataReader.GetString(3);
                        locationDTO.ClientDTO = clientDTO;
                        OutilDTO outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(4);
                        locationDTO.OutilDTO = outilDTO;
                        locationDTO.DateLocation = dataReader.GetDateTime(5).ToString();
                        locationDTO.DateLimite = dataReader.GetString(6).ToString();
                        locationDTO.DateRetour = dataReader.GetDateTime(7).ToString();
                        locations.Add(locationDTO);
                    } while (dataReader.NextResult());
                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return locations;
        }

        /// <inheritdoc />
        public List<LocationDTO> findByOutil(Connection connection,
        String idOutil,
        String sortByPropertyName)
        {

            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (idOutil == null)
            {
                throw new InvalidCriterionException("L'ID du outil ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<LocationDTO> locations = new List<LocationDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = LocationDAO.FIND_BY_OUTIL_REQUEST;
                command.Parameters.Add(new OracleParameter(":idOutil", idOutil));

                OracleDataReader dataReader = command.ExecuteReader();
                LocationDTO locationDTO = null;

                if (dataReader.NextResult())
                {

                    do
                    {
                        locationDTO.IdLocation = dataReader.GetString(1);
                        ClientDTO clientDTO = new ClientDTO();
                        clientDTO.IdClient = dataReader.GetString(2);
                        EmployeDTO employeDTO = new EmployeDTO();
                        employeDTO.IdEmploye = dataReader.GetString(3);
                        locationDTO.ClientDTO = clientDTO;
                        OutilDTO outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(4);
                        locationDTO.OutilDTO = outilDTO;
                        locationDTO.DateLocation = dataReader.GetDateTime(5).ToString();
                        locationDTO.DateLimite = dataReader.GetDateTime(6).ToString();
                        locationDTO.DateRetour = dataReader.GetDateTime(7).ToString();
                        locations.Add(locationDTO);
                    } while (dataReader.NextResult());
                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return locations;
        }
    }
}
