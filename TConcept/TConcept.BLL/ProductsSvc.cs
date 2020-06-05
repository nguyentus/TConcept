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
    public class ProductsSvc : GenericSvc<ProductsRep, Products>
    {
        #region Override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Products m)
        {
            var res = new SingleRsp();
            var m1 = m.CategoryId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
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
        public SingleRsp CreateProduct(ProductReq product)
        {
            var res = new SingleRsp();
            var productNew = new Products()
            {
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                Height = product.Height,
                Width = product.Width,
                Length = product.Length,
                Material = product.Material,
                Color = product.Color,
                Price = product.Price,
                Stock = product.Stock,
                Notes = product.Notes
            };
            res = _rep.CreateProduct(productNew);
            return res;
        }
        public SingleRsp UpdateProduct(ProductReq product)
        {
            var res = new SingleRsp();
            var productUpdate = new Products()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                Height = product.Height,
                Width = product.Width,
                Length = product.Length,
                Material = product.Material,
                Color = product.Color,
                Price = product.Price,
                Stock = product.Stock,
                Notes = product.Notes
            };
            res = _rep.UpdateProduct(productUpdate);
            return res;
        }
        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            var productDelete = _rep.All.First(p => p.ProductId == id);
            res = _rep.DeleteProduct(productDelete);
            return res;
        }
        #endregion
    }
}
