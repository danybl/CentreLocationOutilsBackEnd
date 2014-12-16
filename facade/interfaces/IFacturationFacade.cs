using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    // <summary>
    /// Interface de façade pour manipuler les facturations dans la base de données.
    /// </summary>
    public interface IFacturationFacade : IFacade
    {
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
