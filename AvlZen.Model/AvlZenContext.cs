using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlZen.Model
{
    class AvlZenContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Weekly> Weeklies { get; set; }
    }
}
