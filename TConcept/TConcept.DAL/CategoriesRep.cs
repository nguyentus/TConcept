using TConcept.Common.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.DAL
{
    using TConcept.Common.Req;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Linq;
    using TConcept.Common.Rsp;
    using TConcept.Models;

    public class CategoriesRep : GenericRep<TConceptContext, Categories>
    {
        #region --Override--
        public override Categories Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }
        #endregion

        #region Methods

        public SingleRsp CreateCategory(Categories category)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Categories.Add(category);
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
        public SingleRsp UpdateCategory(Categories category)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Categories.Update(category);
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
        public SingleRsp DeleteCategory(Categories category)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Categories.Remove(category);
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
