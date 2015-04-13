﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class SaveUsuarioInput : IInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Coda { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        public int TipoId { get; set; }
    }
}
