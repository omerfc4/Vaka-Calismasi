using System;
using System.Web.Mvc;
using Vaka.Models;
using Vaka.Services;

namespace Vaka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PostForm Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = PostService.ResultList(Model);
                    ViewData["FirstTraveller"] = result[0];
                    ViewData["SecondTraveller"] = result[1];
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

    }
}