using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TConcept.Common.DAL;
using TConcept.Common.Rsp;
using TConcept.Models;

namespace TConcept.DAL
{
    public class CustomersRep : GenericRep<TConceptContext, Customers>
    {
        #region --Override--
        public override Customers Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CustomerId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.CustomerId == id);
            m = base.Delete(m);
            return m.CustomerId;
        }
        #endregion

        #region Methods

        public SingleRsp CreateCustomer(Customers customer)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Customers.Add(customer);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateCustomer(Customers customer)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Customers.Update(customer);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteCustomer(Customers customer)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Customers.Remove(customer);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        #endregion
    }
}
