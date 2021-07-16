using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace student_admission_backend.Models
{
    public class Address
    {
        public int addressId { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int pincode { get; set; }
        public int StudentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PersonalDetail Student { get; set; }
    }
}
