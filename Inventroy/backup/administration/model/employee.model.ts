export class Employee {
    public id: number;
    public employeeNo: string;
    public organizationId: number;
    public shopId: number;
    public isOwner: number;
    public name: string;
    public firstName: string;
    public lastName: string;
    public designation: number;
    public mobile: string;
    public residanceMobileNo: string;
    public phone: string;
    public email: string;
    public joiningDate: Date;
    public terminationDate: Date;
    public salaryTypeId: number;
    public status: number;
}
export class EmployeeDetails extends Employee {
    public createdBy: number;
    public createdDate: string;
    public modifiedBy: string;
    public modifiedDate: string;
}
export class EmployeeBasicInfo {
    public id: number;
    public employeeId: number;
    public fathersName: string;
    public fathersProfession: number;
    public mothersName: string;
    public mothersProfession: number;
    public dateOfBirth: Date;
    public religionId: number;
    public nationalityId: number;
    public citizenShipStatusId: number;
    public countryOfBirthId: number;
    public distictOfBirthId: number;
    public genderId: number;
    public birthRegNo: string;
    public nationalIdno: string;
    public passportNo: string;
    public hight: number;
    public bloodGroupId: number;
    public Status: number;

    // public long Id { get; set; }
    // public long? EmployeeId { get; set; }
    // public string FathersName { get; set; }
    // public byte? FathersProfession { get; set; }
    // public string MothersName { get; set; }
    // public byte? MothersProfession { get; set; }
    // public DateTime? DateOfBirth { get; set; }
    // public byte? ReligionId { get; set; }
    // public int? NationalityId { get; set; }
    // public byte? CitizenShipStatusId { get; set; }
    // public int? CountryOfBirthId { get; set; }
    // public int? DistictOfBirthId { get; set; }
    // public byte? GenderId { get; set; }
    // public string BirthRegNo { get; set; }
    // public string NationalIdno { get; set; }
    // public string PassportNo { get; set; }
    // public int? Hight { get; set; }
    // public byte? BloodGroupId { get; set; }
    // public string CreatedBy { get; set; }
    // public DateTime? CreatedDate { get; set; }
    // public string  UpdatedBy { get; set; }
    // public DateTime? UpdatedDate { get; set; }
    // public byte? Status { get; set; }
}
export class EmployeeAddress {
    public id: number;
    public employeeId: number;
    public presentVillageHouse: string;
    public presentRoadBlockSector: string;
    public presentPostOffice: number;
    public presentPostCode: string;
    public presentUpazila: number;
    public presentDistrict: number;
    public permanentVillageHouse: string;
    public permanentRoadBlockSector: string;
    public permanentPostOffice: number;
    public permanentPostCode: string;
    public permanentUpazila: number;
    public permanentDistrict: number;
}
export class EmployeeEducationQual {
    public id: number;
    public employeeId: number;
    public registrationNo: string;
    public rollNo: string;
    public boardorUniversity: number;
    public classTypeId: number;
    public subjectId: number;
    public passingYear: Date;
    public result: number;
    public resultCgpa: string;
    // public createdBy: number;
    // public createdDate: Date;
    // public updatedBy: number;
    // public updatedDate: Date;
    //  public status: number;
}
export class CreateEduQual {
    public employeeEduQualViewModels: Array<EmployeeEducationQual>;
}
export class EmployeeRefPersonDetails {
    public id: number;
    public employeeId: number;
    public reletionShipId: number;
    public refPersonName: string;
    public professionId: number;
    public mobileNo: string;
    public email: string;
    public countryId: number;
    public distictId: number;
    public policeStationId: number;
    public postOffice: number;
    public postCode: string;
    public roadBlockSector: string;
    public houseVillage: string;
    public status: number;
}
export class EmployeeRefPersonDetailsViewModel {
    public empRefPersonCreateUpdateViewModels: Array<EmployeeRefPersonDetails>;
}
export class EmployeeDocument {
    public id: number;
    public employeeId: number;
    public documentName: string;
    public fileName: string;
    public file: string;
    public documentUrl: string;
    public status: number;
}
export class CreateUpdateEmpDocument {
    public employeeDocumentViewModels: Array<EmployeeDocument>;
}
