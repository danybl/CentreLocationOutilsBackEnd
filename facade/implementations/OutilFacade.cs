using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.service.interfaces;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.implementations
{
    public class OutilFacade : Facade, IOutilFacade
    {
        private IOutilService outilService;

        public OutilFacade(IOutilService outilService)
            : base()
        {
            if (outilService == null)
            {
                throw new InvalidServiceException("Le service d'outil ne peut être null");
            }
            setOutilService(outilService);
        }

        //Getters and Setters

        private IOutilService getOutilService()
        {
            return this.outilService;
        }

        private void setOutilService(IOutilService outilService)
        {
            this.outilService = outilService;
        }

        public OutilDTO getOutil(Connection connection, string idOutil)
        {
            try
            {
                return getOutilService().getOutil(connection, idOutil);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        public void acquerirOutil(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'outil ne peut être null");
            }
            try
            {
                getOutilService().acquerirOutil(connection, outilDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Il y a eu un erreur : " + serviceException);
            }
        }

        public void vendreOutil(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'outil ne peut être null");
            }
            try
            {
                getOutilService().vendreOutil(connection, outilDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Il y a eu un erreur : " + serviceException);
            }
        }

        public List<OutilDTO> findByNom(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'outil ne peut être null");
            }
            try
            {
                return getOutilService().findByNom(connection, outilDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

    }
}

