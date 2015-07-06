﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Personas.DTOs.OutputModels
{
    public class OpcionPreferenciaPersonaOutput : IOutputDto
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int OpcionPreferenciaId { get; set; }
        public string TipoCambio { get; set; }
        public int PreferenciaId { get; set; }
    }
}
