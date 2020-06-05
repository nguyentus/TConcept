using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TConcept.BLL;
using TConcept.Common.Req;
using TConcept.Common.Rsp;

namespace TConcept.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public OrderDetailsController()
        {
            _svc = new OrderDetailsSvc();
        }

        [HttpPost("create-orderdetail")]
        public IActionResult CreateOrderDetail([FromBody]OrderDetailReq req)
        {
            var res = _svc.CreateOrderDetail(req);
            return Ok(res);
        }

        [HttpPost("update-orderdetail")]
        public IActionResult UpdateOrderDetail([FromBody]OrderDetailReq req)
        {
            var res = _svc.UpdateOrderDetail(req);
            return Ok(res);
        }

        [HttpPost("delete-orderdetail")]
        public IActionResult DeleteOrderDetail([FromBody]SimpleReq req)
        {
            var res = _svc.DeleteOrderDetail(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllOrderDetails()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("get-by-id")]
        public IActionResult getOrderDetailById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        private readonly OrderDetailsSvc _svc;
    }
}