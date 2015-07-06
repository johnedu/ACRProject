using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class SaveDriverInput : IInputDto
    {
        public string plate { get; set; }
        public string type { get; set; }
        public string company { get; set; }
        public string observation { get; set; }
    }
}
