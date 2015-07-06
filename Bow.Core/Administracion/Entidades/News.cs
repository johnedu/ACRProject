using Abp.Domain.Entities;
using Bow.EntidadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Entidades
{
    public class News : EntidadMultiTenant
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime published_at { get; set; }
        public string url { get; set; }
        public string image { get; set; }
    }
}
