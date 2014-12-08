using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.facade.interfaces
{
    public interface IAdresseFacade : IFacade
    {
        void changerAdresse(Connection connection, AdresseDTO adresseDTO);
    }
}
