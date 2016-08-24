using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netwerk.Models
{
    public class ListFs  // functional syndrome
    {
        [Key]
        public int FsId { get; set; }
        public string FsValue { get; set; }
    }
}