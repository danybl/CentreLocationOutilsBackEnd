using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.facade.implementations
{
    /// <summary>
    /// Facade pour interagir avec le service de client.
    /// </summary>
    public class ClientFacade : Facade, IClientFacade
    {
        private IClientService clientService;

        public ClientFacade(IClientService clientService)
            : base()
        {
            if (clientService == null)
            {
                throw new InvalidServiceException("Le service de client ne peut être null");
            }
            setClientService(clientService);
        }

        #region Getters and Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.clientService</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.clientService</code></returns>
        private IClientService getClientService()
        {
            return this.clientService;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.clientService</code>.
        /// </summary>
        /// <param name="clientService">La valeur à utiliser pour la variable d'instance <code>this.clientService</code></param>
        private void setClientService(IClientService clientService)
        {
            this.clientService = clientService;
        }

        #endregion
        #region CRUD
        /// <inheritdoc />
        public ClientDTO getClient(Connection connection, string idClient)
        {
            try
            {
                return getClientService().getClient(connection, idClient);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }

        /// <inheritdoc />
        public List<ClientDTO> findByNom(Connection connection, String nom, String SortByPropertyName)
        {
            try
            {
                return getClientService().findByNom(connection, nom, SortByPropertyName);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }
        /// <inheritdoc />
        public void inscrire(Connection connection, ClientDTO clientDTO)
        {
            try
            {
                getClientService().inscrireClient(connection, clientDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }

        /// <inheritdoc />
        public void desinscrire(Connection connection, ClientDTO clientDTO)
        {
            try
            {
                getClientService().desinscrireClient(connection, clientDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }
        /// <inheritdoc />
        public void mettreAJourClient(Connection connection, ClientDTO clientDTO)
        {
            try
            {
                getClientService().updateClient(connection, clientDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }
        /// <inheritdoc />
        public List<ClientDTO> getAllClients(Connection connection, string sortByPropertyName)
        {
            try
            {
                return getClientService().getAllClients(connection, ClientDTO.ID_CLIENT_COLUMN_NAME);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }
        #endregion
    }
}
