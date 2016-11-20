namespace KontaktBok.DataLayer2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContactBookDBDModel : DbContext
    {
        public ContactBookDBDModel()
            : base("name=ContactBookDBDModel")
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.WorkPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.HomeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Contacts>()
                .Property(e => e.OtherAddress)
                .IsUnicode(false);
        }
    }
}
