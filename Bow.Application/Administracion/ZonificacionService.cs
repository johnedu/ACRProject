using Abp.Localization;
using Abp.UI;
using AutoMapper;
using Bow.Administracion.DTOs.InputModels;
using Bow.Administracion.DTOs.OutputModels;
using Bow.Administracion.Entidades;
using Bow.Administracion.Repositorios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion
{
    public class ZonificacionService : IZonificacionService
    {
        #region Repositorios
        private IPreguntaFrecuenteRepositorio _preguntaFrecuenteRepositorio;
        private ICasesRepositorio _casesRepositorio;
        private ILocationsRepositorio _locationsRepositorio;
        private INewsRepositorio _newsRepositorio;
        private IDiagnosticRepositorio _diagnosticRepositorio;
        private IReportTypeRepositorio _reportTypeRepositorio;
        private ISliderRepositorio _sliderRepositorio;
        private IDriverRepositorio _driverRepositorio;

        #endregion

        //Inyección de Dependencia en el Servicio
        public ZonificacionService( IPreguntaFrecuenteRepositorio preguntaFrecuenteRepositorio,
                                    ICasesRepositorio casesRepositorio,
                                    ILocationsRepositorio locationsRepositorio,
                                    INewsRepositorio newsRepositorio,
                                    IDiagnosticRepositorio diagnosticRepositorio,
                                    IReportTypeRepositorio reportTypeRepositorio,
                                    ISliderRepositorio sliderRepositorio,
                                    IDriverRepositorio driverRepositorio)
        {
            _preguntaFrecuenteRepositorio = preguntaFrecuenteRepositorio;
            _casesRepositorio = casesRepositorio;
            _locationsRepositorio = locationsRepositorio;
            _newsRepositorio = newsRepositorio;
            _diagnosticRepositorio = diagnosticRepositorio;
            _reportTypeRepositorio = reportTypeRepositorio;
            _sliderRepositorio = sliderRepositorio;
            _driverRepositorio = driverRepositorio;
        }

        public GetPreguntaFrecuenteOutput GetPreguntaFrecuente(GetPreguntaFrecuenteInput paisInput)
        {
            return Mapper.Map<GetPreguntaFrecuenteOutput>(_preguntaFrecuenteRepositorio.Get(paisInput.Id));
        }

        public GetAllPreguntasFrecuentesOutput Faqs()
        {
            var listaPaises = _preguntaFrecuenteRepositorio.GetAllList().OrderBy(p => p.text);
            return new GetAllPreguntasFrecuentesOutput { PreguntasFrecuentes = Mapper.Map<List<PreguntaFrecuenteOutput>>(listaPaises) };
        }

        public void SavePreguntaFrecuente(SavePreguntaFrecuenteInput nuevoPais)
        {
            PreguntaFrecuente existePais = _preguntaFrecuenteRepositorio.FirstOrDefault(p => p.text.ToLower() == nuevoPais.Pregunta.ToLower());

            if (existePais == null)
            {
                _preguntaFrecuenteRepositorio.Insert(Mapper.Map<PreguntaFrecuente>(nuevoPais));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public void DeletePreguntaFrecuente(DeletePreguntaFrecuenteInput paisEliminar)
        {

            _preguntaFrecuenteRepositorio.Delete(paisEliminar.Id);
            

        }

        public void UpdatePreguntaFrecuente(UpdatePreguntaFrecuenteInput paisUpdate)
        {
            PreguntaFrecuente existePais = _preguntaFrecuenteRepositorio.FirstOrDefault(p => p.text.ToLower() == paisUpdate.Pregunta.ToLower() && p.Id != paisUpdate.Id);

            if (existePais == null)
            {
                var paisActualizar = _preguntaFrecuenteRepositorio.Update(Mapper.Map<PreguntaFrecuente>(paisUpdate));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public GetAllCasesOutput Cases()
        {
            var CasesList = _casesRepositorio.GetAllList().OrderBy(p => p.title);
            return new GetAllCasesOutput { Cases = Mapper.Map<List<CasesOutput>>(CasesList) };
        }

        public void Cases(SaveCaseInput nuevoCase)
        {
            Cases existeCase = _casesRepositorio.FirstOrDefault(p => p.title.ToLower() == nuevoCase.title.ToLower());

            if (existeCase == null)
            {
                Cases caso = Mapper.Map<Cases>(nuevoCase);
                caso.published_at = DateTime.Now;
                caso.url = "www.google.com";
                _casesRepositorio.Insert(caso);
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "") + "El caso ya existe";
                throw new UserFriendlyException(mensajeError);
            }
        }

        public GetAllLocationsOutput Points()
        {
            var LocationsList = _locationsRepositorio.GetAllList().OrderBy(p => p.name);
            return new GetAllLocationsOutput { Points = Mapper.Map<List<LocationsOutput>>(LocationsList) };
        }

        public void Points(SaveLocationInput nuevaLocation)
        {
            Locations existeLocation = _locationsRepositorio.FirstOrDefault(p => p.description.ToLower() == nuevaLocation.description.ToLower());

            if (existeLocation == null)
            {
                Locations location = Mapper.Map<Locations>(nuevaLocation);
                location.distance = "";
                _locationsRepositorio.Insert(location);
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "") + "El caso ya existe";
                throw new UserFriendlyException(mensajeError);
            }
        }

        public GetAllNewsOutput News()
        {
            var NewsList = _newsRepositorio.GetAllList().OrderBy(p => p.title);
            return new GetAllNewsOutput { News = Mapper.Map<List<NewsOutput>>(NewsList) };
        }

        public GetAllDiagnosticOutput Diagnostic()
        {
            var DiagnosticList = _diagnosticRepositorio.GetAllList().OrderBy(p => p.title);
            return new GetAllDiagnosticOutput { Diagnostic = Mapper.Map<List<DiagnosticOutput>>(DiagnosticList) };
        }

        public GetAllReporttypeOutput Reporttype()
        {
            var ReporttypeList = _reportTypeRepositorio.GetAllList().OrderBy(p => p.text);
            return new GetAllReporttypeOutput { Reporttype = Mapper.Map<List<ReporttypeOutput>>(ReporttypeList) };
        }

        public GetAllSliderOutput Slider()
        {
            var SliderList = _sliderRepositorio.GetAllList();
            return new GetAllSliderOutput { Slider = Mapper.Map<List<SliderOutput>>(SliderList) };
        }

        public void Driver(SaveDriverInput nuevoDriver)
        {
            _driverRepositorio.Insert(Mapper.Map<Driver>(nuevoDriver));
        }
    }
}
