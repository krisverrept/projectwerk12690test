using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netwerk.Models
    {
    public class MocType
        {
        public int MocTypeId { get; set; }
        public string MocName { get; set; }
        public string Description { get; set;  }
       
        }
    }