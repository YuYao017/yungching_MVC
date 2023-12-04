using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using yungching_MVC.Services;
using yungching_MVC.Models;

namespace yungching_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShippersShippers _IShippersShippers;
        public HomeController(ILogger<HomeController> logger, IShippersShippers iShippersShippers)
        {
            _logger = logger;
            _IShippersShippers = iShippersShippers;
        }

        public ActionResult Index()
        {
         
            List<Shipper> aaa  = _IShippersShippers.GetShippersList();
         
            return View(aaa);
        }
    

        //public IActionResult Privacy()
        //{
        //    string test;
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}