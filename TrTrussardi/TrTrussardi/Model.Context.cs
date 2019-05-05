

namespace TrTrussardi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrTrussardiEntities : DbContext
    {
        public TrTrussardiEntities()
            : base("name=TrTrussardiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CanceledDishes> CanceledDishes { get; set; }
        public virtual DbSet<CanceledOrders> CanceledOrders { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Compositions> Compositions { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<OrderedDishes> OrderedDishes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
