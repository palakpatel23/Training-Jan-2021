using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace student_admission_backend.Models
{
    public class MotherDetail
    {
        public int MotherId { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherEmail { get; set; }
        public string MotherEQ { get; set; }
        //EQ=Education Qualification
        public string MotherProfession { get; set; }
        public string MotherDesignation { get; set; }
        public long MotherPhone { get; set; }
        public int StudentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PersonalDetail Student { get; set; }
    }
}
