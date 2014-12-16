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
    /// Service de la table <code>employe</code>.
    /// </summary>
    public class EmployeService : Service, IEmployeService
    {
        private IEmployeDAO employeDAO;

        /// <summary>
        /// Crée le service de l'employe <code>employe</code>.
        /// </summary>
        /// <param name="employeDAO">Le DAO de la table <code>employe</code></param>
        public EmployeService(IEmployeDAO employeDAO)
            : base()
        {
            if (employeDAO == null)
            {
                throw new InvalidDAOException("Le DAO de l'employé ne peut être null");
            }
            setEmployeDAO(employeDAO);
        }

        #region Getters & Setters
        /// <summary>
        /// Getter de la variable d'instance employeDAO
        /// </summary>
        /// <returns>La valeur de la variable d'instance</returns>
        private IEmployeDAO getEmployeDAO()
        {
            return this.employeDAO;
        }
        /// <summary>
        /// Setter de la variable d'instance employeDAO
        /// </summary>
        /// <param name="employeDAO">Valeur à utiliser pour la variable d'instance</param>
        private void setEmployeDAO(IEmployeDAO employeDAO)
        {
            this.employeDAO = employeDAO;
        }

        #endregion

        #region CRUD
        /// <inheritdoc />
        public void addEmploye(Connection connection,
        EmployeDTO employeDTO)
        {
            try
            {
                getEmployeDAO().add(connection,
                    employeDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        public EmployeDTO getEmploye(Connection connection,
        string primaryKey)
        {
            try
            {
                return getEmployeDAO().get(connection,
                    primaryKey);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }


        /// <inheritdoc />
        public void updateEmploye(Connection connection,
            EmployeDTO employeDTO)
        {
            try
            {
                getEmployeDAO().update(connection,
                    employeDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public void deleteEmploye(Connection connection,
            EmployeDTO employeDTO)
        {
            try
            {
                getEmployeDAO().delete(connection,
                    employeDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public List<EmployeDTO> getAllEmployes(Connection connection,
            string sortByPropertyName)
        {
            try
            {
                return getEmployeDAO().getAll(connection,
                    sortByPropertyName);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public List<EmployeDTO> findByNom(Connection connection, EmployeDTO employeDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (employeDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
            try
            {
                return getEmployeDAO().findByNom(connection, employeDTO.Nom, EmployeDTO.NOM_COLUMN_NAME);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public void inscrireEmploye(Connection connection, EmployeDTO employeDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (employeDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
                addEmploye(connection, employeDTO);

        }

        /// <inheritdoc />
        public void desinscrireEmploye(Connection connection, EmployeDTO employeDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (employeDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }

            deleteEmploye(connection, employeDTO);
        }

        public void mettreAJourEmploye(Connection connection, EmployeDTO employeDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (employeDTO == null)
            {
                throw new InvalidDTOException("L'employé ne peut être null");
            }
            updateEmploye(connection, employeDTO);
        }

        #endregion
    }
}
