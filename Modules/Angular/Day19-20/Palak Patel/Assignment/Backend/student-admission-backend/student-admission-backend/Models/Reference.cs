using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace student_admission_backend.Models
{
    public class Reference
    {
        public int ReferenceId { get; set; }
        public string ReferenceThrough { get; set; }
        public string ReferenceAddress { get; set; }
        public int StudentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PersonalDetail Student { get; set; }
    }
}
