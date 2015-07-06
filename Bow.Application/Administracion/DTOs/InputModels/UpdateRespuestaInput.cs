using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class UpdateRespuestaInput : EntityDto, IInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Texto { get; set; }
        [Required]
        public bool Comodin50_50 { get; set; }
        [Required]
        public bool RespuestaVerdadera { get; set; }
        public int PreguntaId { get; set; }
    }
}
