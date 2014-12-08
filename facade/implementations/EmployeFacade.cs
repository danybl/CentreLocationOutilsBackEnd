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
    /// <summary>
    /// Facade pour interagir avec le service d'employe.
    /// </summary>
    public class EmployeFacade : Facade, IEmployeFacade
    {
        private IEmployeService employeService;

        public EmployeFacade(IEmployeService employeService) : base() {
            if (employeService == null)
            {
                throw new InvalidServiceException("Le service d'employe ne peut être null");
            }
            setEmployeService(employeService);
        }

        #region Getters and Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.employeService</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.employeService</code></returns>
        private IEmployeService getEmployeService()
            {
                return this.employeService;
            }

        /// <summary>
        /// Setter de la variable d'instance <code>this.employeService</code>.
        /// </summary>
        /// <param name="employeService">La valeur à utiliser pour la variable d'instance <code>this.employeService</code></param>
        private void setEmployeService(IEmployeService employeService)
            {
                this.employeService = employeService;
            }

        #endregion

        public EmployeDTO getEmploye(Connection connection, string idEmploye)
        {
            try
            {
                return getEmployeService().getEmploye(connection, idEmploye);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("", serviceException);
            }
        }

        /// <inheritdoc />
        public   void inscrireEmploye(Connection connection, EmployeDTO employeDTO)
        {
            try
            {
                getEmployeService().inscrireEmploye(connection,
                    employeDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Il y a eu un erreur : " + serviceException);
            }
        }

        /// <inheritdoc />
        public   void desinscrireEmploye(Connection connection, EmployeDTO employeDTO)
        {
            try
            {
                getEmployeService().desinscrireEmploye(connection,
                    employeDTO);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException("Il y a eu un erreur : " + serviceException);
            }
        }
    }
}
