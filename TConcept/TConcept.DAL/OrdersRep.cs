﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TConcept.Common.DAL;
using TConcept.Common.Rsp;
using TConcept.Models;

namespace TConcept.DAL
{
    public class OrdersRep : GenericRep<TConceptContext, Orders>
    {
        #region --Override--
        public override Orders Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = All.First(i => i.OrderId == id);
            m = base.Delete(m);
            return m.OrderId;
        }
        #endregion

        #region Methods 
        public List<object> GetAllInfoOrder()
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
                cmd.CommandText = "GetAllInfoOrder"; // lay ten store mun thuc hien
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd; // goi thuc thi store
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row.IsNull("OrderID") ? null : row["OrderID"],
                            FullName = row.IsNull("FullName") ? null : row["FullName"],
                            OrderDate = row.IsNull("OrderDate") ? null : row["OrderDate"],
                            Total = row.IsNull("Total") ? null : row["Total"],
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
        public List<object> GetOrderDetailById(int id)
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
                cmd.CommandText = "GetOrderDetailById"; // lay ten store mun thuc hien
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", id);
                da.SelectCommand = cmd; // goi thuc thi store
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row.IsNull("OrderID") ? null : row["OrderID"],
                            CustomerID = row.IsNull("CustomerID") ? null : row["CustomerID"],
                            FullName = row.IsNull("FullName") ? null : row["FullName"],
                            OrderDate = row.IsNull("OrderDate") ? null : row["OrderDate"],
                            ProductId = row.IsNull("ProductId") ? null : row["ProductId"],
                            ProductName = row.IsNull("ProductName") ? null : row["ProductName"],
                            Quantity = row.IsNull("Quantity") ? null : row["Quantity"],
                            Price = row.IsNull("Price") ? null : row["Price"],
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
        #endregion
    }
}
