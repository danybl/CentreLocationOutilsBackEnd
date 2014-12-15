﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;

namespace CentreLocationOutils.facade.interfaces
{
    public interface IClientFacade : IFacade
    {
        ClientDTO getClient(Connection connection, string idClient);

        List<ClientDTO> findByNom(Connection connection, String nom, String SortByPropertyName);

        void inscrire(Connection connection, ClientDTO clientDTO);

        void desinscrire(Connection connection, ClientDTO clientDTO);

        void mettreAJourClient(Connection connection, ClientDTO clientDTO);
    }
}
