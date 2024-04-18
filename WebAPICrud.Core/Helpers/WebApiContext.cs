using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICrud.Core.Helpers
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() { }

        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public WebApiContext(string connectionString) : base(Helpers.ContextConfiguration.GetOptions(connectionString))
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helpers.ContextConfiguration.ConexionString, builder => {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });

            }
        }
    }
}