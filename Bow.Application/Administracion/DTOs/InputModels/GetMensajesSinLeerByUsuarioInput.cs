﻿
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class GetMensajesSinLeerByUsuarioInput : IInputDto
    {
        public string Usuario { get; set; }
    }
}
