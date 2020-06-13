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
        public object SearchProduct(SearchReq req)
        {
            var pro = All.Where(x => x.ProductName.Contains(req.Keyword));

            var offset = (req.Page - 1) * req.Size;
            var total = pro.Count();
            int totalPages = (total % req.Size) == 0 ? (total / req.Size) : (int)(total / req.Size + 1);
            var data = pro.OrderBy(x => x.ProductName).Skip(offset).Take(req.Size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = req.Page,
                Size = req.Size
            };
            return res;
        }

        public object GetProductById(int id)
        {
            return _rep.GetProductById(id);
        }

        public List<object> GetAllProductsByStored()
        {
            return _rep.GetAllProductsByStored();
        }
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
                Image = product.Image,
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
                Image = product.Image,
                Notes = product.Notes
            };
            res = _rep.UpdateProduct(productUpdate);
            return res;
        }
        public SingleRsp DeleteProductById(int id)
        {
            var res = _rep.DeleteProductById(id);
            return res;
        }
        #endregion
    }
}
