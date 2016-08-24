using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Netwerk.Models
{
    public class ListHs
    {
        [Key]
        public int HsId { get; set; }
        public string HsCode { get; set; }
        public string HsValue { get; set; }
    }
}