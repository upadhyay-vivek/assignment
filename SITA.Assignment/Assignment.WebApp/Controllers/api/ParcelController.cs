using Assignment.WebApp.DTOs;
using Assignment.WebApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;

namespace Assignment.WebApp.Controllers.api
{
    public class ParcelController : ApiController
    {
        private readonly IParcelService _parcelService;
        public ParcelController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }
        [HttpPost]
        public IHttpActionResult ParseXml()
        {
            var xmlData = Request.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(xmlData))
            {
                return Ok(_parcelService.ProcessData(xmlData));
            }
            
            return null;
        }

        public string Ping()
        {
            return "Pong";
        }
    }
}
