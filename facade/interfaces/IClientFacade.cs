using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;

namespace CentreLocationOutils.facade.interfaces
{
    // <summary>
    /// Interface de façade pour manipuler les clients dans la base de données.
    /// </summary>
    public interface IClientFacade : IFacade
    {
        /// <summary>
        /// Lit un client à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="clientDTO">Le client à trouver</param>
        ClientDTO getClient(Connection connection, string idClient);

        /// <summary>
        /// Trouve les clients à partir d'un nom. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucun clients n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="nom">Le nom à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun client n'est trouvée, une liste vide est retournée.</returns>
        List<ClientDTO> findByNom(Connection connection, String nom, String SortByPropertyName);

        /// <summary>
        /// Inscrire un client.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="clientDTO">Le client à inscrire</param>
        void inscrire(Connection connection, ClientDTO clientDTO);

        /// <summary>
        /// Desinscrire un client.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="clientDTO">Le client à desinscrire</param>
        void desinscrire(Connection connection, ClientDTO clientDTO);

        /// <summary>
        /// Mettre à jour un client.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="clientDTO">Le client à mettre à jour</param>
        void mettreAJourClient(Connection connection, ClientDTO clientDTO);

        /// <summary>
        /// Trouve tous les clients de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun client n'est trouvé, une liste vide est retournée.</returns>
        List<ClientDTO> getAllClients(Connection connection, string sortByPropertyName);

    }
}
