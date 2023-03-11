using System.Reflection;
using System.Reflection.Emit;
using CMSPlus.Domain.Configurations;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.TopicModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CMSPlus.Domain.Persistance;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TopicEntityConfiguration());
        base.OnModelCreating(builder);

        builder.Entity<CommentModel>()
          .HasOne(c => c.Topic)
          .WithMany(t => t.Comments)
          .HasForeignKey(c => c.IdTopic);
    }
}