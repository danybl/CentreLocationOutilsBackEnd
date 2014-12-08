using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les employes dans la base de données.
    /// </summary>
    public interface IEmployeFacade : IFacade
    {
        /// <summary>
        /// Inscrire un employe
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employe à inscrire</param>
        void inscrireEmploye(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// Desinscrire un employe
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employe à desinscrire</param>
        void desinscrireEmploye(Connection connection, EmployeDTO employeDTO);

        EmployeDTO getEmploye(Connection connection, string idEmploye);
    }
}
