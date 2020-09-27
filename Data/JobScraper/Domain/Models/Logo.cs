using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Logo : NamedEntity
    {
        public JobUrl JobUrl { get; set; }

        public int JobUrlId { get; set; }
    }
}
