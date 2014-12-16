using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.service.interfaces;
using System.Collections.Generic;

namespace CentreLocationOutils.service.implementations
{
    /// <summary>
    /// Service de la table <code>outil</code>.
    /// </summary>
    public class OutilService : Service, IOutilService
    {
        private IOutilDAO outilDAO;


        /// <summary>
        /// Crée le service de la table <code>outil</code>.
        /// </summary>
        /// <param name="outilDAO">Le DAO de la table <code>outil</code></param>
        public OutilService(IOutilDAO outilDAO)
            : base()
        {
            if (outilDAO == null)
            {
                throw new InvalidDAOException("Le DAO de l'outil ne peut être null");
            }
            setOutilDAO(outilDAO);
        }
        #region Getters & Setters
        /// <summary>
        /// Getter de la variable d'instance outilDAO
        /// </summary>
        /// <returns>La valeur de la variable d'instance</returns>
        private IOutilDAO getOutilDAO()
        {
            return this.outilDAO;
        }
        /// <summary>
        /// Setter de la variable d'instance outilDAO
        /// </summary>
        /// <param name="outilDAO">Valeur à utiliser pour la variable d'instance</param>
        private void setOutilDAO(IOutilDAO outilDAO)
        {
            this.outilDAO = outilDAO;
        }
        #endregion

        #region CRUD
        /// <inheritdoc />
        public void addOutil(Connection connection,
        OutilDTO outilDTO)
        {
            try
            {
                getOutilDAO().add(connection,
                    outilDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }
        /// <inheritdoc />
        public OutilDTO getOutil(Connection connection,
            string idOutil)
        {
            try
            {
                return getOutilDAO().get(connection,
                    idOutil);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        /// <inheritdoc />
        public void updateOutil(Connection connection,
            OutilDTO outilDTO)
        {
            try
            {
                getOutilDAO().update(connection,
                    outilDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        public void deleteOutil(Connection connection, OutilDTO outilDTO)
        {
            try
            {
                getOutilDAO().delete(connection, outilDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }

        /// <inheritdoc />
        public List<OutilDTO> getAllOutils(Connection connection,
            string sortByPropertyName)
        {
            try
            {
                return getOutilDAO().getAll(connection,
                    sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Il y a eu un erreur : ", daoException);
            }
        }
        /// <inheritdoc />
        public void acquerirOutil(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
           
                addOutil(connection, outilDTO);
        }

        public void mettreAJourOutil(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
            updateOutil(connection, outilDTO);
        }
        /// <inheritdoc />
        public void supprimerOutil(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
            
                deleteOutil(connection, outilDTO);
        }
        /// <inheritdoc />
        public List<OutilDTO> findByNom(Connection connection, OutilDTO outilDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (outilDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
            try
            {
                return getOutilDAO().findByNom(connection, outilDTO.Nom, OutilDTO.NOM_COLUMN_NAME);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("", daoException);
            }
        }

        #endregion
    }
}
