using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLrecommend
    {
        public int RecommendId { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int DealId { get; set; }
        public string DealName { get; set; }

        public string RecDescription { get; set; } = null!;

        public virtual Deal Deal { get; set; } = null!;
    }
}
