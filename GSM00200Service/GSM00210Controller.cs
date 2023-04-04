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
    public class GSM00210Controller :ControllerBase, IGSM00210
    {
        [HttpPost]
        public R_ServiceGetRecordResultDTO<GSM00210DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<GSM00210DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceGetRecordResultDTO<GSM00210DTO> loRtn = null;
            GSM00210Cls loCls;
            try
            {
                loCls = new GSM00210Cls();
                loRtn = new R_ServiceGetRecordResultDTO<GSM00210DTO>();
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
        public R_ServiceSaveResultDTO<GSM00210DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM00210DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceSaveResultDTO<GSM00210DTO> loRtn = null;
            GSM00210Cls loCls;
            try
            {
                loCls = new GSM00210Cls();
                loRtn = new R_ServiceSaveResultDTO<GSM00210DTO>();
                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM00210DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceDeleteResultDTO loRtn = null;
            GSM00210Cls loCls;
            try
            {
                loCls = new GSM00210Cls();
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
        public IAsyncEnumerable<GSM00210DTONon> GetTableDTList()
        {
            R_Exception loException = new();
            IAsyncEnumerable<GSM00210DTONon> loRtn = null;
            GSM00210Cls loCls;
            string loCompId;
            string lcTableId;
            List<GSM00210DTONon> loRtnTmp;
            try
            {
                loCompId = R_Utility.R_GetStreamingContext<string>(GSM00210Constant.CCOMPANY_ID);
                lcTableId = R_Utility.R_GetStreamingContext<string>(GSM00210Constant.CTABLE_ID);
                loCls = new();
                loRtnTmp = loCls.GetTableDTList(loCompId,lcTableId);
                loRtn = this.GetGSM210Stream(loRtnTmp);
            }
            catch (Exception e)
            {
                loException.Add(e);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        #region  "Helper"
        private async IAsyncEnumerable<GSM00210DTONon> GetGSM210Stream(List<GSM00210DTONon> poParameter)
        {
            foreach (GSM00210DTONon item in poParameter)
            {
                yield return item;
            }
        }
        #endregion
    }
}
