using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;


namespace CentreLocationOutils.service.interfaces
{
    /// <summary>
    /// L'interface pour EmployeService
    /// </summary>
    public interface IEmployeService : IService
    {
        /// <summary>
        /// Ajoute une nouveau employé dans la base de données.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="employeDTO">employeDTO L'employe à ajouter</param>
        void addEmploye(Connection connection,
        EmployeDTO employeDTO);

        /// <summary>
        /// Lit un employé à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        EmployeDTO getEmploye(Connection connection,
        string primaryKey);

        /// <summary>
        /// Met à jour un employé dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employe à mettre à jour</param>
        void updateEmploye(Connection connection,
        EmployeDTO employeDTO);

        /// <summary>
        /// Supprime un employé de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employe à enlever</param>
        void deleteEmploye(Connection connection,
        EmployeDTO employeDTO);

        /// <summary>
        /// Trouve tous les employés de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun employe n'est trouvé, une liste vide est retournée.</returns>
        List<EmployeDTO> getAllEmployes(Connection connection,
        string sortByPropertyName);

        /// <summary>
        /// Trouve les employés à partir d'un nom. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucun employés n'est trouvé, une liste vide est retournée. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="nom">Le nom à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun employe n'est trouvée, une liste vide est retournée.</returns>
        List<EmployeDTO> findByNom(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// Inscrire un employé
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employe à inscrire</param>
        void inscrireEmploye(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// Desinscrire un employé
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="employeDTO">L'employe à desinscrire</param>
        void desinscrireEmploye(Connection connection, EmployeDTO employeDTO);
    }
}
