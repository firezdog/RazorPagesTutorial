using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RazorPagesMovie.Models;

namespace RazorPagesMovie
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RazorPagesMovieContext>
    {
        public RazorPagesMovieContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RazorPagesMovieContext>();

            var connectionString = configuration.GetConnectionString("RazorPagesMovieContext");

            builder.UseSqlServer(connectionString);

            return new RazorPagesMovieContext(builder.Options);
        }
    }
}