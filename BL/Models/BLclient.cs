using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLclient
    {
        public string CompNameCustName { get; set; } = null!;

        public string Mail { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int CustomerType { get; set; }

        public string? ConnectPerson { get; set; }

        //public int OrderNum { get; set; }
        public int CustomersId { get; set; }

        //public virtual CustemerType CustomerTypeNavigation { get; set; } = null!;

        //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
   


}
}
