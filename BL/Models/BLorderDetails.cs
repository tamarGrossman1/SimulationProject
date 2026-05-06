using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLorderDetails
    {
        public int OrderDetailsId { get; set; }

        public int OrderId { get; set; }

        public int DealId { get; set; }

        public DateTime OrderFinishDate { get; set; }
        
        public string? Status { get; set; }

        public virtual Deal Deal { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;
    }
}
