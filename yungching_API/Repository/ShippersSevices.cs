using yungching_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
namespace yungching_API.Repository
{
    public class ShippersSevices : IShippersShippers
    {
        private readonly IConfiguration _Configuration;
        string defaultConnection = String.Empty;
        public ShippersSevices(IConfiguration configuration)
        {
            _Configuration = configuration;
            //字串設定TrustServerCertificate=True
            defaultConnection = _Configuration["ConnectionStrings:DefaultConnection"];
        }
        public IEnumerable<Shippers> GetShippersList()
        {
            string sqlcmd = "select *  FROM [master].[dbo].[Shippers] with (nolock) ";

            List<Shippers> shippersList = new List<Shippers>();

            using (SqlConnection cn = new SqlConnection(defaultConnection))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
                {
                    //rerusl = cmd.ExecuteScalar();
                    using (SqlDataAdapter salda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        salda.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0 && dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Shippers shipper = new Shippers()
                                {
                                    ShipperID = int.Parse(dr["ShipperID"].ToString() ?? "0"),
                                    CompanyName = dr["CompanyName"].ToString() ?? "無",
                                    Phone = dr["Phone"].ToString()
                                };
                                shippersList.Add(shipper);//DataRow Mapping To Model
                            }
                        }
                    }
                }
            }
            return shippersList.ToList();
        }

        public Shippers GetShippers(int ShipperID)
        {
            string sqlcmd = "select *  FROM [master].[dbo].[Shippers] with (nolock) Where ShipperID = @ShipperID ";

            Shippers shipper = new Shippers();

            using (SqlConnection cn = new SqlConnection(defaultConnection))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
                {
                    cmd.Parameters.Add("@ShipperID", System.Data.SqlDbType.Int).Value = ShipperID;
                    using (SqlDataAdapter salda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        salda.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0 && dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                shipper.ShipperID = int.Parse(dr["ShipperID"].ToString() ?? "0");
                                shipper.CompanyName = dr["CompanyName"].ToString() ?? "無";
                                shipper.Phone = dr["Phone"].ToString();
                            }
                        }
                    }
                }
            }
            return shipper;
        }

        public int DelShippers(int ShipperID)
        {
            string sqlcmd = "Delete [master].[dbo].[Shippers] Where ShipperID = @ShipperID ";

            using (SqlConnection cn = new SqlConnection(defaultConnection))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
                {
                    cmd.Parameters.Add("@ShipperID", System.Data.SqlDbType.Int).Value = ShipperID;
                   return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

