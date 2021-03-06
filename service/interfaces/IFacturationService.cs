﻿using System;
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
    public interface IFacturationService : IService
    {
        /// <summary>
        /// Ajoute une nouvelle facture dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="facturationDTO">La facturation à ajouter</param>
        void add(Connection connection, FacturationDTO facturationDTO);

        /// <summary>
        /// Lit une facture à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="idFacturation">L'ID de la facturation à trouver</param>
        /// <returns>La facturation</returns>
        FacturationDTO get(Connection connection, string idFacturation);

        /// <summary>
        /// Met à jour une facture dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="facturationDTO">La facturation à mettre à jour</param>
        void update(Connection connection, FacturationDTO facturationDTO);

        /// <summary>
        /// Supprime une facture de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="facturationDTO">La facturation à enlever</param>
        void delete(Connection connection, FacturationDTO facturationDTO);

        /// <summary>
        /// Trouve tous les factures de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à uriliser pour classer la liste</param>
        /// <returns>La liste de tous les factures à une liste vide sinon</returns>
        List<FacturationDTO> getall(Connection connection, string sortByPropertyName);

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

    }
}
