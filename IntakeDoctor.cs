using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netwerk.Models
    {
    public class IntakeDoctor
        {
            public int IntakeDoctorId { get; set; }
            public string IntakeDoctorName { get; set; }
            public virtual Patient Patient { get; set; }
        }
    }