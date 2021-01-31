using Assignment.WebApp.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using AutoMapper;
using Assignment.WebApp.Models;
using Assignment.WebApp.Utils;
using Newtonsoft.Json;

namespace Assignment.WebApp.Services
{
    public class ParcelService : IParcelService
    {
        private readonly IMapper _mapper;
        public ParcelService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// This method will return data based on what posted in xml file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<ParcelOutputDto> PostXmlData(HttpPostedFileBase file)
        {
            var xmlContent = new StringBuilder();
            using (var reader = new StreamReader(file.InputStream))
            {
                while (reader.Peek() >= 0)
                    xmlContent.AppendLine(reader.ReadLine());
                var content = new StringContent(xmlContent.ToString(),
                                    Encoding.UTF8, "text/xml");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = client.PostAsync("http://localhost:51486/api/Parcel/ParseXml",
                              content).Result;
                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ParcelOutputDto>>(result);
                }
            }
            return null;
        }


        public List<ParcelOutputDto> ProcessData(string xmlData)
        {
            
            if (!string.IsNullOrEmpty(xmlData))
            {
                var container = new Container();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Container));
                StringReader stringReader = new StringReader(xmlData);
                container = (Container)xmlSerializer.Deserialize(stringReader);
                var parcels = new List<ParcelOutputDto>();
                foreach (var item in container.parcels)
                {
                    var parcel = _mapper.Map<Parcel, ParcelOutputDto>(item);
                    if (item.Value > 1000)
                    {
                        parcel.DepartmentName = DepartmentConstants.INSURANCE;
                    }
                    else
                    {
                        if (item.Weight <= 1)
                        {
                            parcel.DepartmentName = DepartmentConstants.MAIL;
                        }
                        else if (item.Weight > 1 && item.Weight <= 10)
                        {
                            parcel.DepartmentName = DepartmentConstants.REGULAR;
                        }
                        else
                        {
                            parcel.DepartmentName = DepartmentConstants.HEAVY;
                        }
                    }
                    parcels.Add(parcel);
                }
                return parcels;
            }


            return null;
        }
    }
}