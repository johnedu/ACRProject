using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.OutputModels
{
    public class LocationsOutput : EntityDto
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string distance { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
