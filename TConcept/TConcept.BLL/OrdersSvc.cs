﻿using System;
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
        public SingleRsp CreateOrder(ConfirmOrderReq orderReq)
        {
            return _rep.CreateOrder(orderReq.CustomerId, orderReq.Notes, orderReq.ProductId, orderReq.Quantity);
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
