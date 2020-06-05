using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TConcept.Common.BLL;
using TConcept.Common.Req;
using TConcept.Common.Rsp;
using TConcept.DAL;
using TConcept.Models;

namespace TConcept.BLL
{
    public class CategoriesSvc : GenericSvc<CategoriesRep, Categories>
    {
        #region Override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Categories m)
        {
            var res = new SingleRsp();
            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.CategoryName);
            if (m1 == null)
                res.SetError("EZ103", "No Data.");
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return res;
        }
        #endregion

        #region Methods
        public SingleRsp CreateCategory(CategoryReq cate)
        {
            var res = new SingleRsp();
            var cateNew = new Categories()
            {
                CategoryName = cate.CategoryName,
                Description = cate.Description
            };
            res = _rep.CreateCategory(cateNew);
            return res;
        }
        public SingleRsp UpdateCategory(CategoryReq cate)
        {
            var res = new SingleRsp();
            var cateUpdate = new Categories()
            {
                CategoryId = cate.CategoryId,
                CategoryName = cate.CategoryName,
                Description = cate.Description
            };
            res = _rep.UpdateCategory(cateUpdate);
            return res;
        }
        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();
            var cateDelete = _rep.All.First(p => p.CategoryId == id);
            res = _rep.DeleteCategory(cateDelete);
            return res;
        }
        #endregion
    }
}
