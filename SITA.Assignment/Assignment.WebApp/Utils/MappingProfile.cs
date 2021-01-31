using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.WebApp.DTOs;
using Assignment.WebApp.Models;
using AutoMapper;

namespace Assignment.WebApp.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Parcel, ParcelOutputDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Sender, SenderDto>();
            CreateMap<Receipient, ReceipientDto>();
                
        }
    }
}