using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.service.interfaces;
using CentreLocationOutils.facade.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.facade.implementations
{
    public class AdresseFacade : IAdresseFacade
    {
        private IAdresseService adresseService;
        public AdresseFacade(IAdresseService adresseService)
            : base()
        {
            if (adresseService == null)
            {
                throw new InvalidServiceException("Le service d'adresse ne peut être null");
            }
            setAdresseService(adresseService);
        }

        private IAdresseService getAdresseService()
        {
            return this.adresseService;
        }

        private void setAdresseService(IAdresseService adresseService)
        {
            this.adresseService = adresseService;
        }

        public   void changerAdresse(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseService().changerAdresse(connection, adresseDTO);
            }
            catch (ServiceException serviceExcpetion)
            {
                throw new FacadeException("", serviceExcpetion);
            }
        }


        public void changerLocation(Connection connection, AdresseDTO adresseDTO)
        {
            //TODO changer location
        }
    }
}