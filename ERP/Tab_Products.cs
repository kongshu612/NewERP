namespace ERP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tab_Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tab_Products()
        {
            Tab_Orders = new HashSet<Tab_Orders>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int ProductSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_Orders> Tab_Orders { get; set; }
    }
}
