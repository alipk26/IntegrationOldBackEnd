using System;
using System.Collections.Generic;
using System.Text;
using GSM00200Common.DTO;
using R_CommonFrontBackAPI;

namespace GSM00200Common.Interfaces
{
    public interface IGSM00210 : R_IServiceCRUDBase<GSM00210DTO>
    {
        IAsyncEnumerable<GSM00210DTONon> GetTableDTList();
    }
}
