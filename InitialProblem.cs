using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netwerk.Models
    {
    public class InitialProblem
        {
        public int InitialProblemId { get; set; }
        public string InitialProblemName { get; set; }
        public virtual Patient Patient { get; set; }
        }
    }