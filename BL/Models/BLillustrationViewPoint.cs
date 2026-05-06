using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLillustrationViewPoint
    {
        public int IllustrationViewPointId { get; set; }

        public string Description { get; set; } = null!;

        public string Price { get; set; } = null!;

        public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
    }
}
