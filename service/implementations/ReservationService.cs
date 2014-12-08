using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.service.interfaces;
using System.Collections.Generic;

namespace CentreLocationOutils.service.implementations
{
    public class ReservationService : Service, IReservationService
    {
        private IReservationDAO reservationDAO;
        private ILocationDAO locationDAO;
        // private IOutilDAO outilDAO;

        public ReservationService(IReservationDAO reservationDAO, ILocationDAO locationDAO)
            : base()
        {
            if (reservationDAO == null)
            {
                throw new InvalidDAOException("Le DAO de la réservation ne peut être null");
            }
            setEmployeDAO(reservationDAO);
        }
        /// <summary>
        /// Getter de la variable d'instance reservationDAO
        /// </summary>
        /// <returns>La valeur de la variable d'instance</returns>
        private IReservationDAO getReservationDAO()
        {
            return this.reservationDAO;
        }
        /// <summary>
        /// Setter de la variable d'instance reservationDAO
        /// </summary>
        /// <param name="reservationDAO">Valeur à utiliser pour la variable d'instance</param>
        private void setEmployeDAO(IReservationDAO reservationDAO)
        {
            this.reservationDAO = reservationDAO;
        }

        private ILocationDAO getLocationDAO()
        {
            return this.locationDAO;
        }
        private void setLocationDAO(ILocationDAO locationDAO)
        {
            this.locationDAO = locationDAO;
        }
        //private IOutilDAO getOutilDAO()
        //{
        //    return this.outilDAO;
        //}
        //private void setOutilDAO(IOutilDAO outilDAO)
        //{
        //    this.outilDAO = outilDAO;
        //}


        /// <inheritdoc />
        public void addReservation(Connection connection,
        ReservationDTO reservationDTO)
        {
            try
            {
                getReservationDAO().add(connection,
                    reservationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }



        /// <inheritdoc />
        public void updateReservation(Connection connection,
            ReservationDTO reservationDTO)
        {
            try
            {
                getReservationDAO().update(connection,
                    reservationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public void deleteReservation(Connection connection,
            ReservationDTO reservationDTO)
        {
            try
            {
                getReservationDAO().delete(connection,
                    reservationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<ReservationDTO> getAllReservations(Connection connection,
            string sortByPropertyName)
        {
            try
            {
                return getReservationDAO().getAll(connection,
                    sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public void placerReservation(Connection connection, ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("La réservation ne peut être null");
            }
            List<ReservationDTO> reservations = getAllReservations(connection, ReservationDTO.ID_RESERVATION_COLUMN_NAME);
            foreach (ReservationDTO uneReservationDTO in reservations)
            {
                if (reservationDTO.OutilDTO.Equals(uneReservationDTO.OutilDTO))
                {
                    throw new ExistingLoanException("L'outil " + uneReservationDTO.OutilDTO.Nom
                    + " (ID d'outil : "
                    + uneReservationDTO.OutilDTO.IdOutil
                    + ") est déjà réservé pour  "
                    + uneReservationDTO.ClientDTO.Nom
                    + ", "
                    + uneReservationDTO.ClientDTO.Prenom
                    + "(ID de client "
                    + uneReservationDTO.ClientDTO.IdClient
                    + ")");
                }
            }
            //reservationDTO.DateReservation = (System.DateTime.Now);
            addReservation(connection, reservationDTO);

        }

        public void utiliserReservation(Connection connection, ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("La réservation ne peut être null");
            }
            try
            {
                List<ReservationDTO> reservations = getReservationDAO().findByOutil(connection, reservationDTO.OutilDTO.IdOutil, ReservationDTO.ID_OUTIL_COLUMN_NAME);
                if (reservations.Count > 0)
                {
                    ReservationDTO uneReservationDTO = reservations[0];
                    if (!reservationDTO.ClientDTO.equals(uneReservationDTO.ClientDTO))
                    {
                        throw new ExistingReservationException("L'outil "
                            + uneReservationDTO.OutilDTO.Nom
                            + " (ID d'outil : "
                            + uneReservationDTO.OutilDTO.IdOutil
                            + ") est réservé pour "
                            + uneReservationDTO.ClientDTO.Nom
                            + ", "
                            + uneReservationDTO.ClientDTO.Prenom
                            + "(ID de client : "
                            + uneReservationDTO.ClientDTO.IdClient
                            + ")"
                            );
                    }
                }
                List<LocationDTO> locations = getLocationDAO().findByOutil(connection, reservationDTO.OutilDTO.IdOutil, LocationDTO.ID_OUTIL_COLUMN_NAME);
                foreach (LocationDTO uneLocationDTO in locations)
                {
                    if (uneLocationDTO.DateRetour == null)
                    {
                        throw new ExistingLoanException("Le livre "
                            + uneLocationDTO.OutilDTO.Nom
                            + "(ID d'outil : "
                            + uneLocationDTO.OutilDTO.IdOutil
                            + ") est présentement prêté à "
                            + uneLocationDTO.ClientDTO.Nom
                            + ", "
                            + uneLocationDTO.ClientDTO.Prenom
                            + "(ID de client : "
                            + uneLocationDTO.ClientDTO.IdClient
                            + ")");
                    }
                }

                if (reservationDTO.ClientDTO.NbLocations.Equals(reservationDTO.ClientDTO.LimiteLocations))
                {
                    throw new InvalidLoanLimitException("Le client "
                    + reservationDTO.ClientDTO.Nom
                    + ", "
                    + reservationDTO.ClientDTO.Prenom
                    + " (ID de client : "
                    + reservationDTO.ClientDTO.IdClient
                    + ") a atteint sa limite de locations ("
                    + reservationDTO.ClientDTO.LimiteLocations
                    + " location(s) maximum)");
                }

                LocationDTO locationDTO = new LocationDTO();
                locationDTO.ClientDTO = reservationDTO.ClientDTO;
                locationDTO.ClientDTO.NbLocations = (int.Parse(locationDTO.ClientDTO.NbLocations + 1)).ToString();
                locationDTO.OutilDTO = reservationDTO.OutilDTO;
                locationDTO.DateLocation = System.DateTime.Now.Ticks.ToString();
                // locationDTO.DateRetour = new System.DateTime();
                getLocationDAO().add(connection, locationDTO);
                annulerReservation(connection, reservationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("", daoException);
            }
        }

        /// <inheritdoc />
        public void annulerReservation(Connection connection, ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("La réservation ne peut être null");
            }
            try
            {
                deleteReservation(connection, reservationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("", daoException);
            }
        }

        /// <inheritdoc />
        public List<ReservationDTO> findByClient(Connection connection, ReservationDTO reservationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (reservationDTO == null)
            {
                throw new InvalidDTOException("La réservation ne peut être null");
            }
            try
            {
                return getReservationDAO().findByClient(connection, reservationDTO.ClientDTO.IdClient, ReservationDTO.ID_CLIENT_COLUMN_NAME);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("", daoException);
            }
        }
    }
}
