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
    public class PreguntaFrecuenteMap : MultiTenantMap<PreguntaFrecuente>
    {
        public PreguntaFrecuenteMap()
        {
            //Atributos
            Property(faq => faq.text).HasMaxLength(1000);
            Property(faq => faq.text).IsRequired();
            Property(faq => faq.answer).HasMaxLength(10000);
            Property(faq => faq.answer).IsRequired();

            //Tabla
            ToTable("pregunta_frecuente");
        }
    }
}
