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
    public interface ICategorieService : IService
    {
        /// <summary>
        /// Ajoute une nouvelle categorie dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="categorieDTO">La categorie à ajouter</param>
        void add(Connection connection,
        CategorieDTO categorieDTO);

        /// <summary>
        /// Lit une categorie à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="categorieDTO">La categorie à trouver</param>
        CategorieDTO get(Connection connection,
        String idCategorie);

        /// <summary>
        /// Met à jour une categorie dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="categorieDTO">La categorie à mettre à jour</param>
        void update(Connection connection,
        CategorieDTO categorieDTO);

        /// <summary>
        /// Supprime une categorie de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="categorieDTO">La categorie à enlever</param>
        void delete(Connection connection,
        CategorieDTO categorieDTO);

        /// <summary>
        /// Trouve tous les categories de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune categorie n'est trouvée, une liste vide est retournée.</returns>
        List<CategorieDTO> getAll(Connection connection,
        String sortByPropertyName);

        /// <summary>
        /// Trouve les categories à partir d'un nom. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucune categories n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="nom">Le nom à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune categorie n'est trouvée, une liste vide est retournée.</returns>
        List<CategorieDTO> findByNom(Connection connection,
        String nom,
        String sortByPropertyName);

    }
}
