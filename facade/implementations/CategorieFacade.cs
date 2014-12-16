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
using CentreLocationOutils.exception.db;

namespace CentreLocationOutils.facade.implementations
{
    /// <summary>
    /// Facade pour interagir avec le service de categorie.
    /// </summary>
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

        #region Getters and Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.categorieService</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.categorieService</code></returns>
        private ICategorieService getCategorieService()
        {
            return this.categorieService;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.categorieService</code>.
        /// </summary>
        /// <param name="categorieService">La valeur à utiliser pour la variable d'instance <code>this.categorieService</code></param>
        private void setCategorieService(ICategorieService categorieService)
        {
            this.categorieService = categorieService;
        }

        #endregion
        #region CRUD
        /// <inheritdoc />
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

        /// <inheritdoc />
        public CategorieDTO getCategorie(Connection connection, string idCategorie)
        {
            try
            {
                return getCategorieService().get(connection, idCategorie);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }
        #endregion
    }
}
