using Account.ApplicationCore.DTOs.AppSettings;
using Account.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Account.Infrastructure.Data
{
    public class EFContext : DbContext, IEFContext
    {
        private readonly string _connectionString;

        public EFContext(IOptions<AppSettings> appSettings) =>
            _connectionString = appSettings.Value.DataBase.SqlServer.ConnectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}