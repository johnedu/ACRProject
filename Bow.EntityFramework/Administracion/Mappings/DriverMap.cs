using Bow.MappingsBase;
using Bow.Administracion.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Mappings
{
    public class DriverMap : MultiTenantMap<Driver>
    {
        public DriverMap()
        {
            //Atributos

            //Tabla
            ToTable("driver");
        }
    }
}
