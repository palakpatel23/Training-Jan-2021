using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace student_admission_backend.Models
{

    public class EmergencyContact
    {
        public int EmergencyContactId { get; set; }
        public string Relation { get; set; }
        public long PhoneNo { get; set; }
        public int StudentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PersonalDetail Student { get; set; }
    }
}
