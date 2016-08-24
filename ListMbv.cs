using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netwerk.Models
{
    public class ListMbv
    {
        [Key]
        public int MbvId { get; set; }
        public string MbvValue { get; set; }
        public string Description { get; set; }
    }
}