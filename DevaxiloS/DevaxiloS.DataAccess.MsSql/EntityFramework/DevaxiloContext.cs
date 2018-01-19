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
        public virtual DbSet<AccountBalance> AccountBalances { get; set; }
        public virtual DbSet<AccountLogin> AccountLogin { get; set; }
        public virtual DbSet<KetQuaXoSoMienBac> KetQuaXoSoMienBacs { get; set; }
        public virtual DbSet<ManageWalletInfo> ManageWalletInfos { get; set; }

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

            modelBuilder.Entity<AccountBalance>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountBalance>()
                .Property(e => e.HoldBalance)
                .HasPrecision(19, 4);
        }
    }
}
