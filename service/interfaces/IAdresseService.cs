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
    public interface IAdresseService : IService
    {
        /// <summary>
        /// Ajoute une nouvelle adresse dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="adresseDTO">L'adresse à ajouter</param>
        void add(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Lit une adresse à partir de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="adresseDTO">L'adresse à trouver</param>
        AdresseDTO get(Connection connection, string idAdresse);

        /// <summary>
        /// Met à jour une adresse dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="adresseDTO">L'adresse à mettre à jour</param>
        void update(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Supprime une adresse de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="adresseDTO">L'adresse à enlever</param>
        void delete(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Trouve tous les adresses de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune adresse n'est trouvée, une liste vide est retournée.</returns>
        List<AdresseDTO> getall(Connection connection, string sortByPropertyName);

        /// <summary>
        /// Trouve les adresses à partir d'une ville. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. 
        /// Si aucune adresse n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="ville">La ville à trouver</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune adresse n'est trouvée, une liste vide est retournée.</returns>
        List<AdresseDTO> findByVille(Connection connection, string ville, string sortByPropertyName);

        /// <summary>
        /// Ajoute une nouvelle adresse
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="adresseDTO"></param>
        void ajouterAdresse(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Change l'adresse d'un client déjà existant dans le système.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="adresseDTO">L'adresse à changer</param>
        void mettreAJourAddresse(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Supprime une adresse
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="adresseDTO"></param>
        void supprimerAdresse(Connection connection, AdresseDTO adresseDTO);
    }
}
