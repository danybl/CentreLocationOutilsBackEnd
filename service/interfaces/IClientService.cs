using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.service.interfaces;
using CentreLocationOutils.dto;
using CentreLocationOutils.db;
using CentreLocationOutils.exception.service;

namespace CentreLocationOutils.service.interfaces
{
    /// <summary>
    /// Interface de base pour les services.<br/>
    /// Toutes les interfaces de service devrait en hériter.
    /// </summary>
    public interface IClientService : IService
    {
        /// <summary>
        /// Ajoute une nouveau client dans la base de données.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="clientDTO">clientDTO Le client à ajouter</param>
        void addClient(Connection connection, ClientDTO clientDTO);
        /// <summary>
        /// Lit un client à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="clientDTO">Le client à trouver</param>
        ClientDTO getClient(Connection connection, String idClient);
        /// <summary>
        /// Met à jour un client dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="clientDTO">Le client à mettre à jour</param>
        void updateClient(Connection connection, ClientDTO clientDTO);
        /// <summary>
        /// Supprime un client de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="clientDTO">Le client à enlever</param>
        void deleteClient(Connection connection, ClientDTO clientDTO);
        /// <summary>
        /// Trouve tous les clients de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucun client n'est trouvé, une liste vide est retournée.</returns>
        List<ClientDTO> getAllClients(Connection connection,
        String sortByPropertyName);
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
        /// <param name="connection"></param>
        /// <param name="clientDTO"></param>
        void inscrireClient(Connection connection, ClientDTO clientDTO);
        /// <summary>
        /// Desinscrire un client.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="clientDTO"></param>
        void desinscrireClient(Connection connection, ClientDTO clientDTO);
        /// <summary>
        /// Mettre à jour un client.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="clientDTO"></param>
        void mettreAJourClient(Connection connection, ClientDTO clientDTO);
    }
}

