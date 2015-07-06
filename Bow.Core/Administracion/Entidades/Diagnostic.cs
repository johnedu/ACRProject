using Abp.Domain.Entities;
using Bow.EntidadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Entidades
{
    public class Diagnostic : EntidadMultiTenant
    {
        public string title { get; set; }
        public string type { get; set; }
        public string advice { get; set; }
        public string image { get; set; }
    }
}
