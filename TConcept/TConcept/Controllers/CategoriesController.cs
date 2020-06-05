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
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            _svc = new CategoriesSvc();
        }

        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody]CategoryReq req)
        {
            var res = _svc.CreateCategory(req);
            return Ok(res);
        }

        [HttpPost("update-category")]
        public IActionResult UpdateCategory([FromBody]CategoryReq req)
        {
            var res = _svc.UpdateCategory(req);
            return Ok(res);
        }

        [HttpPost("delete-category")]
        public IActionResult DeleteCategory([FromBody]SimpleReq req)
        {
            var res = _svc.DeleteCategory(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        private readonly CategoriesSvc _svc;
    }
}