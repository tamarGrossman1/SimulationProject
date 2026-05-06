using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Appi
{
    public interface Idal
    {
        public Iclient client { get; }
        public IcustomerType customerType { get; }
        public Iorder order { get; }
        public Irecommends Recommend { get; }
        //public IorderDetails orderDetails { get; }
        public Ideal deal { get; }
        public IillustrationViewPoint illustrationViewPoint { get; }
        public Iproject project { get; }
    }
}
