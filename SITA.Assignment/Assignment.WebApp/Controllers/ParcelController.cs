using Assignment.WebApp.DTOs;
using Assignment.WebApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Assignment.WebApp.Controllers
{
    public class ParcelController : Controller
    {
        private readonly IParcelService _parcelService;

        public ParcelController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }
        // GET: Parcel
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            
            if (file!=null)
            {
                var result = _parcelService.PostXmlData(file);
                TempData["parcelList"] = result;
                return RedirectToAction("ParcelStatus");
            }

            ViewBag.Message = "No File Uploaded";
            return View();
        }

       
        public ActionResult ParcelStatus(List<ParcelOutputDto> result)
        {
            var parcelList= TempData["parcelList"] as IEnumerable<ParcelOutputDto>;
            return View(parcelList);
        }
    }
}