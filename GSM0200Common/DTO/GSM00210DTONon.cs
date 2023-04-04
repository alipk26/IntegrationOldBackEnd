using System;
using System.Collections.Generic;
using System.Text;

namespace GSM00200Common.DTO
{
    public class GSM00210DTONon
    {
        public string CCOMPANY_ID { get; set; }
        public string CTABLE_ID { get; set; }
        public bool LAUDIT_ENABLE { get; set; }
        public string CCREATE_BY { get; set; }
        public DateTime DCREATE_DATE { get; set; }
        public string CUPDATE_BY { get; set; }
        public DateTime DUPDATE_DATE { get; set; }

        public string CFIELD_ID { get; set; }
        public string CTABLE_NAME { get; set; }
        public string CFIELD_NAME { get; set; }
    }
}
