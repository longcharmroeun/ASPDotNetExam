using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPDotNetExam.DataBase
{
    public partial class userContext : DbContext
    {
        public userContext()
        {
        }

        public userContext(DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<UserItem> UserItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Itemtype> Itemtypes { get; set; }
        public virtual DbSet<ItemDate> ItemDates { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Promo> Promos { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;Database=user;user=root;passworld=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserItem>().HasKey(UserItem => new { UserItem.ItemID, UserItem.UserID });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
