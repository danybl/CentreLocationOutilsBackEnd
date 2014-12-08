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
    /// 
    /// </summary>
    public interface ICategorieService : IService
    {
        /**
        * Ajoute une nouvelle catégorie.
        *
        * @param connection La connection à utiliser
        * @param categorieDTO La catégorie à ajouter
        */
        void add(Connection connection,
        CategorieDTO categorieDTO);

        /**
        * Lit une catégorie.
        *
        * @param connection La connection à utiliser
        * @param categorieDTO La catégorie à lire
        */
        CategorieDTO get(Connection connection,
        String idCategorie);

        /**
        * Met à jour une catégorie.
        *
        * @param connection La connection à utiliser
        * @param categorieDTO La catégorie à mettre à jour
        */
        void update(Connection connection,
        CategorieDTO categorieDTO);

        /**
        * Efface une catégorie.
        *
        * @param connection La connection à utiliser
        * @param categorieDTO La catégorie à effacer
        */
        void delete(Connection connection,
        CategorieDTO categorieDTO);

        /**
        * Trouve tous les livres. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        * livre n'est trouvé, une {@link List} vide est retournée.
        *
        * @param connection La connection à utiliser
        * @param categorieDTO La catégorie à lire
        */
        List<CategorieDTO> getAll(Connection connection,
        String sortByPropertyName);

        /*Trouve une catégorie à partir d'un nom
         *
         *@param connection La connection à utiliser
         *@param nom Le nom à trouver
         *@param sortByPropertyName Le nom de la propriété à utiliser pour classer
         */
        List<CategorieDTO> findByNom(Connection connection,
        String nom,
        String sortByPropertyName);

    }
}
