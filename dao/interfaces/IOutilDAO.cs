using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;

namespace CentreLocationOutils.dao.interfaces
{
    public interface IOutilDAO : IDAO
    {

        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à ajouter</param>
        void add(Connection connection,
          OutilDTO outilDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données
        /// </summary>
        /// <param name="connection">La connection ;a utiliser</param>
        /// <param name="primaryKey">La clé primaire du DTO à lire</param>
        /// <returns>Le DTO à retourner</returns>
        OutilDTO get(Connection connection,
          string primaryKey);

        /// <summary>
        /// Met à jour un DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à mettre à jour</param>
        void update(Connection connection,
          OutilDTO outilDTO);

        /// <summary>
        /// Supprime un DTO de  la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à supprimer</param>
        void delete(Connection connection,
          OutilDTO outilDTO);

        /// <summary>
        /// Trouve tous les DTOs de la base de données. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        /// DTO n'est trouvé, une List vide est retournée.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à uriliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<OutilDTO> getAll(Connection connection,
        string sortByPropertyName);

        ///<summary>Trouve les outils à partir d'un nom. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun outil
        ///n'est trouvé, une {@link List} vide est retournée.</summary>>
        /// <param name="connection">La connexion à utiliser</param>
        ///<param name="nom">Le nom à trouver</param>
        ///<param name="sortByPropertyName">The nom de la propriété à utiliser pour classer</param>
        /// <returns> La liste des outils correspondants à une liste vide sinon</returns>

        List<OutilDTO> findByNom(Connection connection,
          String nom,
          String sortByPropertyName);
    }
}
