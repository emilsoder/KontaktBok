namespace KontaktBok.Data_Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContactDBDataModel : DbContext
    {
        public ContactDBDataModel()
            : base("name=ContactDBDataModel")
        {
        }

        public virtual DbSet<ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<ContactName> ContactName { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactName>()
                .HasMany(e => e.ContactDetails)
                .WithRequired(e => e.ContactName)
                .HasForeignKey(e => e.ContactDetailsID)
                .WillCascadeOnDelete(false);
        }
    }
}
