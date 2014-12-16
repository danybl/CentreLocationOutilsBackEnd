using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.service.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CentreLocationOutils.service.implementations
{
    /// <summary>
    /// Service de la table <code>categorie</code>.
    /// </summary>
    public class CategorieService : Service, ICategorieService
    {

        private ICategorieDAO categorieDAO;

        /// <summary>
        /// Crée le service de la table <code>categorie</code>.
        /// </summary>
        /// <param name="categorieDAO">Le DAO de la table <code>categorie</code></param>
        public CategorieService(ICategorieDAO categorieDAO)
        {

            if (categorieDAO == null)
            {
                throw new InvalidDAOException("Le DAO de categorie ne peut être null");
            }
            setCategorieDAO(categorieDAO);
        }

        #region Getters & Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.categorieDAO</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.categorieDAO</code></returns>
        private ICategorieDAO getCategorieDAO()
        {
            return this.categorieDAO;
        }
        /// <summary>
        /// Setter de la variable d'instance <code>this.categorieDAO</code>.
        /// </summary>
        /// <param name="categorieDAO">La valeur à utiliser pour la variable d'instance <code>this.categorieDAO</code></param>
        private void setCategorieDAO(ICategorieDAO categorieDAO)
        {
            this.categorieDAO = categorieDAO;
        }

        #endregion

        #region CRUD
        /// <inheritdoc />
        public void add(Connection connection, CategorieDTO categorieDTO)
        {
            try
            {
                getCategorieDAO().add(connection,
                    categorieDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }
        /// <inheritdoc />
        public CategorieDTO get(Connection connection, String idCategorie)
        {
            try
            {
                return getCategorieDAO().get(connection,
                    idCategorie);
            }
            catch (DAOException daoException)
            {
                throw new DAOException(daoException);
            }
        }

        /// <inheritdoc />
        public void update(Connection connection,
        CategorieDTO categorieDTO)
        {
            try
            {
                getCategorieDAO().update(connection,
                    categorieDTO);
            }
            catch (DAOException daoException)
            {
                throw new DAOException(daoException);
            }
        }
        /// <inheritdoc />
        public void delete(Connection connection,
        CategorieDTO categorieDTO)
        {
            try
            {
                getCategorieDAO().delete(connection,
                    categorieDTO);
            }
            catch (DAOException daoException)
            {
                throw new DAOException(daoException);
            }
        }
        /// <inheritdoc />
        public List<CategorieDTO> getAll(Connection connection,
        String sortByPropertyName)
        {
            try
            {
                return getCategorieDAO().getAll(connection,
                    sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new DAOException(daoException);
            }
        }
        /// <inheritdoc />
        public List<CategorieDTO> findByNom(Connection connection,
        String nom,
        String sortByPropertyName)
        {
            try
            {
                return getCategorieDAO().findByNom(connection,
                    nom,
                    sortByPropertyName);
            }
            catch (DAOException DAOException)
            {
                throw new DAOException(DAOException);
            }
        }
        #endregion

        public void ajouterCategorie(Connection connection, CategorieDTO categorieDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut pas etre null");
            }
            if (categorieDTO == null)
            {
                throw new InvalidDTOException("La categorieDTO ne peut pas etre null");
            }
           add(connection, categorieDTO);
        }

        public void mettreAJourCategorie(Connection connection, CategorieDTO categorieDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut pas etre null");
            }
            if (categorieDTO == null)
            {
                throw new InvalidDTOException("La categorieDTO ne peut pas etre null");
            }
            update(connection, categorieDTO);
        }

        public void supprimerCategorie(Connection connection, CategorieDTO categorieDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut pas etre null");
            }
            if (categorieDTO == null)
            {
                throw new InvalidDTOException("La categorieDTO ne peut pas etre null");
            }
            delete(connection, categorieDTO);
        }
    }
}