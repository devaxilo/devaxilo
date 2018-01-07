namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{
    using System.Data.Entity;

    public class DevaxiloContext : DbContext
    {
        public DevaxiloContext()
            : base("name=DevaxiloConnectString")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountLogin> AccountLogin { get; set; }
        public virtual DbSet<KetQuaXoSoMienBac> KetQuaXoSoMienBacs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.NickName)
                .IsUnicode(false);
        }
    }
}
