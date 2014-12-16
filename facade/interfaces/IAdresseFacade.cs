using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les adresses dans la base de données.
    /// </summary>
    public interface IAdresseFacade : IFacade
    {
        /// <summary>
        /// Ajoute une nouvelle adresse
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="adresseDTO"></param>
        void ajouterAdresse(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Changer une adresse
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="adresseDTO">L'adresse à changer</param>
        void mettreAJourAdresse(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Supprime une adresse
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="adresseDTO"></param>
        void supprimerAdresse(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Obtient une adresse 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="adresseDTO"></param>
        /// <returns></returns>
        AdresseDTO getAdresse(Connection connection, AdresseDTO adresseDTO);

        /// <summary>
        /// Obtient toutes les adresses
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<AdresseDTO> getAllAdresses(Connection connection, string sortByPropertyName);
    }
}
