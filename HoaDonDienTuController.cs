using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMT.EMS.API.HoaDonDienTu.Models;
using PMT.EMS.API.HoaDonDienTu.BLL;

namespace PMT.EMS.API.HoaDonDienTu.Controllers
{
    public class HoaDonDienTuController : ApiController
    {

        [HttpPut]
        public JToken Update(string id, string invoicestatus, string signstatus)
        {
            var _bus = new HoaDonDienTuBLL();
            var res = new Result();
            try
            {
                var Result = _bus.UpdateHoaDonDienTu(id, invoicestatus, signstatus);
                if (Result == 1)
                {
                    res.succeeded = true;
                    res.message = "Thành công";
                }
                else
                {
                    res.succeeded = false;
                    res.message = "Không tìm thấy mẫu tin";
                }
            }
            catch (Exception ex)
            {
                res.succeeded = false;
                res.message = ex.Message.ToString();
            }
            string json = JsonConvert.SerializeObject(res);
            return json;
    }
    public class Result
    {
        public bool succeeded { get; set; }
        public string message { get; set; }

    }
}
}
