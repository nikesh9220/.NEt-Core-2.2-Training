using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{

    /// <summary>
    ///   The Data Access Layer Class
    ///   The DbContext Will manage Mapping and Transaction
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
    /// <summary>
    /// DbSet<T>, Represent Mapping of T Class With Table T
    /// </summary>
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Student> Students{ get; set; }
        /// <summary>
        ///     DbContext Class will read Connection String
        ///     From ConfigureServices() of the startup class
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        /// <summary>
        ///  Read the model 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
