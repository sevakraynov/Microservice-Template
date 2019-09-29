﻿using Calabonga.Microservice.IdentityModule.Data.Base;
using Calabonga.Microservice.IdentityModule.Models;
using Microsoft.EntityFrameworkCore;

namespace Calabonga.Microservice.IdentityModule.Data
{
    /// <summary>
    /// Database for application
    /// </summary>
    public class ApplicationDbContext : DbContextBase, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        #region System

        public DbSet<Log> Logs { get; set; }

        public DbSet<ApplicationUserProfile> Profiles { get; set; }

        #endregion
    }
}