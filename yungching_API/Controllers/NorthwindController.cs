using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using yungching_API.Model;
using System.Linq;
using yungching_API.Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yungching_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly IShippersShippers _IShippersShippers;
        string defaultConnection = String.Empty;
        public NorthwindController(IConfiguration configuration, IShippersShippers shippersShippers)
        {
            _Configuration = configuration;
            _IShippersShippers = shippersShippers;
            //字串設定TrustServerCertificate=True
            defaultConnection = _Configuration["ConnectionStrings:DefaultConnection"];
        }
        // GET: api/<NorthwindController>
        [HttpGet]
        public ActionResult<IEnumerable<Shipper>> Get()
        {
            try
            {
                return _IShippersShippers.GetShippersList();
            }
            catch
            {
                return NotFound();
            }
            //string sqlcmd = "select *  FROM [master].[dbo].[Shippers] with (nolock) ";

            //List<Shippers> shippersList = new List<Shippers>();

            //using (SqlConnection cn = new SqlConnection(defaultConnection))
            //{
            //    cn.Open();
            //    using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
            //    {
            //        //rerusl = cmd.ExecuteScalar();
            //        using (SqlDataAdapter salda = new SqlDataAdapter(cmd))
            //        {
            //            DataSet ds = new DataSet();
            //            salda.Fill(ds);
            //            DataTable dt = ds.Tables[0];

            //            if (dt.Rows.Count > 0 && dt != null)
            //            {
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    Shippers shipper = new Shippers()
            //                    {
            //                        ShipperID = int.Parse(dr["ShipperID"].ToString() ?? "0"),
            //                        CompanyName = dr["CompanyName"].ToString() ?? "無",
            //                        Phone = dr["Phone"].ToString()
            //                    };
            //                    shippersList.Add(shipper);//DataRow Mapping To Model
            //                }
            //            }
            //        }
            //    }
            //}
            //return shippersList.ToList();
        }

        // GET api/<NorthwindController>/5
        [HttpGet("{ShipperID}")]
        public ActionResult<Shipper> Get(int ShipperID)
        {
            try
            {
                Shipper shippers = _IShippersShippers.GetShipper(ShipperID);
                if (shippers != null && shippers.ShipperID != 0)
                {
                    return shippers;
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return NotFound();
            }
            //string sqlcmd = "select *  FROM [master].[dbo].[Shippers] with (nolock) Where ShipperID = @ShipperID ";

            //Shippers shipper = new Shippers();

            //using (SqlConnection cn = new SqlConnection(defaultConnection))
            //{
            //    cn.Open();
            //    using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
            //    {
            //        cmd.Parameters.Add("@ShipperID", System.Data.SqlDbType.Int).Value = ShipperID;
            //        using (SqlDataAdapter salda = new SqlDataAdapter(cmd))
            //        {
            //            DataSet ds = new DataSet();
            //            salda.Fill(ds);
            //            DataTable dt = ds.Tables[0];

            //            if (dt.Rows.Count > 0 && dt != null)
            //            {
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    shipper.ShipperID = int.Parse(dr["ShipperID"].ToString() ?? "0");
            //                    shipper.CompanyName = dr["CompanyName"].ToString() ?? "無";
            //                    shipper.Phone = dr["Phone"].ToString();
            //                }
            //            }
            //        }
            //    }
            //}
            //return shipper;
        }

        // POST api/<NorthwindController>
        [HttpPost]
        public string Post([FromBody] Shipper Shippers)
        {

            try
            {
                int reslut = _IShippersShippers.InsShipper(Shippers);
                if (reslut == 1)
                {
                    return $"新增成功";
                }
                else
                {
                    return $"新增失敗";
                }
            }
            catch
            {
                return $"新增失敗";
            }
        }
        // PUT api/<NorthwindController>/5
        [HttpPut("{ShipperID}")]
        public string Put(int ShipperID, [FromBody] Shipper Shippers)
        {
            try
            {
                int reslut = _IShippersShippers.updateShipper(ShipperID, Shippers);
                if (reslut == 1)
                {
                    return $"{ShipperID}更新成功";
                }
                else
                {
                    return $"{ShipperID}更新失敗";
                }
            }
            catch
            {
                return $"{ShipperID}更新失敗";
            }

        }

        // DELETE api/<NorthwindController>/5
        [HttpDelete("{ShipperID}")]
        public string Delete(int ShipperID)
        {
            try
            {
                int reslut = _IShippersShippers.DelShipper(ShipperID);
                if (reslut == 1)
                {
                    return $"{ShipperID}刪除成功";
                }
                else
                {
                    return $"{ShipperID}刪除失敗";
                }
            }
            catch
            {
                return $"{ShipperID}更新失敗";
            }
        }
    }
}
