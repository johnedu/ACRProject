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
    public class DiagnosticMap : MultiTenantMap<Diagnostic>
    {
        public DiagnosticMap()
        {
            //Atributos
            Property(faq => faq.title).HasMaxLength(1000);
            Property(faq => faq.title).IsRequired();

            //Tabla
            ToTable("diagnostic");
        }
    }
}
