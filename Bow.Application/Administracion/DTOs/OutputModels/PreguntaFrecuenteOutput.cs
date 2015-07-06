using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.OutputModels
{
    public class PreguntaFrecuenteOutput : EntityDto
    {
        public string text { get; set; }
        public string answer { get; set; }
        public DateTime published_at { get; set; }
        public string url { get; set; }
    }
}
