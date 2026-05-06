using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLproject
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public DateTime? FinalDate { get; set; }
        public string CompName { get; set; }
        public int? PackageId { get; set; }
    }
}
