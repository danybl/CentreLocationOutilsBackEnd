using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les outils dans la base de données.
    /// </summary>
    public interface IOutilFacade : IFacade
    {
        /// <summary>
        /// Lit un outil à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="primaryKey">L'outil à trouver</param>
        OutilDTO getOutil(Connection connection, string idOutil);

        /// <summary>
        /// Acquerir un outil.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="outilDTO">L'outil à acquerir</param>
        void acquerirOutil(Connection connection, OutilDTO outilDTO);

        /// <summary>
        /// Vendre un outil.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="outilDTO">L'outil à vendre</param>
        void vendreOutil(Connection connection, OutilDTO outilDTO);

        /// <summary>
        /// Trouve les outils à partir d'une nom. 
        /// Si aucun outil n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="nom">Le nom à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun outil n'est trouvée, une liste vide est retournée.</returns>
        List<OutilDTO> findByNom(Connection connection, OutilDTO outilDTO);
    }
}
