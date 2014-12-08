using System;

namespace CentreLocationOutils.dto
{
    public class DTO
    {
        protected DTO() : base(){}


        public bool equals(Object obj) {
        bool equals = this == obj;
        if(!equals) {
            equals = obj != null
                && obj is DTO;
        }
        return equals;
    }




    }
}
