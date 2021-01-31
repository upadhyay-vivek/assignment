using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.WebApp.DTOs
{
    public class ParcelOutputDto
    {
        
        public SenderDto Sender { get; set; }
        public ReceipientDto Receipient { get; set; }
        public decimal Weight { get; set; }
        public decimal Value { get; set; }
        public string DepartmentName { get; set; }
    }
}