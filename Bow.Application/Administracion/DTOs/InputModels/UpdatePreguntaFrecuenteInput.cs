﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class UpdatePreguntaFrecuenteInput : EntityDto, IInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Pregunta { get; set; }
        [Required]
        [MaxLength(300)]
        public string Respuesta { get; set; }
    }
}
