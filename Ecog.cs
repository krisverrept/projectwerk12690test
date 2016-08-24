using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netwerk.Models
    {
    public class Ecog
        {
        [Key]
        public int EcId { get; set; }
        public string EcGrade { get; set; }
        public virtual Patient Patient { get; set; }
        }
    }