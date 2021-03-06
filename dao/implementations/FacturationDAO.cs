﻿using CentreLocationOutils.dao.interfaces;
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
    public class FacturationDAO : DAO, IFacturationDAO
    {

        private static   string ADD_REQUEST = "INSERT INTO Facturation (idFacturation, idEmploye, idLocation, coutTotal) "
            + "VALUES (:idFacturation, :idEmploye, :idLocation, :coutTotal)";

        private static   string READ_REQUEST = "SELECT idFacturation, idEmploye, idLocation, coutTotal "
            + "FROM facturation "
            + "WHERE idFacturation = :idFacturation";

        private static   string UPDATE_REQUEST = "UPDATE facturation "
            + "SET idemploye = :idEmploye, idLocation = :idLocation, couttotal = :coutTotal "
            + "WHERE idFacturation = :idFacturation";

        private static   string DELETE_REQUEST = "DELETE FROM facturation "
            + "WHERE idFacturation = :idFacturation";

        private static   string GET_ALL_REQUEST = "SELECT idFacturation, idEmploye, idLocation, coutTotal "
            + "FROM facturation";

        private static   string CREATE_PRIMARY_KEY = "SELECT SEQ_FACTURATION_ID.NEXTVAL from DUAL";

        private static   string FIND_BY_EMPLOYE = "SELECT idFacturation, idEmploye, idLocation, coutTotal "
            + "FROM facturation "
            + "WHERE idEmploye = :idEmploye";

        private static   string FIND_BY_CLIENT = "SELECT facturation.idFacturation, facturation.idEmploye, facturation.idLocation, facturation.coutTotal "
            + "FROM facturation "
            + "INNER JOIN location"
            + "WHERE location.idClient = :idClient";

        /// <summary>
        /// Crée le DAO de la table Facturation <code>facturation</code>
        /// </summary>
        /// <param name="facturationDTOClass">La classe de facturation DTO à utiliser</param>
        
        public FacturationDAO() : base() { }

        /// <inheritdoc />
        private static String getPrimaryKey(Connection connection)
        {
            return DAO.getPrimaryKey(connection,
                FacturationDAO.CREATE_PRIMARY_KEY);
        }

        /// <inheritdoc />
        public void add(Connection connection,
        FacturationDTO facturationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (facturationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idFacturation", getPrimaryKey(connection, FacturationDAO.CREATE_PRIMARY_KEY)));
                command.Parameters.Add(new OracleParameter(":idEmploye", facturationDTO.EmployerDTO.IdEmploye));
                command.Parameters.Add(new OracleParameter(":idLocation", facturationDTO.LocationDTO.IdLocation));
                command.Parameters.Add(new OracleParameter(":coutTotal", facturationDTO.CoutTotal));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public FacturationDTO get(Connection connection,
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
            FacturationDTO facturationDTO = null;
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idLocation", idLocation));

                OracleDataReader dataReader = command.ExecuteReader();
                if (dataReader.NextResult())
                {
                    facturationDTO = new FacturationDTO();
                    facturationDTO.IdFacturation = dataReader.GetString(1);
                    EmployeDTO employeDTO = new EmployeDTO();
                    employeDTO.IdEmploye = dataReader.GetString(2);
                    LocationDTO locationDTO= new LocationDTO();
                    locationDTO.IdLocation = dataReader.GetString(3);
                    facturationDTO.EmployerDTO = employeDTO;
                    facturationDTO.LocationDTO = locationDTO;
                    facturationDTO.CoutTotal = dataReader.GetString(4);

                }
                dataReader.Dispose();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
            return facturationDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection,
        FacturationDTO facturationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (facturationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idEmploye", facturationDTO.IdFacturation));
                command.Parameters.Add(new OracleParameter(":idLocation", facturationDTO.LocationDTO.IdLocation));
                command.Parameters.Add(new OracleParameter(":coutTotal", facturationDTO.CoutTotal));

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
        FacturationDTO facturationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (facturationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idFacturation", facturationDTO.IdFacturation));

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (OracleException oracleException)
            {
                throw new DAOException(oracleException);
            }
        }

        /// <inheritdoc />
        public List<FacturationDTO> getAll(Connection connection,
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
            List<FacturationDTO> facturation = new List<FacturationDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.GET_ALL_REQUEST;

                OracleDataReader dataReader = command.ExecuteReader();
                FacturationDTO facturationDTO = null;

                if (dataReader.NextResult())
                {
                    facturationDTO = new FacturationDTO();
                    do
                    {
                        facturationDTO = new FacturationDTO();
                        facturationDTO.IdFacturation = dataReader.GetString(1);
                        EmployeDTO employeDTO = new EmployeDTO();
                        employeDTO.IdEmploye = dataReader.GetString(2);
                        LocationDTO locationDTO = new LocationDTO();
                        locationDTO.IdLocation = dataReader.GetString(3);
                        facturationDTO.EmployerDTO = employeDTO;
                        facturationDTO.LocationDTO = locationDTO;
                        facturationDTO.CoutTotal = dataReader.GetString(4);

                        facturation.Add(facturationDTO);
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
            return facturation;
        }

        /// <inheritdoc />
        public List<FacturationDTO> findByEmploye(Connection connection, string idEmploye, string sortByPropertyName)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (idEmploye == null)
            {
                throw new InvalidCriterionException("L'ID Employe ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<FacturationDTO> facturation = new List<FacturationDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.FIND_BY_EMPLOYE;
                command.Parameters.Add(new OracleParameter(":idEmploye" ,idEmploye));

                OracleDataReader dataReader = command.ExecuteReader();
                FacturationDTO facturationDTO = null;

                if (dataReader.NextResult())
                {
                    facturationDTO = new FacturationDTO();
                    do
                    {
                        facturationDTO = new FacturationDTO();
                        facturationDTO.IdFacturation = dataReader.GetString(1);
                        EmployeDTO employeDTO = new EmployeDTO();
                        employeDTO.IdEmploye = dataReader.GetString(2);
                        LocationDTO locationDTO = new LocationDTO();
                        locationDTO.IdLocation = dataReader.GetString(3);
                        facturationDTO.EmployerDTO = employeDTO;
                        facturationDTO.LocationDTO = locationDTO;
                        facturationDTO.CoutTotal = dataReader.GetString(4);

                        facturation.Add(facturationDTO);
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
            return facturation;
        }

        /// <inheritdoc />
        public List<FacturationDTO> findByClient(Connection connection, string idClient, string sortByPropertyName)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (idClient == null)
            {
                throw new InvalidCriterionException("L'ID Client ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<FacturationDTO> facturation = new List<FacturationDTO>();

            try
            {
                OracleCommand command = connection.ConnectionOracle.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = FacturationDAO.FIND_BY_CLIENT;
                command.Parameters.Add(new OracleParameter(":idClient", idClient));

                OracleDataReader dataReader = command.ExecuteReader();
                FacturationDTO facturationDTO = null;

                if (dataReader.NextResult())
                {
                    facturationDTO = new FacturationDTO();
                    do
                    {
                        facturationDTO = new FacturationDTO();
                        facturationDTO.IdFacturation = dataReader.GetString(1);
                        EmployeDTO employeDTO = new EmployeDTO();
                        employeDTO.IdEmploye = dataReader.GetString(2);
                        LocationDTO locationDTO = new LocationDTO();
                        locationDTO.IdLocation = dataReader.GetString(3);
                        facturationDTO.EmployerDTO = employeDTO;
                        facturationDTO.LocationDTO = locationDTO;
                        facturationDTO.CoutTotal = dataReader.GetString(4);

                        facturation.Add(facturationDTO);
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
            return facturation;
        }
    }
}
