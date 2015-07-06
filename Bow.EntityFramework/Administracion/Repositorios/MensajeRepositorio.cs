using Abp.EntityFramework;
using Bow.EntityFramework;
using Bow.EntityFramework.Repositories;
using Bow.Administracion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bow.Administracion.Repositorios
{
    public class MensajeRepositorio : BowRepositoryBase<Mensaje>, IMensajeRepositorio
    {
        public MensajeRepositorio(IDbContextProvider<BowDbContext> dbContextProvider)
           : base(dbContextProvider)
        {

        }

        public List<Mensaje> GetAllMensajesByEmisor(int EmisorId)
        {
            return GetAll().Where(m => m.UsuarioEmisorId == EmisorId).Include(m => m.UsuarioEmisor).Include(m => m.UsuarioReceptor).OrderByDescending(m => m.Id).ToList();
        }

        public List<Mensaje> GetAllMensajesByReceptor(int ReceptorId)
        {
            return GetAll().Where(m => m.UsuarioReceptorId == ReceptorId).Include(m => m.UsuarioEmisor).Include(m => m.UsuarioReceptor).OrderByDescending(m => m.Id).ToList();
        }
    }
}
