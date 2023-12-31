﻿using Microsoft.EntityFrameworkCore;
using WeServe.Models;

namespace WeServe.Repositories
{
    /// <summary>
    /// Store tokens in the database
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class TokenRepository : DbContext
    {
        public DbSet<Token> Tokens { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public TokenRepository(DbContextOptions<TokenRepository> options) : base(options) { }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>().HasIndex(b => b.UserId);
        }
    }
}