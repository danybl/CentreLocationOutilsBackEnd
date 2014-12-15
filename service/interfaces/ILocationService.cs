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
    /// Interface de base pour les services.<br/>
    /// Toutes les interfaces de service devrait en hériter.
    /// </summary>
    public interface ILocationService : IService
    {
        /// <summary>
        /// Ajoute une nouvelle location dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à ajouter</param>
        void addLocation(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Lit une location à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à trouver</param>
        LocationDTO getLocation(Connection connection, string idLocation);

        /// <summary>
        /// Met à jour une location dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à mettre à jour</param>
        void updateLocation(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Supprime une location de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="locationDTO">La location à enlever</param>
        void deleteLocation(Connection connection, LocationDTO locationDTO);

        /// <summary>
        /// Trouve tous les locations de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune location n'est trouvée, une liste vide est retournée.</returns>
        List<LocationDTO> getAllLocations(Connection connection, string sortByPropertyName);

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
