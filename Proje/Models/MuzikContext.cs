using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjeAdi.Models
{
    public class MuzikContext : DbContext
    {
        public MuzikContext() : base("MuzikDB") { }

        public DbSet<Muzik> Muzikler { get; set; }
    }
}
