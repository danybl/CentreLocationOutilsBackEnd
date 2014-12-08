using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.dto
{
    public class CategorieDTO :DTO
    {

        public static   string ID_CATEGORIE_COLUMN_NAME = "idCategorie";

        public static   string NOM_COLUMN_NAME = "nom";

        public string IdCategorie { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

    }
}
