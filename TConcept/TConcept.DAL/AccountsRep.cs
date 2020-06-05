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

    public class AccountsRep : GenericRep<TConceptContext, Accounts>
    {
        #region --Override--
        public override Accounts Read(int id)
        {
            var res = All.FirstOrDefault(p => p.AccountId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.AccountId == id);
            m = base.Delete(m);
            return m.AccountId;
        }
        #endregion

        #region Methods

        public SingleRsp CreateAccount(Accounts acc)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Accounts.Add(acc);
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
        public SingleRsp UpdateAccount(Accounts acc)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Accounts.Update(acc);
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
        public SingleRsp DeleteAccount(Accounts acc)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Accounts.Remove(acc);
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

        public Accounts Login(string UserName, string Password)
        {
            var res = All.FirstOrDefault(p => p.UserName == UserName && p.UserPassword == Password);
            return res;
        }

        //public InfoAccountReq GetInfoAccountByID(int id)
        //{
        //    InfoAccountReq res = new InfoAccountReq();

        //    var cnn = (SqlConnection)Context.Database.GetDbConnection();
        //    if (cnn.State == ConnectionState.Closed)
        //    {
        //        cnn.Open();
        //    }
        //    try
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        DataSet ds = new DataSet();
        //        var cmd = cnn.CreateCommand();
        //        cmd.CommandText = "GetAccountByID";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@AccountID", id);
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            foreach (DataRow row in ds.Tables[0].Rows)
        //            {
        //                InfoAccountReq p = new InfoAccountReq()
        //                {
        //                    AccountId = (int)row["AccountId"],
        //                    Email = row["Email"].ToString(),
        //                    Password = row["Password"].ToString(),
        //                    DisplayName = row["DisplayName"].ToString(),
        //                    AvatarURL = row["AvatarURL"].ToString(),
        //                    Gender = row["Gender"].ToString(),
        //                    YearOfBirth = (int)row["YearOfBirth"]
        //                };
        //                res = p;
        //            }
        //        }
        //        List<PostReq> lst = GetPostsByID(res.AccountId);
        //        res.lstPost = lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        res = null;
        //    }

        //    return res;
        //}

        //public List<PostReq> GetPostsByID(int id)
        //{
        //    List<PostReq> res = new List<PostReq>();
        //    var cnn = (SqlConnection)Context.Database.GetDbConnection();
        //    if (cnn.State == ConnectionState.Closed)
        //    {
        //        cnn.Open();
        //    }
        //    try
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        DataSet ds = new DataSet();
        //        var cmd = cnn.CreateCommand();
        //        cmd.CommandText = "GetPostsByAccountID";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@AccountID", id);
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            foreach (DataRow row in ds.Tables[0].Rows)
        //            {
        //                PostReq p = new PostReq()
        //                {
        //                    PostId = (int)row["PostId"],
        //                    AccountId = (int)row["AccountId"],
        //                    PostName = row["PostName"].ToString(),
        //                    Content = row["Content"].ToString(),
        //                    Address = row["Address"].ToString(),
        //                    PictureURL = row["PictureURL"].ToString()
        //                };
        //                res.Add(p);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res = null;
        //    }
        //    return res;
        //}
        #endregion
    }
}
