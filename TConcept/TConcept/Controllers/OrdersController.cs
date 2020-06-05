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
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
            _svc = new OrdersSvc();
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody]OrderReq req)
        {
            var res = _svc.CreateOrder(req);
            return Ok(res);
        }

        [HttpPost("update-order")]
        public IActionResult UpdateOrder([FromBody]OrderReq req)
        {
            var res = _svc.UpdateOrder(req);
            return Ok(res);
        }

        [HttpPost("delete-order")]
        public IActionResult DeleteOrder([FromBody]SimpleReq req)
        {
            var res = _svc.DeleteOrder(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllOrders()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("get-by-id")]
        public IActionResult getOrderById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        private readonly OrdersSvc _svc;
    }
}