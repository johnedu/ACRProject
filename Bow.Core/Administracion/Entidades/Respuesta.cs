using Abp.Domain.Entities;
using Bow.EntidadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Entidades
{
    public class Respuesta : EntidadMultiTenant
    {
        public string Texto { get; set; }
        public bool Comodin50_50 { get; set; }
        public bool RespuestaVerdadera { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta PreguntaRespuesta { get; set; }
    }
}
