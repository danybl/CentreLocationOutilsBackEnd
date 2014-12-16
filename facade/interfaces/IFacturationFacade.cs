using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les facturations dans la base de données.
    /// </summary>
    public interface IFacturationFacade : IFacade
    {
        /// <summary>
        /// Ajoute une facturation
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="facturationDTO"></param>
        void ajouterFacturation(Connection connection, FacturationDTO facturationDTO);

        /// <summary>
        /// Met à jour une facturation
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="facturationDTO"></param>
        void mettreAJourFacturation(Connection connection, FacturationDTO facturationDTO);

        /// <summary>
        /// Supprime une facturation
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="facturationDTO"></param>
        void supprimerFacturation(Connection connection, FacturationDTO facturationDTO);

        /// <summary>
        /// Obtient une facturation
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="idFacturation"></param>
        /// <returns></returns>
        FacturationDTO getFacturation(Connection connection, string idFacturation);

        /// <summary>
        /// Obtient toutes les facturations
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<FacturationDTO> getAllFacturations(Connection connection, string sortByPropertyName);
        /// <summary>
        /// Trouve les factures à partir d'un client. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucune adresse n'est trouvé, une liste vide est retournée. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="idClient">L'ID du client à trouver</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à uriliser pour classer la liste</param>
        /// <returns>Si aucune facturation n'est trouvée, une liste vide est retournée.</returns>
        List<FacturationDTO> findByClient(Connection connection, string idClient, string sortByPropertyName);

        /// <summary>
        /// Trouve les factures à partir d'un employe. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucune adresse n'est trouvé, une liste vide est retournée.  
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="idEmploye">L'ID du employe à trouver</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à utiliser pour classer la liste</param>
        /// <returns>Si aucune facturation n'est trouvée, une liste vide est retournée.</returns>
        List<FacturationDTO> findByEmploye(Connection connection, string idEmploye, string sortByPropertyName);
    }
}
