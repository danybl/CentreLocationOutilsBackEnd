using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.dto
{
    public class LocationDTO
    {

        public static   string ID_LOCATION_COLUMN_NAME = "idLocation";

        public static   string ID_CLIENT_COLUMN_NAME = "idClient";

        public static   string ID_EMPLOYE_COLUMN_NAME = "idEmploye";

        public static   string ID_OUTIL_COLUMN_NAME = "idOutil";

        public static   string DATELIMITE_COLUMN_NAME = "dateLimite";

        public string IdLocation { get; set; }
        public ClientDTO ClientDTO { get; set; }
        public EmployeDTO EmployeDTO { get; set; }
        public OutilDTO OutilDTO { get; set; }
        public string Depot { get; set; }
        public string DateLocation { get; set; }
        public string DateLimite { get; set; }
        public string DateRetour { get; set; }
    }
}
