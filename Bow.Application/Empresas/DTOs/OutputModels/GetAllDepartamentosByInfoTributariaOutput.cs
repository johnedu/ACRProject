﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Empresas.DTOs.OutputModels
{
    public class GetAllDepartamentosByInfoTributariaOutput : IOutputDto
    {
        public List<DepartamentosByInfoTributariaOutput> InfoTributariaDepartamentos { get; set; }
    }
}
