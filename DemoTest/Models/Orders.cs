using System;
using System.Collections.Generic;

namespace DemoTest.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Datecreation { get; set; }
        public bool Status { get; set; }
        public string Payments { get; set; }
        public int? Customerid { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
