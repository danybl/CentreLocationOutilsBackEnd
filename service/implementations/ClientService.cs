using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.service.interfaces;
using System;
using System.Collections.Generic;

namespace CentreLocationOutils.service.implementations
{
    /// <summary>
    /// Service de la table <code>client</code>.
    /// </summary>
    public class ClientService : Service, IClientService
    {
        private IClientDAO clientDAO;

        /// <summary>
        /// Crée le service de la client <code>client</code>.
        /// </summary>
        /// <param name="clientDAO">Le DAO de la table <code>client</code></param>
        public ClientService(IClientDAO clientDAO) : base()
        {
          if(clientDAO == null) {
              throw new InvalidDAOException("Le DAO de client ne peut être null");
        }
        setClientDAO(clientDAO);
        }

        #region Getters & Setters

        /// <summary>
        /// Getter de la variable d'instance <code>this.clientDAO</code>.
        /// </summary>
        /// <returns>La variable d'instance <code>this.clientDAO</code></returns>
        private IClientDAO getClientDAO()
        {
            return this.clientDAO;
        }

        /// <summary>
        /// Setter de la variable d'instance <code>this.clientDAO</code>.
        /// </summary>
        /// <param name="clientDAO">La valeur à utiliser pour la variable d'instance <code>this.clientDAO</code></param>
        private void setClientDAO(IClientDAO clientDAO)
        {
            this.clientDAO = clientDAO;
        }

        #endregion

        #region CRUD
        /// <inheritdoc />
        public void addClient(Connection connection,
        ClientDTO clientDTO)
        {
        try {
             getClientDAO().add(connection,clientDTO);
        }
        catch (DAOException daoException)
        {
            throw new ServiceException("Erreur : " + daoException);
        }
        }

        /// <inheritdoc />
        public ClientDTO getClient(Connection connection, String primaryKey)
        {
        try {
            return getClientDAO().get(connection,primaryKey); 
        }
        catch (DAOException daoException)
        {
            throw new ServiceException("Erreur : " + daoException);
        }
        }

        /// <inheritdoc />
        public void updateClient(Connection connection,
        ClientDTO clientDTO)
        {
            try
            {
                getClientDAO().update(connection, clientDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public void deleteClient(Connection connection,
        ClientDTO clientDTO)
        {
            try
            {
                getClientDAO().delete(connection, clientDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException("Erreur : " + daoException);
            }
        }

        /// <inheritdoc />
        public List<ClientDTO> getAllClients(Connection connection, String sortByPropertyName)
        {
            try
            {
                return getClientDAO().getAll(connection,sortByPropertyName); 
         }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<ClientDTO> findByNom(Connection connection, String nom, String sortByPropertyName)
        {
         if (connection == null)
          {
           throw new InvalidConnectionException("La connection ne peut être null");
         }
         try 
         {
         return getClientDAO().findByNom(connection,
                nom,
                sortByPropertyName);
         } 
         catch (DAOException daoException)
         {
           throw new ServiceException(daoException.Message);
         }
       }

        /// <inheritdoc />
        public void inscrireClient(Connection connection, ClientDTO clientDTO)
        {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (clientDTO == null)
            {
                throw new InvalidDTOException("Le client ne peut être null");
            }
            addClient(connection, clientDTO);
        }

        /// <inheritdoc />
         public void desinscrireClient(Connection connection, ClientDTO clientDTO)
         {
            if (connection == null)
            {
                throw new InvalidConnectionException("La connection ne peut être null");
            }
            if (clientDTO == null)
            {
                throw new InvalidDTOException("Le client ne peut être null");
            }
            deleteClient(connection, clientDTO);
        }


         /// <inheritdoc />
         public void mettreAJourClient(Connection connection, ClientDTO clientDTO)
         {
             if (connection == null)
             {
                 throw new InvalidConnectionException("La connection ne peut être null");
             }
             if (clientDTO == null)
             {
                 throw new InvalidDTOException("Le client ne peut être null");
             }
             updateClient(connection, clientDTO);
         }
        #endregion
    }
}
