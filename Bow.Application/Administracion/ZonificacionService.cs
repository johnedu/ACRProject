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

        #endregion

        //Inyección de Dependencia en el Servicio
        public ZonificacionService(IPreguntaFrecuenteRepositorio preguntaFrecuenteRepositorio, ICasesRepositorio casesRepositorio)
        {
            _preguntaFrecuenteRepositorio = preguntaFrecuenteRepositorio;
            _casesRepositorio = casesRepositorio;
        }

        public GetPreguntaFrecuenteOutput GetPreguntaFrecuente(GetPreguntaFrecuenteInput paisInput)
        {
            return Mapper.Map<GetPreguntaFrecuenteOutput>(_preguntaFrecuenteRepositorio.Get(paisInput.Id));
        }

        public GetAllPreguntasFrecuentesOutput GetAllPreguntasFrecuentes()
        {
            var listaPaises = _preguntaFrecuenteRepositorio.GetAllList().OrderBy(p => p.Pregunta);
            return new GetAllPreguntasFrecuentesOutput { PreguntasFrecuentes = Mapper.Map<List<PreguntaFrecuenteOutput>>(listaPaises) };
        }

        public void SavePreguntaFrecuente(SavePreguntaFrecuenteInput nuevoPais)
        {
            PreguntaFrecuente existePais = _preguntaFrecuenteRepositorio.FirstOrDefault(p => p.Pregunta.ToLower() == nuevoPais.Pregunta.ToLower());

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
            PreguntaFrecuente existePais = _preguntaFrecuenteRepositorio.FirstOrDefault(p => p.Pregunta.ToLower() == paisUpdate.Pregunta.ToLower() && p.Id != paisUpdate.Id);

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

        public GetAllCasesOutput GetCases()
        {
            var CasesList = _casesRepositorio.GetAllList().OrderBy(p => p.title);
            return new GetAllCasesOutput { Cases = Mapper.Map<List<CasesOutput>>(CasesList) };
        }

        public void SaveCase(SaveCaseInput nuevoCase)
        {
            Cases existeCase = _casesRepositorio.FirstOrDefault(p => p.title.ToLower() == nuevoCase.title.ToLower());

            if (existeCase == null)
            {
                _casesRepositorio.Insert(Mapper.Map<Cases>(nuevoCase));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "") + "El caso ya existe";
                throw new UserFriendlyException(mensajeError);
            }
        }
    }
}
