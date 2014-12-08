using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.dto;
using CentreLocationOutils.db;

namespace CentreLocationOutils.facade.interfaces
{
    public interface ICategorieFacade : IFacade
    {
        List<CategorieDTO> findByNom(Connection connection, String nom, String sortByPropertyName);
    }
}
