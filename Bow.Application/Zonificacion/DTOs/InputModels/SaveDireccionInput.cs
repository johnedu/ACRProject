﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Zonificacion.DTOs.InputModels
{
    public class SaveDireccionInput : IInputDto
    {
        public string Nombre { get; set; }
        public string Pista { get; set; }
        public int? ManzanaId { get; set; }
        public int? BarrioId { get; set; }
        public int? TorieLocalidad1Id { get; set; }
        public int? Orientacion1 { get; set; }
        public int? SufijoLocalidad1Id { get; set; }
        public int? TorieLocalidad2Id { get; set; }
        public int? Orientacion2 { get; set; }
        public int? SufijoLocalidad2Id { get; set; }
        public string Porton { get; set; }
        public string Apartamento { get; set; }
        public string DireccionCompleta { get; set; }
        public string ZipCode { get; set; }
        public int LocalidadId { get; set; }
        //public bool VisibleSinNom { get; set; }
        //public bool VisibleConNom { get; set; }
        //public bool VisibleSinNomUsa { get; set; }
        //public bool VisibleConNomUsa { get; set; }
    }
}
