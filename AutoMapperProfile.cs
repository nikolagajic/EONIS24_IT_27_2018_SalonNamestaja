using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP_SalonNamestaja.DTO.Prostorija;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prostorija, GetProstorijaDto>();
            CreateMap<AddProstorijaDto, Prostorija>();
        }
    }
}