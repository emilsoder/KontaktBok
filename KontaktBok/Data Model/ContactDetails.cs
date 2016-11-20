namespace KontaktBok.Data_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactID { get; set; }

        public int ContactDetailsID { get; set; }

        [StringLength(30)]
        public string PhonePrivate { get; set; }

        [StringLength(30)]
        public string HomePhone { get; set; }

        [StringLength(30)]
        public string WorkPhone { get; set; }

        [StringLength(30)]
        public string HomeAddress { get; set; }

        [StringLength(30)]
        public string WorkAddress { get; set; }

        [StringLength(30)]
        public string OtherAddress { get; set; }

        public virtual ContactName ContactName { get; set; }
    }
}
