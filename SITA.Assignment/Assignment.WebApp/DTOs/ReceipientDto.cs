using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.WebApp.DTOs
{
    public class ReceipientDto
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}