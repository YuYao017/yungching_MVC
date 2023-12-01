using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace yungching_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IConfiguration _Configuration;


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("test")]
        public int test()
        {
            //¦r¦ê³]©wTrustServerCertificate=True
            var defaultConnection = _Configuration["ConnectionStrings:DefaultConnection"];
            //string ConnectionString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
            //string test = builder
            string sqlcmd = "select *  FROM [master].[dbo].[Shippers] with (nolock) ";
            int rerusl = 0;
            using (SqlConnection cn = new SqlConnection(defaultConnection))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlcmd, cn))
                {
                    rerusl = Convert.ToInt32(cmd.ExecuteScalar());
                    //using (SqlDataAdapter adpter = new SqlDataAdapter(cmd))
                    //{
                    //    System.Data.DataSet ds = new System.Data.DataSet();
                    //    adpter.Fill(ds);
                    //    System.Data.DataTable dt = ds.Tables[0];

                    //    foreach (System.Data.DataRow dr in dt.Rows)
                    //    {
                    //        ObjFgUserData user = getPersonFromDataRow(dr);
                    //        users.Add(user);//DataRow Mapping To Model
                    //    }
                    //}
                }
            } 
                return rerusl;
        }
    }
}