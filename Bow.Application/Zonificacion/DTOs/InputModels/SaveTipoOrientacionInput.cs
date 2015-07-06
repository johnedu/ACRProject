﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Zonificacion.DTOs.InputModels
{
    public class SaveTipoOrientacionInput : IInputDto
    {
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }
    }
}
