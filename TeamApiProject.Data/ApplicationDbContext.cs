using TeamApiProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TeamApiProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}
        public DbSet<RepliesEntity> Replies {get; set;} = null!;
        public DbSet<PostsEntity> Posts {get; set;} = null!;
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments {get; set;}
        public DbSet<LikeEntity> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<RepliesEntity>()
                .HasOne(n => n.Replies) 
                .WithMany(u => u.Replies)  
                .HasForeignKey(n => n.AuthorId)
                .HasForeignKey(n => n.ParentId);
        }
    }
}