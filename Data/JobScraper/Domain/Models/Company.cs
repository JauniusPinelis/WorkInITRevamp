using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Company : NamedEntity
    {
        public ICollection<JobUrl> Jobs { get; set; }

        [MaxLength]
        public string ImageData { get; set; }

        public string ImageExtension { get; set; }

        public string Logourl { get; set; }
    }
}
