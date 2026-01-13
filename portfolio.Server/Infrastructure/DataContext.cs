using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using portfolio.Server.Infrastructure.Models;
using PortfolioBackend.PortfolioBackend.Core.Models;

namespace PortfolioBackend.Infrastructure
{
    public sealed class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<Translation> Translations { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DbProject> Projects { get; set; }
        public DbSet<DbCompetency> Competencies { get; set; }
        public DbSet<Skill> Skills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DbProject
            modelBuilder.Entity<DbProject>()
                .Navigation(p => p.Competencies).AutoInclude();

            #endregion DbProject
                
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Translation>()
                .HasKey(t => new { t.Language, t.Key });
        }
    }
}
