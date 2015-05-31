﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Afiliaciones.DTOs.InputModels
{
    public class DeleteBeneficioAdicionalPlanExequialInput
    {
        [Required(ErrorMessageResourceName = "beneficiosPlanExequial_delete_Id_requerido", ErrorMessageResourceType = typeof(Bow.Resources.TextosValidacionDTO))]
        public int Id { get; set; }
    }
}
