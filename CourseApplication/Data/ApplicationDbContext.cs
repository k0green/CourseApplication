using CourseApplication.Data.Entities;
using CourseApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemTag> ItemTag { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<UserCollection> UserCollection { get; set; }
        public DbSet<UserItemComment> UserItemComment { get; set; }
        public DbSet<UserItemLike> UserItemLike { get; set; }
        public DbSet<CustomField> CustomField { get; set; }
        public DbSet<Entities.ValueType> ValueType { get; set; }
        public DbSet<CustomFieldsValues> CustomFieldsValues { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCollection>()
                .HasKey(bc => new { bc.UserId, bc.CollectionId });
            modelBuilder.Entity<UserCollection>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserCollections)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserCollection>()
                .HasOne(bc => bc.Collection)
                .WithMany(c => c.UserCollections)
                .HasForeignKey(bc => bc.CollectionId);

            modelBuilder.Entity<ItemTag>()
                .HasKey(bc => new { bc.ItemId, bc.TagId });
            modelBuilder.Entity<ItemTag>()
                .HasOne(bc => bc.Item)
                .WithMany(b => b.ItemTags)
                .HasForeignKey(bc => bc.ItemId);
            modelBuilder.Entity<ItemTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.ItemTags)
                .HasForeignKey(bc => bc.TagId);

            modelBuilder.Entity<UserItemLike>()
                .HasKey(bc => new { bc.ItemId, bc.UserId });
            modelBuilder.Entity<UserItemLike>()
                .HasOne(bc => bc.Item)
                .WithMany(b => b.UserItemLikes)
                .HasForeignKey(bc => bc.ItemId);
            modelBuilder.Entity<UserItemLike>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserItemLikes)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserItemComment>()
                .HasKey(bc => new { bc.ItemId, bc.UserId });
            modelBuilder.Entity<UserItemComment>()
                .HasOne(bc => bc.Item)
                .WithMany(b => b.UserItemComments)
                .HasForeignKey(bc => bc.ItemId);
            modelBuilder.Entity<UserItemComment>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserItemComments)
                .HasForeignKey(bc => bc.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}