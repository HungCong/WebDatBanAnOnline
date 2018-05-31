namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Order_Restaurant_Db : DbContext
    {
        public Order_Restaurant_Db()
            : base("name=Order_Restaurant_Db")
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Book_Food> Book_Food { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Main_Menu> Main_Menu { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<Banner>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Food>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<Food>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Main_Menu>()
                .Property(e => e.Link)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
