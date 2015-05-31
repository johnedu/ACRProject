﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Empresas.DTOs.OutputModels
{
    public class LocalidadesByInfoTributariaOutput : EntityDto 
    {
        public int LocalidadId { get; set; }
        public string Localidad { get; set; }
        public int DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public int PaisId { get; set; }
        public string Pais { get; set; }
    }
}
