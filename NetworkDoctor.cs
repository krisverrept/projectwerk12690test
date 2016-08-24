using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netwerk.Models
    {
    public class NetworkDoctor
        {
            public int NetworkDoctorId { get; set; }
            public string NetworkDoctorName { get; set; }
            public virtual Patient Patient { get; set; }
        }
    }