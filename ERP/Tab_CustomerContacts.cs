namespace ERP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tab_CustomerContacts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tab_CustomerContacts()
        {
            Tab_Orders = new HashSet<Tab_Orders>();
        }

        [Key]
        public long ContactID { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactName { get; set; }

        [StringLength(50)]
        public string ContactTelphone { get; set; }

        public long FK_Customer_ID { get; set; }

        [StringLength(1000)]
        public string ContactDescription { get; set; }

        public long FK_Credit { get; set; }

        public virtual Tab_Credit Tab_Credit { get; set; }

        public virtual Tab_Customers Tab_Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_Orders> Tab_Orders { get; set; }
    }
}
