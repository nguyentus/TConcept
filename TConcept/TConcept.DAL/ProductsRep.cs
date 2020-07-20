using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TConcept.Common.DAL;
using TConcept.Common.Req;
using TConcept.Common.Rsp;
using TConcept.Models;

namespace TConcept.DAL
{
    public class ProductsRep : GenericRep<TConceptContext, Products>
    {
        #region --Override--
        public override Products Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        #endregion

        #region Methods
        public object GetProductById(int id)
        {
            object res = new object();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "GetProductById"; // lay ten store mun thuc hien
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", id);
                da.SelectCommand = cmd; // goi thuc thi store
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            ProductId = row.IsNull("ProductId") ? null : row["ProductId"],
                            ProductName = row.IsNull("ProductName") ? null : row["ProductName"],
                            CategoryId = row.IsNull("CategoryId") ? null : row["CategoryId"],
                            CategoryName = row.IsNull("CategoryName") ? null : row["CategoryName"],
                            Height = row.IsNull("Height") ? null : row["Height"],
                            Width = row.IsNull("Width") ? null : row["Width"],
                            Length = row.IsNull("Length") ? null : row["Length"],
                            Material = row.IsNull("Material") ? null : row["Material"],
                            Color = row.IsNull("Color") ? null : row["Color"],
                            Price = row.IsNull("Price") ? null : row["Price"],
                            Stock = row.IsNull("Stock") ? null : row["Stock"],
                            Image = row.IsNull("Image") ? null : row["Image"],
                            Notes = row.IsNull("Notes") ? null : row["Notes"]
                        };
                        res = x;
                    }
                }
            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;
        }

        public List<object> GetAllProductsByStored()
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "GetAllProductsByStored"; // lay ten store mun thuc hien
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd; // goi thuc thi store
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            ProductId = row.IsNull("ProductId") ? null : row["ProductId"],
                            ProductName = row.IsNull("ProductName") ? null : row["ProductName"],
                            CategoryId = row.IsNull("CategoryId") ? null : row["CategoryId"],
                            CategoryName = row.IsNull("CategoryName") ? null : row["CategoryName"],
                            Height = row.IsNull("Height") ? null : row["Height"],
                            Width = row.IsNull("Width") ? null : row["Width"],
                            Length = row.IsNull("Length") ? null : row["Length"],
                            Material = row.IsNull("Material") ? null : row["Material"],
                            Color = row.IsNull("Color") ? null : row["Color"],
                            Price = row.IsNull("Price") ? null : row["Price"],
                            Stock = row.IsNull("Stock") ? null : row["Stock"],
                            Image = row.IsNull("Image") ? null : row["Image"],
                            Notes = row.IsNull("Notes") ? null : row["Notes"]
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;
        }
        public List<object> GetProductImageDetail(int id)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "GetProductImageDetail"; // Lấy tên Store Procedure muốn thực thi
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", id);
                da.SelectCommand = cmd; // Gọi thực thi Store Procedure 
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            Image = row.IsNull("Image") ? null : row["Image"]
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;
        }
        public SingleRsp CreateProduct(Products product)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Products.Add(product);
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
        public SingleRsp UpdateProduct(Products product)
        {
            var res = new SingleRsp();
            using (var context = new TConceptContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Products.Update(product);
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
        public SingleRsp DeleteProductById(int id)
        {
            var res = new SingleRsp();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "DeleteProductById"; // lay ten store mun thuc hien
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", id);
                da.SelectCommand = cmd; // goi thuc thi store
                da.Fill(ds);
                res.Data = ds.Tables;
            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;
        }
        #endregion
    }
}
