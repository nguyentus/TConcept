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
        public IActionResult CreateOrder([FromBody]ConfirmOrderReq req)
        {
            var res = _svc.CreateOrder(req);
            return Ok(res);
        }

        [HttpPost("get-order-details-by-id")]
        public IActionResult getOrderDetailById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetOrderDetailById(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all-info-order")]
        public IActionResult GetAllInfoOrder()
        {
            var res = new SingleRsp();
            res.Data = _svc.GetAllInfoOrder();
            return Ok(res);
        }
        private readonly OrdersSvc _svc;
    }
}