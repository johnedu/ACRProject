using Abp.Domain.Entities;
using Bow.EntidadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Entidades
{
    public class Locations : EntidadMultiTenant
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string distance { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
