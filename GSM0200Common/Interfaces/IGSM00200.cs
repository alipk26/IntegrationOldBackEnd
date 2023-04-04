using GSM00200Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using R_CommonFrontBackAPI;

namespace GSM00200Common.Interfaces
{
    public interface IGSM00200 : R_IServiceCRUDBase<GSM00200DTO>
    {
        IAsyncEnumerable<GSM00200DTONon> GetTableHDList();
    }
}
