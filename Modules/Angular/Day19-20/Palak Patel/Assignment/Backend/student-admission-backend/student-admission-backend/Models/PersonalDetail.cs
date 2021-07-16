using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_admission_backend.Models
{
    public partial class PersonalDetail
    {
        public PersonalDetail()
        {
            emergencyContacts = new HashSet<EmergencyContact>();
            references = new HashSet<Reference>();
        }

        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentMiddleName { get; set; }
        public string StudentLastName { get; set; }
        public DateTime DOB { get; set; }
        public string BirthPlace { get; set; }
        public string Language { get; set; }

        public virtual Address address { get; set; }
        public virtual FatherDetail fatherDetails { get; set; }
        public virtual MotherDetail motherDetails { get; set; }
        public virtual ICollection<EmergencyContact> emergencyContacts { get; set; }
        public virtual ICollection<Reference> references { get; set; }
    }
}
