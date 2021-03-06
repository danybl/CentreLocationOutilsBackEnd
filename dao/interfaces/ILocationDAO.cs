﻿using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;

namespace CentreLocationOutils.dao.interfaces
{
    public interface ILocationDAO : IDAO
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="locationDTO">La location à ajouter</param>
        void add(Connection connection,
          LocationDTO locationDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="primaryKey">La clé primaire du DTO à lire</param>
        /// <returns>Le DTO à retourner</returns>
        LocationDTO get(Connection connection,
          string primaryKey);

        /// <summary>
        /// Met à jour un DTO dans la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="locationDTO">La location à mettre à jour</param>
        void update(Connection connection,
          LocationDTO locationDTO);

        /// <summary>
        /// Supprime un DTO de  la base de données
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="locationDTO">La location à supprimer</param>
        void delete(Connection connection,
          LocationDTO locationDTO);

        /// <summary>
        /// Trouve tous les DTOs de la base de données. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        /// DTO n'est trouvé, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connection à utiliser</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à utiliser pour classer la liste</param>
        /// <returns>La liste de tous les DTOs</returns>
        List<LocationDTO> getAll(Connection connection,
       string sortByPropertyName);


        /// <summary>
        /// Trouve les locations d'un client. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucune location
        /// n'est trouvée, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="idClient">L'ID du client à trouver</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à utiliser pour classer</param>
        /// <returns>La liste des location correspondantes</returns>
        List<LocationDTO> findByClient(Connection connection,
      String idClient,
      String sortByPropertyName);

        /// <summary>
        /// Trouve les locations pour un outil. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucune location
        /// n'est trouvée, une liste vide est retournée.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="idOutil">L'ID de l'outil à trouver</param>
        /// <param name="sortByPropertyName">Le nom de la propriété à utiliser pour classer</param>
        /// <returns>La liste des location correspondantes</returns>
        List<LocationDTO> findByOutil(Connection connection,
      String idOutil,
      String sortByPropertyName);
    }
}
