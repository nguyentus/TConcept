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
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            _svc = new ProductsSvc();
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody]ProductReq req)
        {
            var res = _svc.CreateProduct(req);
            return Ok(res);
        }

        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody]ProductReq req)
        {
            var res = _svc.UpdateProduct(req);
            return Ok(res);
        }

        [HttpPost("delete-product-by-id")]
        public IActionResult DeleteProductById([FromBody]SimpleReq req)
        {
            var res = _svc.DeleteProductById(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all-products-by-stored")]
        public IActionResult GetAllProductsByStored()
        {
            List<object> res = _svc.GetAllProductsByStored();
            return Ok(res);
        }

        [HttpPost("get-product-by-id")]
        public IActionResult GetProductById([FromBody]SimpleReq req)
        {
            object res = _svc.GetProductById(req.Id);
            return Ok(res);
        }

        [HttpPost("search-products")]
        public IActionResult SearchProducts([FromBody]SearchReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchProduct(req);
            res.Data = pros;
            return Ok(res);
        }

        private readonly ProductsSvc _svc;
    }
}