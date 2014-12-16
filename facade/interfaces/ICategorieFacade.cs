using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.dto;
using CentreLocationOutils.db;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les categories dans la base de données.
    /// </summary>
    public interface ICategorieFacade : IFacade
    {
        /// <summary>
        /// Ajoute une categorie
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="categorieDTO"></param>
        void ajouterCategorie(Connection connection, CategorieDTO categorieDTO);

        /// <summary>
        /// Met à jour une categorie
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="categorieDTO"></param>
        void mettreAJourCategorie(Connection connection, CategorieDTO categorieDTO);

        /// <summary>
        /// Supprime une categorie
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="categorieDTO"></param>
        void supprimerCategorie(Connection connection, CategorieDTO categorieDTO);

        /// <summary>
        /// Lit une categorie à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="idCategorie">L'id de categorie à trouver</param>
        CategorieDTO getCategorie(Connection connection, string idCategorie);

        /// <summary>
        /// Obtient toutes les categories
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<CategorieDTO> getAllCategories(Connection connection, string sortByPropertyName);

        /// <summary>
        /// Trouve les categories à partir d'un nom. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucune categories n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="nom">Le nom à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune categorie n'est trouvée, une liste vide est retournée.</returns>
        List<CategorieDTO> findByNom(Connection connection, string nom, String sortByPropertyName);
    }
}
