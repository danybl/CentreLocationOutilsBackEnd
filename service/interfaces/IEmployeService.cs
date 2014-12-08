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
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="employeDTO"></param>
        void addEmploye(Connection connection,
        EmployeDTO employeDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        EmployeDTO getEmploye(Connection connection,
        string primaryKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="employeDTO"></param>
        void updateEmploye(Connection connection,
        EmployeDTO employeDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="employeDTO"></param>
        void deleteEmploye(Connection connection,
        EmployeDTO employeDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<EmployeDTO> getAllEmployes(Connection connection,
        string sortByPropertyName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="nom"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<EmployeDTO> findByNom(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="employeDTO"></param>
        void inscrireEmploye(Connection connection, EmployeDTO employeDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="employeDTO"></param>
        void desinscrireEmploye(Connection connection, EmployeDTO employeDTO);
    }
}
