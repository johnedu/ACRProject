using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.DTOs.InputModels
{
    public class EnviarMensajeInput : IInputDto
    {
        [Required]
        public string UsuarioEmisorId { get; set; }
        [Required]
        public int UsuarioReceptorId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Contenido { get; set; }
        [Required]
        public bool FueLeido { get; set; }
    }
}
