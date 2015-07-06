using Abp.Domain.Entities;
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
        public string text { get; set; }
        public string answer { get; set; }
        public DateTime published_at { get; set; }
        public string url { get; set; }
    }
}
