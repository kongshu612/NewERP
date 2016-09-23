namespace ERP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tab_Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tab_Customers()
        {
            Tab_CustomerContacts = new HashSet<Tab_CustomerContacts>();
            Tab_Orders = new HashSet<Tab_Orders>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(200)]
        public string CName { get; set; }

        [StringLength(200)]
        public string CAddress { get; set; }

        [StringLength(1000)]
        public string CDescription { get; set; }

        public long FK_CustomerCatalog { get; set; }

        public virtual Tab_CustomerCatalog Tab_CustomerCatalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_CustomerContacts> Tab_CustomerContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_Orders> Tab_Orders { get; set; }
    }
}
