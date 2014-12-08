using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;

namespace CentreLocationOutils.dao.interfaces
{
    public interface IClientDAO : IDAO
    {

        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à ajouter</param>
        void add(Connection connection,
          ClientDTO clientDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données
        /// </summary>
        /// <param name="connection">La connection ;a utiliser</param>
        /// <param name="primaryKey">La clé primaire du DTO à lire</param>
        /// <returns>Le DTO à retourner</returns>
        ClientDTO get(Connection connection,
          string primaryKey);

        /// <summary>
        /// Met à jour un DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à mettre à jour</param>
        void update(Connection connection,
          ClientDTO clientDTO);

        /// <summary>
        /// Supprime un DTO de  la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à supprimer</param>
        void delete(Connection connection,
          ClientDTO clientDTOs);

        /// <summary>
        /// Trouve tous les DTOs de la base de données. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        /// DTO n'est trouvé, une List vide est retournée.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à uriliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<ClientDTO> getAll(Connection connection,
       string sortByPropertyName);


        ///<summary>Trouve les clients à partir d'un nom. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun client
        ///n'est trouvé, une liste vide est retournée.</summary>>
        /// <param name="connection">La connexion à utiliser</param>
        ///<param name="nom">Le nom à trouver</param>
        ///<param name="sortByPropertyName">The nom de la propriété à utiliser pour classer</param>
        /// <returns> La liste des clients correspondants à une liste vide sinon</returns>

        List<ClientDTO> findByNom(Connection connection,
          String nom,
          String sortByPropertyName);

    }
}
