using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP_SalonNamestaja.DTO.ProstorijaDTO;
using ERP_SalonNamestaja.DTO.KategorijaDTO;
using ERP_SalonNamestaja.DTO.ProizvodDTO;
using ERP_SalonNamestaja.DTO.ProizvodjacDTO;
using ERP_SalonNamestaja.DTO.LokacijaDTO;
using ERP_SalonNamestaja.DTO.StavkaPorudzbineDTO;
using ERP_SalonNamestaja.DTO.PorudzbinaDTO;
using ERP_SalonNamestaja.DTO.StanjeDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prostorija, GetProstorijaDto>();
            CreateMap<AddProstorijaDto, Prostorija>();

            CreateMap<Kategorija, GetKategorijaDto>();
            CreateMap<AddKategorijaDto, Kategorija>();

            CreateMap<Lokacija, GetLokacijaDto>();
            CreateMap<AddKategorijaDto, Kategorija>();

            CreateMap<Porudzbina, GetPorudzbinaDto>();
            CreateMap<AddPorudzbinaDto, Porudzbina>();

            CreateMap<Proizvodjac, GetProizvodjacDto>();
            CreateMap<AddProizvodjacDto, Proizvodjac>();

            CreateMap<Stanje, GetStanjeDto>();
            CreateMap<AddStanjeDto, Stanje>();

            CreateMap<Proizvod, GetProizvodDto>();
            CreateMap<AddProizvodDto, Proizvod>();

            CreateMap<StavkaPorudzbine, GetStavkaPorudzbineDto>();
            CreateMap<AddStavkaPorudzbineDto, StavkaPorudzbine>();
        }
    }
}