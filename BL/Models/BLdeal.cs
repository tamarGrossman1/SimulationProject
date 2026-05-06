using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLdeal
    {
        public int DealId { get; set; }

       public int ViewPointId { get; set; }

        public string DealDescription { get; set; } = null!;

       // public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

       // public virtual ICollection<Recommend> Recommends { get; set; } = new List<Recommend>();

      //  public virtual IllustrationViewPoint ViewPoint { get; set; } = null!;
    }
}
