using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace student_admission_backend.Models
{
    public class FatherDetail
    {
        public int fatherId { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherEmail { get; set; }
        public string FatherEQ { get; set; }
        //EQ=Education Qualification
        public string FatherProfession { get; set; }
        public string FatherDesignation { get; set; }
        public long FatherPhone { get; set; }
        public int StudentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PersonalDetail Student { get; set; }
    }
}
