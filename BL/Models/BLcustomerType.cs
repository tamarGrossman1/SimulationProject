using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLcustomerType
    {
        public int CustomerTypeId { get; set; }

        public string? CustomerType { get; set; } = null;

        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
