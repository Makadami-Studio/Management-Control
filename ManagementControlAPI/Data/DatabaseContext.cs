using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagementControlAPI.Models;

namespace ManagementControlAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

            internal object FirstOrDefault(Func<object, bool> value)
            {
                  throw new NotImplementedException();
            }
      }
}