using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    public interface ILocationFacade : IFacade
    {
        LocationDTO getLocation(Connection connection,string  idLocation);
        void commencerLocation(Connection connection, LocationDTO locationDTO);
        void renouvelerLocation(Connection connection, LocationDTO locationDTO);
        void terminerLocation(Connection connection, LocationDTO locationDTO);
        List<LocationDTO> findByClient(Connection connection, LocationDTO locationDTO);
        List<LocationDTO> findByOutil(Connection connection, LocationDTO locationDTO);
    }
}
