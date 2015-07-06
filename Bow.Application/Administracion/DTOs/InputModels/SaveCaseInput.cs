using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class SaveCaseInput : IInputDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public string published_at { get; set; }
        public string url { get; set; }
        public string image { get; set; }
    }
}
