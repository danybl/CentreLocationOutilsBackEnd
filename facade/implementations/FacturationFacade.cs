using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.facade.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.service.interfaces;

namespace CentreLocationOutils.facade.implementations
{
    /// <summary>
    /// Facade pour interagir avec le service de facture.
    /// </summary>
    public class FacturationFacade : Facade, IFacturationFacade
    {
        private IFacturationService facturationService;

        public FacturationFacade(IFacturationService facturationService) : base() {

            if (facturationService == null)
            {
                throw new InvalidServiceException("Le service de facture ne peut être null");
            }
            setFacturationService(facturationService);
        }

        #region Getters and Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.facturationFacade</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.facturationFacade</code></returns>
        private IFacturationService getFacturationService()
        {
            return this.facturationService;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.facturationFacade</code>.
        /// </summary>
        /// <param name="facturationFacade">La valeur à utiliser pour la variable d'instance <code>this.facturationFacade</code></param>
        private void setFacturationService(IFacturationService facturationService)
        {
            this.facturationService = facturationService;
        }

        #endregion

        public   List<FacturationDTO> findByClient(Connection connection, string idClient, string sortByPropertyName) {
            try
            {
               return getFacturationService().findByClient(connection, idClient, sortByPropertyName);
            }
            catch (ServiceException serviceExcpetion)
            {
                throw new FacadeException("", serviceExcpetion);
            }
        }

        public   List<FacturationDTO> findByEmploye(Connection connection, string idEmploye, string sortByPropertyName)
        {
            try {
                return getFacturationService().findByEmploye(connection, idEmploye, sortByPropertyName);
            }
            catch (ServiceException serviceExcpetion) {
                throw new FacadeException("", serviceExcpetion);
            }
        }
    }
}
