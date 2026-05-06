using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBl
    {
        public IblClient Client { get; }
        public IblCustomerType CustomerType { get; }
        public Ibldeal Deal { get; }
        public IblIllustrationViewPoint IblIllustrationViewPoint { get; }
        public IblOrder IblOrder { get; }
        public IblOrderDetails IblOrderDetails { get; } 
        public IblRecommend IblRecommend { get; }
        public IblProject IblProject { get; }

        
    }
}
