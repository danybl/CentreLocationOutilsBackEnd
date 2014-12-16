using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.service.interfaces;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.implementations
{
    /// <summary>
    /// Facade pour interagir avec le service de location.
    /// </summary>
    public class LocationFacade : ILocationFacade
    {
        private ILocationService locationService;

        private IEmployeService employeService;

        public LocationFacade(ILocationService locationService)
            : base()
        {
            if (locationService == null)
            {
                throw new InvalidServiceException("Le service de location ne peut être null");
            }
            setLocationService(locationService);
        }

        #region Getters and Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.locationFacade</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.locationFacade</code></returns>
        private ILocationService getLocationService()
        {
            return this.locationService;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.locationFacade</code>.
        /// </summary>
        /// <param name="locationFacade">La valeur à utiliser pour la variable d'instance <code>this.locationFacade</code></param>
        private void setLocationService(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        #endregion

        #region CRUD

        /// <inheritdoc />
        private LocationDTO getLocation(Connection connection, string idLocation)
        {
            try
            {
                return getLocationService().getLocation(connection, idLocation);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        /// <inheritdoc />
        public void commencerLocation(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                getLocationService().commencerLocation(connection, locationDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        /// <inheritdoc />
        public void renouvelerLocation(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                getLocationService().renouvelerLocation(connection, locationDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        /// <inheritdoc />
        public void terminerLocation(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                getLocationService().terminerLocation(connection, locationDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        /// <inheritdoc />
        public List<LocationDTO> findByClient(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                return getLocationService().findByClient(connection, locationDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        /// <inheritdoc />
        public List<LocationDTO> findByOutil(Connection connection, LocationDTO locationDTO)
        {
            try
            {
                return getLocationService().findByClient(connection, locationDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }
        #endregion
    }
}
