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
    public class ClientService : Service, IClientService
    {
        private IClientDAO clientDAO;
        
        public ClientService(IClientDAO clientDAO) : base()
        {
          if(clientDAO == null) {
              throw new InvalidDAOException("Le DAO de client ne peut être null");
        }
        setClientDAO(clientDAO);
        }

        //set et get
        private IClientDAO getClientDAO()
        {
            return this.clientDAO;
        }

        private void setClientDAO(IClientDAO clientDAO)
        {
            this.clientDAO = clientDAO;
        }

        //Ajout d'un client
        public void addClient(Connection connection,
        ClientDTO clientDTO)
        {
        try {
             getClientDAO().add(connection,clientDTO);
        }
        catch (DAOException daoException)
        {
            throw new ServiceException(daoException.Message);
        }
        }

        //Lecture des clients
        public ClientDTO getClient(Connection connection, String primaryKey)
        {
        try {
            return getClientDAO().get(connection,primaryKey); 
        }
        catch (DAOException daoException)
        {
            throw new ServiceException(daoException.Message);
        }
        }

        //Mise à jour d'un client
        public void updateClient(Connection connection,
        ClientDTO clientDTO)
        {
            try
            {
                getClientDAO().update(connection, clientDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        //Suppression d'un client
        public void deleteClient(Connection connection,
        ClientDTO clientDTO)
        {
            try
            {
                getClientDAO().delete(connection, clientDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

      //Lecture de toutes les clients
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

        //Trouver un client par son nom
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

        // Inscrire un client
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

        //Desinscrire un client
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

    }
}
