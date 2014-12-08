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
    /// <summary>
    /// Service de la table <code>location</code>.
    /// </summary>
    public class LocationService : Service, ILocationService
    {
        private ILocationDAO locationDAO;

        private IReservationDAO reservationDAO;


        /// <summary>
        /// Crée le service de la table <code>location</code>.
        /// </summary>
        /// <param name="locationDAO">Le DAO de la table <code>location</code></param>
        public LocationService(ILocationDAO locationDAO, IReservationDAO reservationDAO)
            : base()
        {
            if (locationDAO == null)
            {
                throw new InvalidDAOException("Le DAO de location ne peut être null");
            }

            setLocationDAO(locationDAO);
        }

        #region Getters & Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.locationDAO</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.locationDAO</code></returns>
        private ILocationDAO getLocationDAO()
        {
            return this.locationDAO;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.locationDAO</code>.
        /// </summary>
        /// <param name="locationDAO">La valeur à utiliser pour la variable d'instance <code>this.locationDAO</code></param>
        private void setLocationDAO(ILocationDAO locationDAO)
        {
            this.locationDAO = locationDAO;
        }

        private IReservationDAO getReservationDAO()
        {
            return this.reservationDAO;
        }

        private void setReservationDAO(IReservationDAO reservationDAO)
        {
            this.reservationDAO = reservationDAO;
        }

        #endregion

        #region CRUD


        /// <inheritdoc />
        public   void addLocation(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                getLocationDAO().add(connection, locationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        /// <inheritdoc />
        public   LocationDTO getLocation(Connection connection, string idLocation)
        {
            try
            {
                return getLocationDAO().get(connection, idLocation);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        /// <inheritdoc />
        public   void updateLocation(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                getLocationDAO().update(connection, locationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        /// <inheritdoc />
        public   void deleteLocation(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                getLocationDAO().delete(connection, locationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        /// <inheritdoc />
        public   List<LocationDTO> getAllLocations(Connection connection, string sortByPropertyName)
        {
            try
            {
                return getLocationDAO().getAll(connection, sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        #endregion

        public void commencerLocation(Connection connection, LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("La réservation ne peut être null");
            }

            List<LocationDTO> locations = getLocationDAO().findByOutil(connection, locationDTO.OutilDTO.IdOutil, LocationDTO.ID_OUTIL_COLUMN_NAME);
            foreach (LocationDTO uneLocationDTO in locations)
            {
                if (uneLocationDTO.DateRetour == null)
                {
                    throw new ExistingLoanException("Le livre "
                        + uneLocationDTO.OutilDTO.Nom
                        + " (ID d'outil : "
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

            if (locationDTO.ClientDTO.NbLocations.Equals(locationDTO.ClientDTO.LimiteLocations))
            {
                throw new InvalidLoanLimitException("Le client "
                + locationDTO.ClientDTO.Nom
                + ", "
                + locationDTO.ClientDTO.Prenom
                + " (ID de client : "
                + locationDTO.ClientDTO.IdClient
                + ") a atteint sa limite de locations ("
                + locationDTO.ClientDTO.LimiteLocations
                + " location(s) maximum)");
            }

            List<ReservationDTO> reservations = getReservationDAO().findByOutil(connection, locationDTO.OutilDTO.IdOutil, ReservationDTO.ID_OUTIL_COLUMN_NAME);
            if (reservations.Count > 0)
            {
                ReservationDTO uneReservationDTO = reservations[0];
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

            locationDTO.ClientDTO.NbLocations = (int.Parse(locationDTO.ClientDTO.NbLocations + 1)).ToString();
            //locationDTO.DateLocation = System.DateTime.Today;
            // locationDTO.DateRetour = null;
            addLocation(connection, locationDTO);
        }

        public void renouvelerLocation(Connection connection, LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("La location ne peut être null");
            }
            if (locationDTO.DateRetour != null)
            {
                throw new MissingLoanException("L'outil "
                    + locationDTO.OutilDTO.Nom
                    + " (ID d'outil : "
                    + locationDTO.OutilDTO.IdOutil
                    + ") est retourné"
                    );
            }
            //locationDTO.DateLocation = (System.DateTime.Now);
            //locationDTO.DateRetour = null
            updateLocation(connection, locationDTO);
        }

        public void terminerLocation(Connection connection, LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("La location ne peut être null");
            }
            if (locationDTO.DateRetour != null)
            {
                throw new MissingLoanException("L'outil "
                    + locationDTO.OutilDTO.Nom
                    + " (ID d'outil : "
                    + locationDTO.OutilDTO.IdOutil
                    + ") est retourné"
                    );
            }

            locationDTO.ClientDTO.NbLocations = int.Parse(locationDTO.ClientDTO.NbLocations).ToString();
            //locationDTO.DateRetour = System.DateTime.Now;
            updateLocation(connection, locationDTO);
        }

        /// <inheritdoc />
        public List<LocationDTO> findByClient(Connection connection, LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("La lcoation ne peut être null");
            }
            try
            {
                return getLocationDAO().findByClient(connection, locationDTO.ClientDTO.IdClient, LocationDTO.ID_CLIENT_COLUMN_NAME);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("", daoException);
            }
        }

        public List<LocationDTO> findByOutil(Connection connection, LocationDTO locationDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (locationDTO == null)
            {
                throw new InvalidDTOException("La lcoation ne peut être null");
            }
            try
            {
                return getLocationDAO().findByOutil(connection, locationDTO.OutilDTO.IdOutil, LocationDTO.ID_OUTIL_COLUMN_NAME);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("", daoException);
            }
        }


        //TODO findByDatePret() et findByDateRetour();
    }
}
