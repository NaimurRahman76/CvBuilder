using BusinessObject.DataModel;
using Microsoft.EntityFrameworkCore;



namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<BasicInfo> BasicInfos { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CustomSection> CustomSections { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<Template> Templates { get; set; }  
        public DbSet<ProjelctView> Projects { get; set; }
    }
}
