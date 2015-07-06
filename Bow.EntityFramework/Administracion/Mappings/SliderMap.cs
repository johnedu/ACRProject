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
    public class SliderMap : MultiTenantMap<Slider>
    {
        public SliderMap()
        {
            //Atributos
            Property(faq => faq.Image).HasMaxLength(10000);
            Property(faq => faq.Image).IsRequired();

            //Tabla
            ToTable("slider");
        }
    }
}
