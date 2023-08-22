using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPasteBin.Models;

namespace MvcPasteBin.Data
{
    public class MvcPasteBinContext : DbContext
    {
        public MvcPasteBinContext (DbContextOptions<MvcPasteBinContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPasteBin.Models.PasteBin> PasteBin { get; set; } = default!;
    }
}
