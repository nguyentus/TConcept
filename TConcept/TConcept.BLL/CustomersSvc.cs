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
    public class CustomersSvc : GenericSvc<CustomersRep, Customers>
    {
        #region Override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Customers m)
        {
            var res = new SingleRsp();
            var m1 = m.CustomerId > 0 ? _rep.Read(m.CustomerId) : _rep.Read(m.FullName);
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
        public SingleRsp CreateCustomer(CustomerReq customer)
        {
            var res = new SingleRsp();
            var customerNew = new Customers()
            {
                FullName = customer.FullName,
                AccountId = customer.AccountId,
                BirthDate = customer.BirthDate,
                Address = customer.Address,
                HomePhone = customer.HomePhone,
                Notes = customer.Notes
            };
            res = _rep.CreateCustomer(customerNew);
            return res;
        }
        public SingleRsp UpdateCustomer(CustomerReq customer)
        {
            var res = new SingleRsp();
            var customerUpdate = new Customers()
            {
                CustomerId = customer.CustomerId,
                FullName = customer.FullName,
                AccountId = customer.AccountId,
                BirthDate = customer.BirthDate,
                Address = customer.Address,
                HomePhone = customer.HomePhone,
                Notes = customer.Notes
            };
            res = _rep.UpdateCustomer(customerUpdate);
            return res;
        }
        public SingleRsp DeleteCustomer(int id)
        {
            var res = new SingleRsp();
            var customerDelete = _rep.All.First(p => p.CustomerId == id);
            res = _rep.DeleteCustomer(customerDelete);
            return res;
        }
        public object GetCustomerId(string UserName, string UserPassword)
        {
            return _rep.GetCustomerId(UserName, UserPassword);
        }
        #endregion
    }
}
