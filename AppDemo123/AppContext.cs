using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppDemo123
{
    internal class AppContext : DbContext
    {

        public DbSet<Agent> Agents {  get; set; }

        public AppContext() : base("DefaultConnection") { }

    }
}
