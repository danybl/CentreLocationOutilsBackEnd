using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;


namespace CentreLocationOutils.service.interfaces
{
    /// <summary>
    /// L'interface pour OutilService
    /// </summary>
    public interface IOutilService : IService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="outilDTO"></param>
        void addOutil(Connection connection,
        OutilDTO outilDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        OutilDTO getOutil(Connection connection,
        string primaryKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="outilDTO"></param>
        void updateOutil(Connection connection,
        OutilDTO outilDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="outilDTO"></param>
        void deleteOutil(Connection connection,
        OutilDTO outilDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<OutilDTO> getAllOutils(Connection connection,
        string sortByPropertyName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="nom"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<OutilDTO> findByNom(Connection connection, OutilDTO outil);

        void acquerirOutil(Connection connection, OutilDTO outilDTO);

        void vendreOutil(Connection connection, OutilDTO outilDTO);
    }
}
