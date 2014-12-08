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

        private IClientService getClientService()
        {
            return this.clientService;
        }


        private void setClientService(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public   ClientDTO getClient(Connection connection, string idClient)
        {
            try
            {
                return getClientService().getClient(connection, idClient);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }


        public List<ClientDTO> findByNom(Connection connection, String nom, String SortByPropertyName)
        {
            try
            {
                return getClientService().findByNom(connection, nom, SortByPropertyName);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        public void inscrire(Connection connection, ClientDTO clientDTO)
        {
            try
            {
                getClientService().inscrireClient(connection, clientDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }
    }
}
