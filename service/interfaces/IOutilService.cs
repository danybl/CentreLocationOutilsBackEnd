using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;


namespace CentreLocationOutils.service.interfaces
{
    /// <summary>
    /// Interface de base pour les services.<br/>
    /// Toutes les interfaces de service devrait en hériter.
    /// </summary>
    public interface IOutilService : IService
    {
        /// <summary>
        /// Ajoute un nouveau outil dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="outilDTO">L'outil à ajouter</param>
        void addOutil(Connection connection,
        OutilDTO outilDTO);

        /// <summary>
        /// Lit un outil à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="primaryKey">L'outil à trouver</param>
        OutilDTO getOutil(Connection connection,
        string primaryKey);

        /// <summary>
        /// Met à jour un outil dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser<</param>
        /// <param name="outilDTO">L'outil à mettre à jour</param>
        void updateOutil(Connection connection,
        OutilDTO outilDTO);

        /// <summary>
        /// Supprime un outil de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="outilDTO">L'outil à enlever</param>
        void deleteOutil(Connection connection,
        OutilDTO outilDTO);

        /// <summary>
        /// Trouve tous les outils de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun outil n'est trouvée, une liste vide est retournée.</returns>
        List<OutilDTO> getAllOutils(Connection connection,
        string sortByPropertyName);

        /// <summary>
        /// Trouve les outils à partir d'une nom. 
        /// Si aucun outil n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="nom">Le nom à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun outil n'est trouvée, une liste vide est retournée.</returns>
        
        List<OutilDTO> findByNom(Connection connection, OutilDTO outil);
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
    }
}
