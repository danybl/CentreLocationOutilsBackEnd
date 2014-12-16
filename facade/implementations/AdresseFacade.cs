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
    /// <summary>
    /// Facade pour interagir avec le service d'adresse.
    /// </summary>
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

        #region Getters and Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.adresseService</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.adresseService</code></returns>
        private IAdresseService getAdresseService()
        {
            return this.adresseService;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.adresseService</code>.
        /// </summary>
        /// <param name="adresseService">La valeur à utiliser pour la variable d'instance <code>this.adresseService</code></param>
        private void setAdresseService(IAdresseService adresseService)
        {
            this.adresseService = adresseService;
        }

        #endregion
        #region CRUD

        public void ajouterAdresse(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseService().ajouterAdresse(connection, adresseDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceException);
            }
        }
        /// <inheritdoc />
        public void mettreAJourAdresse(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseService().mettreAJourAddresse(connection, adresseDTO);
            }
            catch (ServiceException serviceExcpetion)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceExcpetion);
            }
        }

        public void supprimerAdresse(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseService().supprimerAdresse(connection, adresseDTO);
            }
            catch (ServiceException serviceExcpetion)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceExcpetion);
            }
        }

        public AdresseDTO getAdresse(Connection connection, string idAdresse)
        {
            try
            {
               return getAdresseService().get(connection, idAdresse);
            }
            catch (ServiceException serviceExcpetion)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceExcpetion);
            }
        }

        public List<AdresseDTO> getAllAdresses(Connection connection, string sortByPropertyName)
        {
            try
            {
                return getAdresseService().getall(connection, sortByPropertyName);
            }
            catch (ServiceException serviceExcpetion)
            {
                throw new FacadeException("Un erreur s'est produit : " + serviceExcpetion);
            }
        }
        #endregion
    }
}