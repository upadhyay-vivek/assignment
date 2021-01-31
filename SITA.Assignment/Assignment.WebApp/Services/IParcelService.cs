using Assignment.WebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Assignment.WebApp.Services
{
    public interface IParcelService
    {
        List<ParcelOutputDto> PostXmlData(HttpPostedFileBase file);
        List<ParcelOutputDto> ProcessData(string xmlData);
    }
}
