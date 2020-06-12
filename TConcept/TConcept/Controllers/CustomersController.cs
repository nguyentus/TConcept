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
    public class CustomersController : ControllerBase
    {
        public CustomersController()
        {
            _svc = new CustomersSvc();
        }

        [HttpPost("create-customer")]
        public IActionResult CreateCustomer([FromBody]CustomerReq req)
        {
            var res = _svc.CreateCustomer(req);
            return Ok(res);
        }

        [HttpPost("update-customer")]
        public IActionResult UpdateCustomer([FromBody]CustomerReq req)
        {
            var res = _svc.UpdateCustomer(req);
            return Ok(res);
        }

        //[HttpPost("delete-customer")]
        //public IActionResult DeleteCustomer([FromBody]SimpleReq req)
        //{
        //    var res = _svc.DeleteCustomer(req.Id);
        //    return Ok(res);
        //}

        //[HttpPost("get-all")]
        //public IActionResult getAllCustomers()
        //{
        //    var res = new SingleRsp();
        //    res.Data = _svc.All;
        //    return Ok(res);
        //}

        [HttpPost("get-by-id")]
        public IActionResult getCustomerById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-id-login")]
        public IActionResult GetProductById([FromBody]LoginReq req)
        {
            object res = _svc.GetCustomerId(req.UserName, req.UserPassword);
            return Ok(res);
        }

        private readonly CustomersSvc _svc;
    }
}