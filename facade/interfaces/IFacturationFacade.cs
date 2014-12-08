using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    public interface IFacturationFacade : IFacade
    {
        List<FacturationDTO> findByClient(Connection connection, string idClient, string sortByPropertyName);

        List<FacturationDTO> findByEmploye(Connection connection, string idEmploye, string sortByPropertyName);
    }
}
