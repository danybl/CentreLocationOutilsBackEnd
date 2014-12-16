using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les employés dans la base de données.
    /// </summary>
    public interface IEmployeFacade : IFacade
    {
        /// <summary>
        /// Inscrire un employé
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employé à inscrire</param>
        void inscrireEmploye(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// Desinscrire un employé
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employé à desinscrire</param>
        void desinscrireEmploye(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// Lit un employé à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="idEmploye">L'id de L'employé</param>
        /// <returns></returns>
        EmployeDTO getEmploye(Connection connection, string idEmploye);

        /// <summary>
        /// Obtient tous les employes
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<EmployeDTO> getAllEmployes(Connection connection, string sortByPropertyName);
    }
}
