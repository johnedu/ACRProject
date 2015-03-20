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
        private IPreguntaFrecuenteRepositorio _paisRepositorio;

        #endregion

        //Inyección de Dependencia en el Servicio
        public ZonificacionService(IPreguntaFrecuenteRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        public GetPreguntaFrecuenteOutput GetPreguntaFrecuente(GetPreguntaFrecuenteInput paisInput)
        {
            return Mapper.Map<GetPreguntaFrecuenteOutput>(_paisRepositorio.Get(paisInput.Id));
        }

        public GetAllPreguntasFrecuentesOutput GetAllPreguntasFrecuentes()
        {
            var listaPaises = _paisRepositorio.GetAllList().OrderBy(p => p.Pregunta);
            return new GetAllPreguntasFrecuentesOutput { PreguntasFrecuentes = Mapper.Map<List<PreguntaFrecuenteOutput>>(listaPaises) };
        }

        public void SavePreguntaFrecuente(SavePreguntaFrecuenteInput nuevoPais)
        {
            PreguntaFrecuente existePais = _paisRepositorio.FirstOrDefault(p => p.Pregunta.ToLower() == nuevoPais.Pregunta.ToLower());

            if (existePais == null)
            {
                _paisRepositorio.Insert(Mapper.Map<PreguntaFrecuente>(nuevoPais));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public void DeletePreguntaFrecuente(DeletePreguntaFrecuenteInput paisEliminar)
        {
            
                _paisRepositorio.Delete(paisEliminar.Id);
            

        }

        public void UpdatePreguntaFrecuente(UpdatePreguntaFrecuenteInput paisUpdate)
        {
            PreguntaFrecuente existePais = _paisRepositorio.FirstOrDefault(p => p.Pregunta.ToLower() == paisUpdate.Pregunta.ToLower() && p.Id != paisUpdate.Id);

            if (existePais == null)
            {
                var paisActualizar = _paisRepositorio.Update(Mapper.Map<PreguntaFrecuente>(paisUpdate));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }
    }
}
