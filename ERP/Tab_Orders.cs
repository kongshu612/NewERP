namespace ERP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tab_Orders
    {
        [Key]
        public long OrderID { get; set; }

        public long FK_Product { get; set; }

        public long FK_Customer { get; set; }

        public long FK_CustomerContact { get; set; }

        public long PricePer { get; set; }

        public long TotalCount { get; set; }

        public long TotalPrice { get; set; }

        public bool IsPayed { get; set; }
        [StringLength(100)]
        public string CreatedTime { get; set; }
        [StringLength(100)]
        public string SendTime { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string MailID { get; set; }

        public virtual Tab_CustomerContacts Tab_CustomerContacts { get; set; }

        public virtual Tab_Customers Tab_Customers { get; set; }

        public virtual Tab_Products Tab_Products { get; set; }
    }
}
