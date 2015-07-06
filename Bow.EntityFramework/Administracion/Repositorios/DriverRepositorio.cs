using Abp.EntityFramework;
using Bow.EntityFramework;
using Bow.EntityFramework.Repositories;
using Bow.Administracion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion.Repositorios
{
    public class DriverRepositorio : BowRepositoryBase<Driver>, IDriverRepositorio
    {
        public DriverRepositorio(IDbContextProvider<BowDbContext> dbContextProvider)
           : base(dbContextProvider)
        {

        }
    }
}
