﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Zonificacion.DTOs.InputModels
{
    public class GetBarriosByZonaDisponiblesInput : IInputDto
    {
        public int ZonaId { get; set; }
    }
}