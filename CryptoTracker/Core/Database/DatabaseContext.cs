using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CryptoTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Core.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ExchangeSettings> ExchangeSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Filename=CryptoTracker.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(options);
        }

    }
}
