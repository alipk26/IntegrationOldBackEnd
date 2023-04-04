using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSM00200Back;
using GSM00200Common;
using GSM00200Common.DTO;
using GSM00200Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;

namespace GSM00200Service
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GSM00200Controller : ControllerBase, IGSM00200
    {
        [HttpPost]
        public R_ServiceGetRecordResultDTO<GSM00200DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<GSM00200DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceGetRecordResultDTO<GSM00200DTO> loRtn = null;
            GSM00200Cls loCls;

            try
            {
                loCls = new GSM00200Cls();
                loRtn = new R_ServiceGetRecordResultDTO<GSM00200DTO>();
                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            };
            EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<GSM00200DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM00200DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceSaveResultDTO<GSM00200DTO> loRtn = null;
            GSM00200Cls loCls;
            try
            {
                loCls = new GSM00200Cls();
                loRtn = new R_ServiceSaveResultDTO<GSM00200DTO>();
                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM00200DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceDeleteResultDTO loRtn = null;
            GSM00200Cls loCls;
            try
            {
                loCls = new GSM00200Cls();
                loCls.R_Delete(poParameter.Entity);

            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public IAsyncEnumerable<GSM00200DTONon> GetTableHDList()
        {
            R_Exception loException = new();
            IAsyncEnumerable<GSM00200DTONon> loRtn = null;
            GSM00200Cls loCls;
            string loCompId;
            List<GSM00200DTONon> loRtnTmp;
            try
            {
                loCompId = R_Utility.R_GetStreamingContext<string>(GSM00200Constant.CCOMPANY_ID);
                loCls = new();
                loRtnTmp = loCls.GetTableHDList(loCompId);
                loRtn = this.GetGSM200Stream(loRtnTmp);
            }
            catch (Exception e)
            {
                loException.Add(e);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        

        #region  "Helper"
        private async IAsyncEnumerable<GSM00200DTONon> GetGSM200Stream(List<GSM00200DTONon> poParameter)
        {
            foreach (GSM00200DTONon item in poParameter)
            {
                yield return item;
            }
        }
        #endregion
    }
}
