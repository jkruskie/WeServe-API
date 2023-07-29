using Microsoft.EntityFrameworkCore;

namespace WeServe.Data
{
    /// <summary>
    /// The database context for the WeServe application.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class WeServeContext : DbContext
    {
        /// <summary>
        /// Create a new instance of the WeServeContext.
        /// </summary>
        /// <param name="options"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public WeServeContext(DbContextOptions<WeServeContext> options) : base(options) { }

        // Models



        /// <summary>
        /// Configure the models for the database context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the models
        }
    }
}
