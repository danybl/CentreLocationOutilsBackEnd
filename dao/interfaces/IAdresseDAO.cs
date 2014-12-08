using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.dao.interfaces
{
    public interface IAdresseDAO : IDAO
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à ajouter</param>
        void add(Connection connection,
            AdresseDTO adresseDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données
        /// </summary>
        /// <param name="connection">La connection ;a utiliser</param>
        /// <param name="primaryKey">La clé primaire du DTO à lire</param>
        /// <returns>Le DTO à retourner</returns>
        AdresseDTO get(Connection connection,
            string primaryKey);

        /// <summary>
        /// Met à jour un DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à mettre à jour</param>
        void update(Connection connection,
            AdresseDTO adresseDTO);

        /// <summary>
        /// Supprime un DTO de  la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="dto">Le DTO à supprimer</param>
        void delete(Connection connection,
            AdresseDTO adresseDTO);

        /// <summary>
        /// Trouve tous les DTOs de la base de données. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        /// DTO n'est trouvé, une List vide est retournée.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à uriliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<AdresseDTO> getAll(Connection connection,
         string sortByPropertyName);

        /// <summary>
        /// Trouve les adresses à partir d'une ville. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.
        /// Si aucune adresse * n'est trouvé, une {@link List} vide est retournée.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="ville">La ville à trouver</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à uriliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<AdresseDTO> findByVille(Connection connection, string ville, string sortByPropertyName);
    }
}
