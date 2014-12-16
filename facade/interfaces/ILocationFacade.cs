using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les locations dans la base de données.
    /// </summary>
    public interface ILocationFacade : IFacade
    {
        /// <summary>
        /// Lit une location à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à trouver</param>
        LocationDTO getLocation(Connection connection,string  idLocation);

        /// <summary>
        /// Commencer une location.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à commencer</param>
        void commencerLocation(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Renouveler une location.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à renouveler</param>
        void renouvelerLocation(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Terminer une location.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à terminer</param>
        void terminerLocation(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Trouve les locations à partir d'un client. 
        /// Si aucune location n'est trouvé, une liste vide est retournée.  
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO"></param>
        /// <param name="sortByPropertyName">Le client de la propriété à utiliser pour classer la liste</param>
        /// <returns>Si aucune location n'est trouvée, une liste vide est retournée.</returns>
        List<LocationDTO> findByClient(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Trouve les locations à partir d'un outil. 
        /// Si aucune location n'est trouvé, une liste vide est retournée.  
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO"></param>
        /// <param name="sortByPropertyName">L'outil de la propriété à utiliser pour classer la liste</param>
        /// <returns>Si aucune location n'est trouvée, une liste vide est retournée.</returns>
        List<LocationDTO> findByOutil(Connection connection, LocationDTO locationDTO);
    }
}
