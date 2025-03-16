using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class KisiContext : DbContext
    {
        public KisiContext(DbContextOptions<KisiContext> options) :base(options)
        {

        }

        public DbSet<Kisiler> Kisiler { get; set; }
    }
}
