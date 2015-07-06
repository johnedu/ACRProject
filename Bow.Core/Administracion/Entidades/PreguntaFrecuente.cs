﻿using Abp.Domain.Entities;
using Bow.EntidadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Entidades
{
    public class PreguntaFrecuente : EntidadMultiTenant
    {
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public bool EstadoActiva { get; set; }
    }
}
