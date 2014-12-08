using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

namespace CentreLocationOutils.dao.implementations
{
    public class ReservationDAO : DAO, IReservationDAO
    {
        private static   String CREATE_PRIMARY_KEY = "SELECT SEQ_RESERVATION_ID.NEXTVAL "
        + "FROM DUAL";

        private static   String ADD_REQUEST = "INSERT INTO reservation (idReservation, idClient, idOutil, dateReservation, dateLimite) "
            + "VALUES (:idReservation, :idClient, :idOutil, :dateReservation, :dateLimite";

        private static   String READ_REQUEST = "SELECT idReservation, idClient, idOutil, dateReservation, dateLimite "
            + "FROM reservation "
            + "WHERE idReservation = :idReservation";

        private static   String UPDATE_REQUEST = "UPDATE reservation "
            + "SET dateLimite = :dateLimite "
            + "WHERE idReservation = :idReservation";

        private static   String DELETE_REQUEST = "DELETE FROM reservation "
            + "WHERE idReservation = :idReservation";

        private static   String GET_ALL_REQUEST = "SELECT idReservation, idClient, idOutil, dateReservation "
            + "FROM reservation";

        private static   String FIND_BY_CLIENT_REQUEST = "SELECT idReservation, idClient, idOutil, dateReservation "
            + "FROM reservation "
            + "WHERE idClient = :idClient";

        private static   String FIND_BY_OUTIL_REQUEST = "SELECT idReservation, idClient, idOutil, dateReservation "
            + "FROM reservation "
            + "WHERE idOutil = :idOutil "
            + "ORDER BY dateReservation ASC";

        /// <summary>
        /// Crée le DAO de la table réservation
        /// </summary>
        /// <param name="reservationDTOClass">La classe de réservationDTO à utiliser</param>
        //public ReservationDAO(ReservationDTO reservationDTOClass) : base(reservationDTOClass) { }

        public ReservationDAO() : base() { }

        private static String getPrimaryKey(Connection connection) {
        return DAO.getPrimaryKey(connection,
            ReservationDAO.CREATE_PRIMARY_KEY);
    }

        /// <inheritdoc />
        public void add(Connection connection,
        ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            //if (!dto.GetType().Equals(getDtoClass()))
            //{
            //    throw new InvalidDTOClassException("Le DTO doit être un "
            //        + getDtoClass().getName());
            //}
            //EmployeDTO employeDTO = employeDTO;//(EmployeDTO) dto;
            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.ADD_REQUEST;
                command.Parameters.Add(new OracleParameter(":idReservation", reservationDTO.IdReservation));
                command.Parameters.Add(new OracleParameter(":idClient", reservationDTO.ClientDTO.IdClient));
                command.Parameters.Add(new OracleParameter(":idOutil", reservationDTO.OutilDTO.IdOutil));
                command.Parameters.Add(new OracleParameter(":dateReservation", reservationDTO.DateReservation));
                command.Parameters.Add(new OracleParameter(":dateLimite", reservationDTO.DateLimite));


                command.ExecuteNonQuery();
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }

        /// <inheritdoc />
        public ReservationDTO get(Connection connection,
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
            string idReservation = primaryKey.ToString();
            ReservationDTO reservationDTO = null;
            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.READ_REQUEST;
                command.Parameters.Add(new OracleParameter(":idReservation", idReservation));

                DbDataReader dataReader = command.ExecuteReader();
                if (dataReader.NextResult())
                {
                    reservationDTO = new ReservationDTO();
                    reservationDTO.IdReservation = dataReader.GetString(1);
                    ClientDTO clientDTO = new ClientDTO();
                    clientDTO.IdClient = dataReader.GetString(2);
                    OutilDTO outilDTO = new OutilDTO();
                    outilDTO.IdOutil = dataReader.GetString(3);
                    reservationDTO.ClientDTO = clientDTO;
                    reservationDTO.OutilDTO = outilDTO;
                    reservationDTO.DateReservation = dataReader.GetDateTime(4).ToString();
                    reservationDTO.DateLimite = dataReader.GetDateTime(5).ToString();

                }
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
            return reservationDTO;
        }

        /// <inheritdoc />
        public void update(Connection connection,
        ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                //throw new InvalidHibernateSessionException("La connexion ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            //if (!dto.GetType().Equals(getDtoClass()))
            //{
            //    throw new InvalidDTOClassException("Le DTO doit être un "
            //        + getDtoClass().getName());
            //}
            //EmployeDTO employeDTO = (EmployeDTO)dto;
            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.UPDATE_REQUEST;
                command.Parameters.Add(new OracleParameter(":dateLimite", reservationDTO.DateLimite));
                command.Parameters.Add(new OracleParameter(":idReservation", reservationDTO.IdReservation));

                command.ExecuteNonQuery();
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }

        /// <inheritdoc />
        public void delete(Connection connection,
        ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                //throw new InvalidHibernateSessionException("La connexion ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null");
            }
            //if (!dto.GetType().Equals(getDtoClass()))
            //{
            //    throw new InvalidDTOClassException("Le DTO doit être un "
            //        + getDtoClass().getName());
            //}
            // EmployeDTO employeDTO = (EmployeDTO)dto;

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.DELETE_REQUEST;
                command.Parameters.Add(new OracleParameter(":idReservation", reservationDTO.IdReservation));
                command.ExecuteNonQuery();
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }

        /// <inheritdoc />
        public List<ReservationDTO> getAll(Connection connection,
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
            List<ReservationDTO> reservations = new List<ReservationDTO>();

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.GET_ALL_REQUEST;

                DbDataReader dataReader = command.ExecuteReader();
                ReservationDTO reservationDTO = null;

                if (dataReader.NextResult())
                {
                    reservationDTO = new ReservationDTO();
                    do
                    {
                        reservationDTO.IdReservation = dataReader.GetString(1);
                        ClientDTO clientDTO = new ClientDTO();
                        clientDTO.IdClient = dataReader.GetString(2);
                        reservationDTO.ClientDTO = clientDTO;
                        OutilDTO outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(3);
                        reservationDTO.OutilDTO = outilDTO;
                        reservationDTO.DateReservation = dataReader.GetDateTime(4).ToString();
                        reservationDTO.DateLimite = dataReader.GetDateTime(5).ToString();

                        reservations.Add(reservationDTO);
                    }
                    while (dataReader.NextResult());
                }
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
            return reservations;
        }

        /// <inheritdoc />
        public List<ReservationDTO> findByClient(Connection connection,
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
            List<ReservationDTO> reservations = new List<ReservationDTO>();

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.FIND_BY_CLIENT_REQUEST;

                DbDataReader dataReader = command.ExecuteReader();
                ReservationDTO reservationDTO = null;

                if (dataReader.NextResult())
                {

                    do
                    {
                        reservationDTO = new ReservationDTO();
                        reservationDTO.IdReservation = dataReader.GetString(1);
                        ClientDTO clientDTO = new ClientDTO();
                        clientDTO.IdClient = dataReader.GetString(2);
                        OutilDTO outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(3);
                        reservationDTO.ClientDTO = clientDTO;
                        reservationDTO.OutilDTO = outilDTO;
                        reservations.Add(reservationDTO);
                    } while (dataReader.NextResult());
                }
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
            return reservations;
        }

        /// <inheritdoc />
        public List<ReservationDTO> findByOutil(Connection connection,
        String idClient,
        String sortByPropertyName)
        {

            if (connection == null)
            {
                throw new InvalidConnectionException("La connexion ne peut être null");
            }
            if (idClient == null)
            {
                throw new InvalidCriterionException("L'ID du outil ne peut être null");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("La propriété utilisée pour classer ne peut être null");
            }
            List<ReservationDTO> reservations = new List<ReservationDTO>();

            try
            {
                DbCommand command = connection.getConnection().CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = ReservationDAO.FIND_BY_OUTIL_REQUEST;

                DbDataReader dataReader = command.ExecuteReader();
                ReservationDTO reservationDTO = null;

                if (dataReader.NextResult())
                {

                    do
                    {
                        reservationDTO = new ReservationDTO();
                        reservationDTO.IdReservation = dataReader.GetString(1);
                        ClientDTO clientDTO = new ClientDTO();
                        clientDTO.IdClient = dataReader.GetString(2);
                        OutilDTO outilDTO = new OutilDTO();
                        outilDTO.IdOutil = dataReader.GetString(3);
                        reservationDTO.ClientDTO = clientDTO;
                        reservationDTO.OutilDTO = outilDTO;
                        reservations.Add(reservationDTO);
                    } while (dataReader.NextResult());
                }
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
            return reservations;
        }

    }
}
