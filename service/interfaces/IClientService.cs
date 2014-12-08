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
    /// 
    /// </summary>
    public interface IClientService : IService
    {
        /**
        * Ajoute une nouveau client.
        *
        * @param connection La connection à utiliser
        * @param clientDTO Le client à ajouter
        */
        void addClient(Connection connection, ClientDTO clientDTO);
        /**
        * Lit une client.
        *
        * @param connection La connection à utiliser
        * @param clientDTO La client à lire
        */
        ClientDTO getClient(Connection connection, String idClient);
        /**
        * Met à jour un client.
        *
        * @param connection La connection à utiliser
        * @param clientDTO Le client à mettre à jour
        */
        void updateClient(Connection connection, ClientDTO clientDTO);
        /**
        * Efface une client.
        *
        * @param connection La connection à utiliser
        * @param clientDTO La client à effacer
        */
        void deleteClient(Connection connection, ClientDTO clientDTO);
        /**
        * Trouve tous les clients. La liste est classée par ordre croissant sur <code>sortByPropertyName</code>. Si aucun
        * client n'est trouvé, une {@link List} vide est retournée.
        *
        * @param connection La connection à utiliser
        * @param clientDTO Le client à lire
        */
        List<ClientDTO> getAllClients(Connection connection,
        String sortByPropertyName);
        /*Trouve un client à partir d'un nom
        *
        *@param connection La connection à utiliser
        *@param nom Le nom à trouver
        *@param sortByPropertyName Le nom de la propriété à utiliser pour classer
        */
        List<ClientDTO> findByNom(Connection connection, String nom, String SortByPropertyName);

        /*Inscrit un client
        *
        *@param connection La connection à utiliser
        *@param clientDTO Le client à inscrire
        */
        void inscrireClient(Connection connection, ClientDTO clientDTO);
        /*Desinscrit un client
        *
        *@param connection La connection à utiliser
        *@param clientDTO Le client à desinscrire
        */
        void desinscrireClient(Connection connection, ClientDTO clientDTO);
    }
}

