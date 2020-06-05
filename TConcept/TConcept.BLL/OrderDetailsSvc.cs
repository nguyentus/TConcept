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
    public class OrderDetailsSvc : GenericSvc<OrderDetailsRep, OrderDetails>
    {
        #region Override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(OrderDetails m)
        {
            var res = new SingleRsp();
            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.OrderId);
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
        public SingleRsp CreateOrderDetail(OrderDetailReq orderDetail)
        {
            var res = new SingleRsp();
            var odNew = new OrderDetails()
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                Notes = orderDetail.Notes
            };
            res = _rep.CreateOrderDetail(odNew);
            return res;
        }
        public SingleRsp UpdateOrderDetail(OrderDetailReq orderDetail)
        {
            var res = new SingleRsp();
            var odUpdate = new OrderDetails()
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                Notes = orderDetail.Notes
            };
            res = _rep.UpdateOrderDetail(odUpdate);
            return res;
        }
        public SingleRsp DeleteOrderDetail(int id)
        {
            var res = new SingleRsp();
            var cateDelete = _rep.All.First(p => p.OrderId == id);
            res = _rep.DeleteOrderDetail(cateDelete);
            return res;
        }
        #endregion
    }
}
