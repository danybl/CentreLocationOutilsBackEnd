using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.service.interfaces;
using System;
using System.Collections.Generic;

namespace CentreLocationOutils.service.implementations
{
    /// <summary>
    /// Service de la table <code>adresse</code>.
    /// </summary>
    public class AdresseService : Service, IAdresseService
    {
        private IAdresseDAO adresseDAO;

        /// <summary>
        /// Crée le service de la table <code>adresse</code>.
        /// </summary>
        /// <param name="adresseDAO">Le DAO de la table <code>adresse</code></param>
        public AdresseService(IAdresseDAO adresseDAO)
            : base()
        {
            if (adresseDAO == null)
            {
                throw new InvalidDAOException("Le DAO d'adresse ne peut être null");
            }

            setAdresseDAO(adresseDAO);
        }
        #region Getters & Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.adresseDAO</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.adresseDAO</code></returns>
        private IAdresseDAO getAdresseDAO()
        {
            return this.adresseDAO;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.adresseDAO</code>.
        /// </summary>
        /// <param name="adresseDAO">La valeur à utiliser pour la variable d'instance <code>this.adresseDAO</code></param>
        private void setAdresseDAO(IAdresseDAO adresseDAO)
        {
            this.adresseDAO = adresseDAO;
        }

        #endregion

        #region CRUD
        /// <inheritdoc />
        public void add(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseDAO().add(connection, adresseDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public AdresseDTO get(Connection connection, string idAdresse)
        {
            try
            {
                return getAdresseDAO().get(connection, idAdresse);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public void update(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseDAO().update(connection, adresseDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public void delete(Connection connection, AdresseDTO adresseDTO)
        {
            try
            {
                getAdresseDAO().delete(connection, adresseDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public List<AdresseDTO> getall(Connection connection, string sortByPropertyName)
        {
            try
            {
                return (List<AdresseDTO>)getAdresseDAO().getAll(connection, sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public List<AdresseDTO> findByVille(Connection connection, string ville, string sortByPropertyName)
        {
            try
            {
                return (List<AdresseDTO>)getAdresseDAO().findByVille(connection, ville, sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : " + daoException);
            }
        }

        #endregion



        void IAdresseService.get(Connection connection, string idAdresse)
        {
            throw new NotImplementedException();
        }

        public void changerAdresse(Connection connection, AdresseDTO adresseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
