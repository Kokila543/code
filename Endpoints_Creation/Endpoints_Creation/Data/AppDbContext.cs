using System.Collections.Generic;
using Endpoints_Creation.Models;
using Microsoft.EntityFrameworkCore;
namespace Endpoints_Creation.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TagMasterDto> TagMasters { get; set; }
    }
}
