using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class SaveLocationInput : IInputDto
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
