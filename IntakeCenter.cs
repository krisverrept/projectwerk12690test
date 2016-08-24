using System.ComponentModel.DataAnnotations;

namespace Netwerk.Models
    {
    public class IntakeCenter
        {
        [Key]
        [ScaffoldColumn(false)]
        public int IntakeCenterId { get; set; }
        public string IntakeCenterName { get; set; }
        public virtual Patient Patient { get; set; }
        }
    }