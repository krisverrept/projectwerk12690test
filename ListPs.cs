using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netwerk.Models
{
    public class ListPs  // Site of primary
    {
        [Key]
        public int PsId { get; set; }
        public string PsValue { get; set; }
    }

}