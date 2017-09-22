using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fretboard_Theory_Course.Models;

namespace Fretboard_Theory_Course.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<Foundations> Foundations { get; set; }
        public DbSet<UserFoundations> UserFoundations { get; set; }
        public DbSet<FoundationsImages> FoundationsImages { get; set; }
        public DbSet<Intermediate> Intermediate { get; set; }
        public DbSet<UserIntermediate> UserIntermediate { get; set; }
        public DbSet<IntermediateImages> IntermediateImages { get; set; }
        public DbSet<Advanced> Advanced { get; set; }
        public DbSet<UserAdvanced> UserAdvanced { get; set; }
        public DbSet<AdvancedImages> AdvancedImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<ResourcesImages> ResourcesImages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
