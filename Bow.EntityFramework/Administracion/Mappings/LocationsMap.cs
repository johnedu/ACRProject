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
    public class LocationsMap : MultiTenantMap<Locations>
    {
        public LocationsMap()
        {
            //Atributos
            Property(faq => faq.latitude).HasMaxLength(100);
            Property(faq => faq.latitude).IsRequired();
            Property(faq => faq.longitude).HasMaxLength(100);
            Property(faq => faq.longitude).IsRequired();
            Property(faq => faq.distance).HasMaxLength(100);
            Property(faq => faq.distance).IsRequired();
            Property(faq => faq.name).HasMaxLength(1000);
            Property(faq => faq.name).IsRequired();
            Property(faq => faq.description).HasMaxLength(10000);
            Property(faq => faq.description).IsRequired();

            //Tabla
            ToTable("locations");
        }
    }
}
