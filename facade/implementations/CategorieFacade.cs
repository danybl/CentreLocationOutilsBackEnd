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
    public class CategorieFacade : ICategorieFacade
    {
        private ICategorieService categorieService;
        public CategorieFacade(ICategorieService categorieService)
            : base()
        {
            if (categorieService == null)
            {
                throw new InvalidServiceException("Le service d'adresse ne peut être null");
            }
            setCategorieService(categorieService);
        }

        private ICategorieService getCategorieService()
        {
            return this.categorieService;
        }

        private void setCategorieService(ICategorieService categorieService)
        {
            this.categorieService = categorieService;
        }


        public List<CategorieDTO> findByNom(Connection connection,
        String nom,
        String sortByPropertyName)
        {
            try
            {
                return getCategorieService().findByNom(connection, nom, sortByPropertyName);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }
    }
}
