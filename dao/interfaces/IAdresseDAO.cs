using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.dao.interfaces
{
    public interface IAdresseDAO : IDAO
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de donnees
        /// </summary>
        /// <param name="connection">La connection a utiliser</param>
        /// <param name="dto">Le DTO a ajouter</param>
        void add(Connection connection,
            AdresseDTO adresseDTO);

        /// <summary>
        /// Lit un DTO a partir de la base de donnees
        /// </summary>
        /// <param name="connection">La connection a utiliser</param>
        /// <param name="primaryKey">La cle primaire du DTO a lire</param>
        /// <returns>Le DTO a retourner</returns>
        AdresseDTO get(Connection connection,
            string primaryKey);

        /// <summary>
        /// Met a jour un DTO dans la base de donnees
        /// </summary>
        /// <param name="connection">La connection a utiliser</param>
        /// <param name="dto">Le DTO a mettre a jour</param>
        void update(Connection connection,
            AdresseDTO adresseDTO);

        /// <summary>
        /// Supprime un DTO de la base de donnees
        /// </summary>
        /// <param name="connection">La connection a utiliser</param>
        /// <param name="dto">Le DTO a supprimer</param>
        void delete(Connection connection,
            AdresseDTO adresseDTO);

        /// <summary>
        /// Trouve tous les DTOs de la base de donnees. La liste est classee par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        /// DTO n'est trouve, une liste vide est retournee.
        /// </summary>
        /// <param name="connection">La connection a utiliser</param>
        /// <param name="sortByPropertyName">Le nom de la propriete a utiliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<AdresseDTO> getAll(Connection connection,
         string sortByPropertyName);

        /// <summary>
        /// Trouve les adresses a partir d'une ville. La liste est classee par ordre croissant sur <code>sortByPropertyName</code>.
        /// Si aucune adresse n'est trouve, une liste vide est retournee.
        /// </summary>
        /// <param name="connection">La connection a utiliser</param>
        /// <param name="ville">La ville a trouver</param>
        /// <param name="sortByPropertyName">Le nom de la propriete a utiliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<AdresseDTO> findByVille(Connection connection, string ville, string sortByPropertyName);
    }
}
