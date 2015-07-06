using Bow.Utilidades.AutoMapper;
using Bow.Administracion.DTOs.InputModels;
using Bow.Administracion.DTOs.OutputModels;
using Bow.Administracion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Zonificacion
{
    public class AutoMapperZonificacionProfile : AutoMapperBaseProfile
    {
        public AutoMapperZonificacionProfile()
            : base("AutoMapperZonificacionProfile")
        {
        }

        protected override void CrearMappings()
        {
            CreateMap<SavePreguntaFrecuenteInput, PreguntaFrecuente>();
            CreateMap<UpdatePreguntaFrecuenteInput, PreguntaFrecuente>();
            CreateMap<PreguntaFrecuente, GetPreguntaFrecuenteOutput>();
            CreateMap<PreguntaFrecuente, PreguntaFrecuenteOutput>();

            CreateMap<SaveDriverInput, Cases>();
            CreateMap<Cases, CasesOutput>();

            CreateMap<SaveLocationInput, Locations>();
            CreateMap<Locations, LocationsOutput>();

            CreateMap<News, NewsOutput>();

            CreateMap<Diagnostic, DiagnosticOutput>();

            CreateMap<ReportType, ReporttypeOutput>();

            CreateMap<Slider, SliderOutput>();

            CreateMap<SaveDriverInput, Driver>();
            
        }
    }
}
