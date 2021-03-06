﻿using Abp.Application.Services;
using Bow.Administracion.DTOs.InputModels;
using Bow.Administracion.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion
{
    /// <summary>
    ///     Definición de los servicios ofrecidos por el módulo de Zonificación
    /// </summary>
    public interface IZonificacionService : IApplicationService
    {
        GetPreguntaFrecuenteOutput GetPreguntaFrecuente(GetPreguntaFrecuenteInput paisInput);

        GetAllPreguntasFrecuentesOutput Faqs();

        void SavePreguntaFrecuente(SavePreguntaFrecuenteInput nuevoPais);

        void DeletePreguntaFrecuente(DeletePreguntaFrecuenteInput paisEliminar);

        void UpdatePreguntaFrecuente(UpdatePreguntaFrecuenteInput paisUpdate);

        GetAllCasesOutput Cases();

        void SaveCases(SaveCaseInput nuevoCase);

        GetAllLocationsOutput Points();

        void SavePoints(SaveLocationInput nuevaLocation);

        GetAllNewsOutput News();

        GetAllDiagnosticOutput Diagnostic();

        GetAllReporttypeOutput Reporttype();

        GetAllSliderOutput Slider();

        void SaveDriver(SaveDriverInput nuevoDriver);

    }
}


