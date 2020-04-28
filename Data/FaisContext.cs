using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAIS_PROTOTIPO_.Models;
using Microsoft.EntityFrameworkCore;

namespace FAIS_PROTOTIPO_.Data
{
    public class FaisContext : DbContext
    {
        public FaisContext(DbContextOptions<FaisContext> options)
            : base(options)
        {
        }

        public DbSet<Suscriptor> Suscriptor { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
