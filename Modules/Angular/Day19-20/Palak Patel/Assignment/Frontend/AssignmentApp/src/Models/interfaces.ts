export interface IStudent{
    studentId:number;
    Name : {
        FirstName : string;
        MiddleName : string;
        LastName : string;
    }
    DOB : Date;
    BirthPlace : string;
    FirstLanguage : string;
    Address : {
        City : string;
        State : string;
        Country : string;
        Pin : number;
    }
    Father : {
        Name : {
            FirstName : string;
            MiddleName : string;
            LastName : string;
        },
        Email : string;
        EducationQualification : string;
        Profession : string;
        Designation : string;
        Phone : number;
    }
    Mother : {
        Name : {
            FirstName : string;
            MiddleName : string;
            LastName : string;
        },
        Email : string;
        EducationQualification : string;
        Profession : string;
        Designation : string;
        Phone : number;
    }

    EmergencyContact : {
        Relation : string,
        Contact : number
    }[]
    ReferenceDetail : {
        RefThrough : string;
        RefAddress : string;
    }[]
}