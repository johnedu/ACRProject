namespace Bow.Migrations
{
    using Bow.Administracion.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bow.EntityFramework.BowDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Bow";
        }

        protected override void Seed(Bow.EntityFramework.BowDbContext context)
        {
        }

        
    }
}
