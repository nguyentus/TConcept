using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TConcept.Common.BLL;
using TConcept.Common.Req;
using TConcept.Common.Rsp;
using TConcept.DAL;
using TConcept.DAL.ViewModels;
using TConcept.Models;

namespace TConcept.BLL
{
    public class OrdersSvc : GenericSvc<OrdersRep, Orders>
    {
        #region Override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Orders m)
        {
            var res = new SingleRsp();
            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.Notes);
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
        public object SearchOrder(SearchReq req)
        {
            //Keywords tìm kiếm là tên khách hàng
            var context = new TConceptContext();
            var orders = context.Orders.ToList();
            var orderdetails = context.OrderDetails.ToList();
            var customers = context.Customers.ToList();
            var products = context.Products.ToList();


            var orderResult = from o in orders join od in orderdetails on o.OrderId equals od.OrderId
                              join c in customers on o.CustomerId equals c.CustomerId
                              join p in products on od.ProductId equals p.ProductId
                              where c.FullName.ToLower().Contains(req.Keyword)
                              //&& String.Format("{0:MM/dd/yyyy}", o.OrderDate).Contains(req.Date)
                              select new OrderInfoViewModel()
                              {
                                  OrderId = o.OrderId,
                                  FullName = c.FullName,
                                  ProductName = p.ProductName,
                                  OrderDate = o.OrderDate,
                                  Address = c.Address,
                                  Notes = o.Notes, 
                                  Price = od.Quantity * p.Price 
                              };

            //Thuật toán phân trang
            var offset = (req.Page - 1) * req.Size;
            var total = orderResult.Count();
            int totalPages = (total % req.Size) == 0 ? (total / req.Size) : (int)(total / req.Size + 1);
            //Lấy dữ liệu
            var data = orderResult.OrderByDescending(x => x.OrderDate).Skip(offset).Take(req.Size).ToList();

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
        public SingleRsp CreateOrder(ConfirmOrderReq orderReq)
        {
            return _rep.CreateOrder(orderReq.CustomerId, orderReq.Notes, orderReq.ProductId, orderReq.Quantity);
        }
        public SingleRsp DeleteOrder(int id)
        {
            var res = _rep.DeleteOrder(id);
            return res;
        }
        public List<object> GetAllInfoOrder()
        {
            return _rep.GetAllInfoOrder();
        } 
        public List<object> GetOrderDetailById(int id)
        {
            return _rep.GetOrderDetailById(id);
        }
        #endregion
    }
}
