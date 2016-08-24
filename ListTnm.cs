using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netwerk.Models
{
    public class ListTnm
    {
        [Key]
        public int TnmId { get; set; }
        public string TnmValue { get; set;
        }
    }
}