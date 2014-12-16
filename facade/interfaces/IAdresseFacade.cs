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
        /// Changer une adresse
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="adresseDTO">L'adresse à changer</param>
        void changerAdresse(Connection connection, AdresseDTO adresseDTO);
    }
}
