using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using yungching_API.Model;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yungching_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        string defaultConnection = String.Empty;
        public NorthwindController(IConfiguration configuration)
        {
            _Configuration = configuration;
            //字串設定TrustServerCertificate=True
            defaultConnection = _Configuration["ConnectionStrings:DefaultConnection"];
        }
        // GET: api/<NorthwindController>
        [HttpGet]
        public IEnumerable<Shippers> Get()
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

        // GET api/<NorthwindController>/5
        [HttpGet("{ShipperID}")]
        public Shippers Get(int ShipperID)
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

        // POST api/<NorthwindController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NorthwindController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NorthwindController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
