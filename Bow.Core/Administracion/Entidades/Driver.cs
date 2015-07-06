using Abp.Domain.Entities;
using Bow.EntidadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Entidades
{
    public class Driver : EntidadMultiTenant
    {
        public string plate { get; set; }
        public string type { get; set; }
        public string company { get; set; }
        public string observation { get; set; }
    }
}
