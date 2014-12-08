using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.dto
{
    public class FacturationDTO
    {

        public static   string ID_FACTURATION_COLUMN_NAME = "idFacturation";

        public string IdFacturation { get; set; }
        public EmployeDTO EmployerDTO { get; set; }
        public LocationDTO LocationDTO { get; set; }
        public string CoutTotal { get; set; }
    }
}
