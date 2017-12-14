using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GoogleAuthSpike.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public JsonResult GetGoogleAuth()
        {
            GoogleAuthUtil _util = new GoogleAuthUtil(_config);
            var setupInfo = _util.GetScanCode();
            return Json(setupInfo);
        }

        public JsonResult ValidateCode(string code)
        {
            GoogleAuthUtil ob = new GoogleAuthUtil(_config);
            return Json(ob.ValidateCode(code));
        }

        public JsonResult ValidateExistingAuthCode(string code, string memberNumber)
        {
            DataAccess _da = new DataAccess();
            GoogleAuthModel model = _da.GetGoogleAuthDetails(memberNumber);
            GoogleAuthUtil ob = new GoogleAuthUtil(_config);

            return Json(ob.ValidateCode(code, model.PassCodeGoogleSecret));
        }
    }
}
