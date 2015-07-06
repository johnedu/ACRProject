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
    public class CasesMap : MultiTenantMap<Cases>
    {
        public CasesMap()
        {
            //Atributos
            Property(faq => faq.title).HasMaxLength(1000);
            Property(faq => faq.title).IsRequired();
            Property(faq => faq.description).HasMaxLength(10000);
            Property(faq => faq.description).IsRequired();
            Property(faq => faq.published_at).IsRequired();

            //Tabla
            ToTable("cases");
        }
    }
}
