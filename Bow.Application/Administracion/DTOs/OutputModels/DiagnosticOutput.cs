using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.OutputModels
{
    public class DiagnosticOutput : EntityDto
    {
        public string title { get; set; }
        public string type { get; set; }
        public string advice { get; set; }
        public string image { get; set; }
    }
}
