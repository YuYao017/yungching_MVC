
using yungching_MVC.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace yungching_MVC.Services
{
    public class ShippersSevices : IShippersShippers
    {
        private readonly IConfiguration _Configuration;
        private HttpClient _HttpClient;
        string defaultConnection = String.Empty;
        public ShippersSevices(IConfiguration configuration,HttpClient httpClient)
        {
            _Configuration = configuration;
            _HttpClient = httpClient;
            //字串設定TrustServerCertificate=True
            defaultConnection = _Configuration["ConnectionStrings:DefaultConnection"];
        }
        public List<Shipper> GetShippersList()
        {
            try
            {
                HttpResponseMessage response = _HttpClient.GetAsync("/api/Northwind").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                List<Shipper> data = JsonConvert.DeserializeObject<List<Shipper>>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Shipper GetShipper(int ShipperID)
        //{
        //    try
        //    {
        //        string sqlcmd = "select *  FROM [master].[dbo].[Shippers] with (nolock) Where ShipperID = @ShipperID ";

        //        Shipper shipper = new Shipper();

        //        using (SqlConnection cn = new SqlConnection(defaultConnection))
        //        {
        //            cn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
        //            {
        //                cmd.Parameters.Add("@ShipperID", System.Data.SqlDbType.Int).Value = ShipperID;
        //                using (SqlDataAdapter salda = new SqlDataAdapter(cmd))
        //                {
        //                    DataSet ds = new DataSet();
        //                    salda.Fill(ds);
        //                    DataTable dt = ds.Tables[0];

        //                    if (dt.Rows.Count > 0 && dt != null)
        //                    {
        //                        foreach (DataRow dr in dt.Rows)
        //                        {
        //                            shipper.ShipperId = int.Parse(dr["ShipperID"].ToString() ?? "0");
        //                            shipper.CompanyName = dr["CompanyName"].ToString() ?? "無";
        //                            shipper.Phone = dr["Phone"].ToString();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return shipper;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public int DelShipper(int ShipperID)
        //{
        //    try
        //    {
        //        string sqlcmd = "Delete [master].[dbo].[Shippers] Where ShipperID = @ShipperID ";

        //        using (SqlConnection cn = new SqlConnection(defaultConnection))
        //        {
        //            cn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
        //            {
        //                cmd.Parameters.Add("@ShipperID", System.Data.SqlDbType.Int).Value = ShipperID;
        //                return cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public int updateShipper(int ShipperID, Shipper Shipper)
        //{
        //    try
        //    {
        //        string sqlcmd = @"Update [master].[dbo].[Shippers] Set CompanyName = @CompanyName,
        //                      Phone = @Phone Where ShipperID = @ShipperID ";

        //        using (SqlConnection cn = new SqlConnection(defaultConnection))
        //        {
        //            cn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
        //            {
        //                cmd.Parameters.Add("@ShipperID", SqlDbType.Int).Value = ShipperID;
        //                cmd.Parameters.Add("@CompanyName", SqlDbType.NChar).Value = Shipper.CompanyName;
        //                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = Shipper.Phone;
        //                return cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }


        //}

        //public int InsShipper(Shipper Shipper)
        //{
        //    try
        //    {
        //        string sqlcmd = @"Insert Into [master].[dbo].[Shippers]
        //                      Values( @CompanyName , @Phone )";

        //        using (SqlConnection cn = new SqlConnection(defaultConnection))
        //        {
        //            cn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
        //            {
        //                cmd.Parameters.Add("@CompanyName", SqlDbType.NChar).Value = Shipper.CompanyName;
        //                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = Shipper.Phone;
        //                return cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}
    }
}

