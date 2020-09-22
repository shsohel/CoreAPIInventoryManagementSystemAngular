import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { CommonService } from 'src/app/common/services/common.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { Employee, EmployeeBasicInfo, EmployeeAddress, EmployeeRefPersonDetails, EmployeeEducationQual, EmployeeDocument, CreateEduQual, EmployeeRefPersonDetailsViewModel, CreateUpdateEmpDocument } from 'src/app/administration/model/employee.model';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { DataService } from 'src/app/common/services/data.service';
import { Route } from '@angular/compiler/src/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppHost } from 'src/app/common/models/app-host.model';
import { YesOrNo } from 'src/app/administration/enums/yesorno.enum';
import { EmployeeSalaryType } from 'src/app/administration/enums/employee-status-code.enum';
import { EmployeeService } from 'src/app/administration/services/employee.service';
import { EmployeeBasicInfoService } from 'src/app/administration/services/employee-basic-info.service';
import { CitizenshipStatus, Religion, Gender, BloodGroup, Result, RelationshipEnum, BoardOrUniversity, SubjectorGroupEnum, ClassType } from 'src/app/common/enums/common-basic.enum';
import { EmployeeAddressService } from 'src/app/administration/services/employee-address.service';
import { EmployeeEduQualService } from 'src/app/administration/services/employee-edu-qual.service';
import { EmployeeRefPersonService } from 'src/app/administration/services/employee-ref-person.service';
import { EmployeeDocumentService } from 'src/app/administration/services/employee-document.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  createEduQual: CreateEduQual = new CreateEduQual();
  createRefPerson: EmployeeRefPersonDetailsViewModel = new EmployeeRefPersonDetailsViewModel();
  createEmDoc: CreateUpdateEmpDocument = new CreateUpdateEmpDocument();
  appHost: AppHost = new AppHost();
  response: ResponseMessage = new ResponseMessage();
  employee: Employee = new Employee();
  employeeBasicInfo: EmployeeBasicInfo = new EmployeeBasicInfo();
  employeeAddress: EmployeeAddress = new EmployeeAddress();
  employeeDocument: EmployeeDocument;
  employeeDocumentArray: EmployeeDocument[] = [];
  employeeRefPersonDetails: EmployeeRefPersonDetails[] = [];
  employeeEduQual: EmployeeEducationQual[] = [];
  reset: any = [{}];
  isLinear = false;
  isTeacher: boolean = false;
  // citizenshipStatus = CitizenshipStatus;
  // religion = Religion;
  // gender = Gender;
  // bloodGroup = BloodGroup;
  // result = Result;
  // relationshipEnum = RelationshipEnum;
  keysOfcitizenshipStatus: any = new Object();
  citizenshipStatus = CitizenshipStatus;
  religion = Religion;
  gender = Gender;
  bloodGroup = BloodGroup;
  classType = ClassType;
  result = Result;
  boardorUniversity = BoardOrUniversity;
  subjectOrGroup = SubjectorGroupEnum;
  relationshipEnum = RelationshipEnum;
  employeeFirstForm: FormGroup;
  employeeSecondForm: FormGroup;
  employeeBasicInfoForm: FormGroup;
  employeeAddressForm: FormGroup;
  employeeQualAndRefDetailsForm: FormGroup;
  employeeReferenceDetailsForm: FormGroup;
  // employeeType = EmployeeType;
  employeeSalaryType = EmployeeSalaryType;
  yesOrNo = YesOrNo;
  keyofBoardUniversity: any = new Object();
  keyOfYesNo: any = new Object();
  keysOfEmployeeType: any = new Object();
  keysOfReligion: any = new Object();
  keysOfEmployeeSalaryType: any = new Object();
  keysOfGender: any = new Object();
  keysOfBloodGroup: any = new Object();
  keysOfResult: any = new Object();
  keyofClass: any = new Object();
  keysofSubjectOrGroup: any = new Object();
  keysOfelationshipEnum: any = new Object();
  commonDataList: CommonDataList = new CommonDataList();
  employeeId: number;
  constructor(private _formBuilder: FormBuilder, private commonService: CommonService, private dataService: DataService, private router: Router,
    private employeeService: EmployeeService, private employeeBasicInfoService: EmployeeBasicInfoService, private employeeAddressService: EmployeeAddressService,
    private employeeEduQualService: EmployeeEduQualService, private activatedRoute: ActivatedRoute, private employeeReferenceService: EmployeeRefPersonService,
    private employeeDocumentService: EmployeeDocumentService, private matSnakBar: MatSnackBar) {
    this.keyOfYesNo = Object.keys(this.yesOrNo).filter(Boolean);
    this.keysOfEmployeeSalaryType = Object.keys(this.employeeSalaryType).filter(Number);
    this.keysOfcitizenshipStatus = Object.keys(this.citizenshipStatus).filter(Number);
    this.keysOfReligion = Object.keys(this.religion).filter(Number);
    this.keysOfGender = Object.keys(this.gender).filter(Number);
    this.keysOfBloodGroup = Object.keys(this.bloodGroup).filter(Number);
    this.keysOfResult = Object.keys(this.result).filter(Number);
    this.keyofBoardUniversity = Object.keys(this.boardorUniversity).filter(Number);
    this.keysOfelationshipEnum = Object.keys(this.relationshipEnum).filter(Number);
    this.keysofSubjectOrGroup = Object.keys(this.subjectOrGroup).filter(Number);
    this.keyofClass = Object.keys(this.classType).filter(Number);
    this.employeeFirstForm = this._formBuilder.group({
      id: [''],
      // employeeNo: ['', Validators.required],
      // organizationId: ['', Validators.required],
      // shopId: ['', Validators.required],
      isOwner: ['', Validators.required],
      // name: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      designation: ['', Validators.required],
      mobile: ['', Validators.required],
      residanceMobileNo: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', Validators.required],
      joiningDate: ['', Validators.required],
      terminationDate: [''],
      salaryTypeId: ['', Validators.required]
    });
    this.employeeBasicInfoForm = this._formBuilder.group({
      id: '',
      employeeId: '',
      fathersName: ['', Validators.required],
      fathersProfession: ['', Validators.required],
      mothersName: ['', Validators.required],
      mothersProfession: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      religionId: ['', Validators.required],
      nationalityId: ['', Validators.required],
      citizenShipStatusId: ['', Validators.required],
      countryOfBirthId: ['', Validators.required],
      distictOfBirthId: ['', Validators.required],
      genderId: ['', Validators.required],
      birthRegNo: ['', Validators.required],
      nationalIdno: ['', Validators.required],
      passportNo: ['', Validators.required],
      hight: ['', Validators.required],
      bloodGroupId: ['', Validators.required]
    });
    this.employeeAddressForm = this._formBuilder.group({
      id: [''],
      employeeId: [''],
      presentVillageHouse: ['', Validators.required],
      presentRoadBlockSector: ['', Validators.required],
      presentPostOffice: ['', Validators.required],
      presentPostCode: ['', Validators.required],
      presentUpazila: ['', Validators.required],
      presentDistrict: ['', Validators.required],
      permanentVillageHouse: ['', Validators.required],
      permanentRoadBlockSector: ['', Validators.required],
      permanentPostOffice: ['', Validators.required],
      permanentPostCode: ['', Validators.required],
      permanentUpazila: ['', Validators.required],
      permanentDistrict: ['', Validators.required],
    });
    this.employeeQualAndRefDetailsForm = this._formBuilder.group({
      educationQualification: this._formBuilder.array([
        this.addEducationQualificationForm()
      ]),
    });
    this.employeeReferenceDetailsForm = this._formBuilder.group({
      employeeReferences: this._formBuilder.array([
        this.addEducationReferencesForm()
      ]),
    })
  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(param => {
      this.employeeId = + param.get('id');
      if (this.employeeId > 0) {
        this.employeeService.getById(this.employeeId).subscribe((res: any) => {
          this.employee = <Employee>res.obj;
          this.employeeFirstForm.patchValue(this.employee);
        })
      }
    })
    this.commonService.get().subscribe((res: any) => {
      this.commonDataList = <CommonDataList>res.obj;
      console.log(this.commonDataList);
    })
  }
  addEducationQualificationForm(): FormGroup {
    return this._formBuilder.group({
      id: '',
      // organizationId: '',
      // campusId: '',
      employeeId: [''],
      // examId: ['', Validators.required],
      classTypeId: ['', Validators.required],
      registrationNo: ['', Validators.required],
      rollNo: ['', Validators.required],
      boardorUniversity: ['', Validators.required],
      subjectId: ['', Validators.required],
      passingYear: ['', Validators.required],
      result: ['', Validators.required],
      resultCgpa: ['']
    })
  }
  addEducationReferencesForm(): FormGroup {
    return this._formBuilder.group({
      id: '',
      employeeId: ['1'],
      reletionShipId: ['', Validators.required],
      refPersonName: ['', Validators.required],
      professionId: ['', Validators.required],
      mobileNo: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      countryId: ['', Validators.required],
      distictId: ['', Validators.required],
      policeStationId: ['', Validators.required],
      postOffice: ['', Validators.required],
      postCode: ['', Validators.required],
      roadBlockSector: ['', Validators.required],
      houseVillage: ['', Validators.required]
    })
  }
  onAddMoreEducation() {
    (<FormArray>this.employeeQualAndRefDetailsForm.get('educationQualification')).push(this.addEducationQualificationForm());
  }
  onRemoveEduQulification(index: number) {
    (<FormArray>this.employeeQualAndRefDetailsForm.get('educationQualification')).removeAt(index);
  }
  onAddMoreReference() {
    (<FormArray>this.employeeReferenceDetailsForm.get('employeeReferences')).push(this.addEducationReferencesForm());
  }
  onRemoveReference(index: number) {
    (<FormArray>this.employeeReferenceDetailsForm.get('employeeReferences')).removeAt(index);
  }
  onEmployeeSave() {
    this.employeeFirstForm.markAsTouched();
    if (this.employeeFirstForm.valid) {
      console.log(this.employeeFirstForm.valid)
      this.employeeFirstForm.controls['id'].setValue(this.employee.id);
      if (this.employee.id > 0) {
        this.employeeService.put(this.employeeFirstForm.value).subscribe((res: any) => {
          this.employee = <Employee>res.obj;
          this.assignCommonData();
          this.assignDataToBasicInfoForm(this.employee.id);
        });
      }
      else {
        this.employeeService.post(this.employeeFirstForm.value).subscribe((res: any) => {
          this.employee = <Employee>res.obj;
          this.assignCommonData();
        });
      }
    }
  }
  assignDataToBasicInfoForm(id: number) {
    console.log(id)
    if (id > 0) {
      this.employeeBasicInfoService.getById(id).subscribe((res: any) => {
        if (res.obj != null) {
          this.employeeBasicInfo = <EmployeeBasicInfo>res.obj;
          this.employeeBasicInfoForm.patchValue(this.employeeBasicInfo);
        }
      })
    }
  }
  onBasicInfoSave() {
    console.log(this.employeeBasicInfoForm.value);
    this.employeeBasicInfoForm.markAsTouched();
    if (this.employeeBasicInfoForm.valid) {
      if (this.employeeBasicInfo.id > 0) {
        this.employeeBasicInfoService.put(this.employeeBasicInfoForm.value).subscribe((res: any) => {
          //response work goes here
          this.employeeBasicInfo = <EmployeeBasicInfo>res.obj;
          this.assignDataToEmployeeAddressForm(this.employee.id);
        });
      }
      else {
        this.employeeBasicInfoService.post(this.employeeBasicInfoForm.value).subscribe((res: any) => {
          //response work goes here
          this.employeeBasicInfo = <EmployeeBasicInfo>res.obj;
        });
      }
    }
  }
  assignDataToEmployeeAddressForm(id: number) {
    console.log("EmpId: " + id)
    if (id > 0) {
      this.employeeAddressService.getById(id).subscribe((res: any) => {
        if (res.obj != null) {
          this.employeeAddress = <EmployeeAddress>res.obj;
          this.lstOfPresentUpazilas = this.commonDataList.lstUpazilas.filter(e => e.districtId == this.employeeAddress.presentDistrict);
          this.lstOfPermanentUpazilas = this.commonDataList.lstUpazilas.filter(e => e.districtId == this.employeeAddress.permanentDistrict);
          this.employeeAddressForm.patchValue(this.employeeAddress);
          console.log(this.employeeAddress)
        }
      })
    }
  }
  onAddressSave() {
    if (this.employeeAddressForm.valid) {
      if (this.employeeAddress.id > 0) {
        this.employeeAddressService.put(this.employeeAddressForm.value).subscribe((res: any) => {
          this.employeeAddress = <EmployeeAddress>res.obj;
          this.assignDataToEmployeeEduQualForm(this.employee.id);
        })
      }
      else {
        this.employeeAddressService.post(this.employeeAddressForm.value).subscribe((res: any) => {
          this.employeeAddress = <EmployeeAddress>res.obj;
        })
      }
    }
  }
  assignDataToEmployeeEduQualForm(id: number) {
    if (id > 0) {
      let eduQulaFormArray = <FormArray>this.employeeQualAndRefDetailsForm.get('educationQualification');
      this.createEduQual.employeeEduQualViewModels = eduQulaFormArray.value;
      this.employeeEduQualService.getById(id).subscribe((res: any) => {
        this.employeeEduQual = <EmployeeEducationQual[]>res.obj;
        console.log(this.employeeEduQual);
        if (this.employeeEduQual.length > 0) {
          console.log(this.employeeEduQual);
          if (eduQulaFormArray.length < this.employeeEduQual.length) {
            for (let i = 1; i < this.employeeEduQual.length; i++) {
              this.onAddMoreEducation();
            }
          }
          eduQulaFormArray.patchValue(this.employeeEduQual);
        }
      });
    }
  }
  onEducationQualificationSave() {
    let eduQulaFormArray = <FormArray>this.employeeQualAndRefDetailsForm.get('educationQualification');
    if (eduQulaFormArray.valid) {
      for (let i = 0; i < eduQulaFormArray.length; i++) {
        eduQulaFormArray.at(i).get('employeeId').setValue(this.employee.id);
        console.log(this.employee.id);
        this.createEduQual.employeeEduQualViewModels = eduQulaFormArray.value;
      }
      if (eduQulaFormArray.at(0).get('id').value > 0) {
        this.employeeEduQualService.put(this.createEduQual).subscribe((res: any) => {
          console.log(res.obj);
          this.employeeEduQual = <EmployeeEducationQual[]>res.obj;
          this.assignDataToReferenceDetailsForm(this.employee.id);
        });
      }
      else {
        this.employeeEduQualService.post(this.createEduQual).subscribe((res: any) => {
          console.log(res.obj);
          this.employeeEduQual = <EmployeeEducationQual[]>res.obj;
        });
      }
    }
  }
  assignDataToReferenceDetailsForm(id: number) {
    console.log("Iam :" + id);
    let empRefFormArray = <FormArray>this.employeeReferenceDetailsForm.get('employeeReferences');
    this.createRefPerson.empRefPersonCreateUpdateViewModels = empRefFormArray.value;
    if (id > 0) {
      this.employeeReferenceService.getById(id).subscribe((res: any) => {
        if (res.obj != null) {
          this.employeeRefPersonDetails = <EmployeeRefPersonDetails[]>res.obj;
          console.log(this.employeeRefPersonDetails);
          if (empRefFormArray.length < this.employeeRefPersonDetails.length) {
            for (let i = 1; i < this.employeeRefPersonDetails.length; i++) {
              this.onAddMoreReference();
            }
          }
          empRefFormArray.patchValue(this.employeeRefPersonDetails);
        }
      })
    }
  }
  onReferecesPersonSave() {
    let empRefFormArray = <FormArray>this.employeeReferenceDetailsForm.get('employeeReferences');
    console.log(empRefFormArray.valid)
    console.log(empRefFormArray.value)
    if (empRefFormArray.valid) {
      for (let i = 0; i < empRefFormArray.length; i++) {
        empRefFormArray.at(i).get('employeeId').setValue(this.employee.id);
    this.createRefPerson.empRefPersonCreateUpdateViewModels = empRefFormArray.value;
      }
      if (empRefFormArray.at(0).get('id').value > 0) {
        this.employeeReferenceService.put(this.createRefPerson).subscribe((res: any) => {
          console.log(res.obj);
          this.employeeRefPersonDetails = <EmployeeRefPersonDetails[]>res.obj;
          this.assignDataToDocumentForm(this.employee.id);
        });
      }
      else {
        this.employeeReferenceService.post(this.createRefPerson).subscribe((res: any) => {
          console.log(res.obj);
          this.employeeRefPersonDetails = <EmployeeRefPersonDetails[]>res.obj;
        });
      }
    }
  }
  assignDataToDocumentForm(id: number) {
    if (id > 0) {
      this.employeeDocumentService.getById(id).subscribe((res: any) => {
        if (res.obj != null) {
          this.employeeDocumentArray = <EmployeeDocument[]>res.obj;
          if(this.employeeDocumentArray.length > 0){
            this.assignPictureProperty();
          }
          console.log(this.employeeDocumentArray)
        };
      });
    }
  }
  onDocumentSave() {
   // let data = JSON.stringify(this.employeeDocumentArray);
   this.createEmDoc.employeeDocumentViewModels=this.employeeDocumentArray;
   console.log("hello")
    if (this.employeeDocumentArray[0].id > 0) {
      this.employeeDocumentService.put(this.createEmDoc).subscribe((res: any) => {
        this.workWithResponse(res);
      });
    }
    else {
      this.employeeDocumentService.post(this.createEmDoc).subscribe((res: any) => {
        this.workWithResponse(res);
      });
    }
  }
  assignCommonData() {
    this.employeeBasicInfoForm.controls['employeeId'].setValue(this.employee.id);
    this.employeeAddressForm.controls['employeeId'].setValue(this.employee.id);
    //this.addEducationQualificationForm.bind['employeeId'].setValue(this.employee.id);
  }
  getupazila(id: number) {
    if (id > 0) {
      return this.commonDataList.lstUpazilas.filter(e => e.districtId == id);
    }
  }
  getPostCode(idd: number, index: number) {
    let postCode;
    console.log(idd);
    if (idd > 0 && idd !=undefined ) {
      this.commonDataList.lstPostOffices.filter(e => {
        if (e.id == idd) {
          postCode = e.postCode;
          (<FormArray>this.employeeReferenceDetailsForm.get('employeeReferences')).at(index).get('postCode').setValue(e.postCode);
        }
      })
      return postCode;

    }
    return "";
  }
  onPostOfficeChange(event) {
    this.commonDataList.lstPostOffices.filter(e => {
      if (e.id == event.target.value &&e.id !=undefined) {
        this.employeeReferenceDetailsForm.controls['postCode'].setValue(e.postCode);
      }
    })
  }
  lstOfPresentUpazilas;
  lstOfPermanentUpazilas;
  onPresentDistrictChange(id) {
    if (this.commonDataList.lstUpazilas != null) {
      this.lstOfPresentUpazilas = this.commonDataList.lstUpazilas.filter(e => e.districtId == id);
    }
  }
  onPermanentDistrictChange(id) {
    if (this.commonDataList.lstUpazilas != null) {
      this.lstOfPermanentUpazilas = this.commonDataList.lstUpazilas.filter(e => e.districtId == id);
    }
  }
  onPresentPostOfficeChange(event) {
    this.commonDataList.lstPostOffices.filter(e => {
      if (e.id == event.target.value) {
        this.employeeAddressForm.controls['presentPostCode'].setValue(e.postCode);
      }
    })
  }
  onPermanentPostOfficeChange(event) {
    this.commonDataList.lstPostOffices.filter(e => {
      if (e.id == event.target.value) {
        this.employeeAddressForm.controls['permanentPostCode'].setValue(e.postCode);
      }
    })
  }
  onCheckClick(event) {
    if (event.checked) {
      this.assignValueToPermanentAddress();
    }
  }
  assignValueToPermanentAddress() {
    this.onPermanentDistrictChange(this.employeeAddressForm.get('presentDistrict').value);
    this.employeeAddressForm.get('permanentVillageHouse').setValue(this.employeeAddressForm.get('presentVillageHouse').value);
    this.employeeAddressForm.get('permanentRoadBlockSector').setValue(this.employeeAddressForm.get('presentRoadBlockSector').value);
    console.log(this.employeeAddressForm.get('presentPostOffice').value);
    this.employeeAddressForm.controls['permanentPostOffice'].setValue(this.employeeAddressForm.get('presentPostOffice').value);
    this.employeeAddressForm.get('permanentPostCode').setValue(this.employeeAddressForm.get('presentPostCode').value);
    this.employeeAddressForm.get('permanentUpazila').setValue(this.employeeAddressForm.get('presentUpazila').value);
    this.employeeAddressForm.controls['permanentDistrict'].setValue(this.employeeAddressForm.get('presentDistrict').value);
  }
  assignPictureProperty() {
    console.log(this.employeeDocumentArray)
    let url = this.appHost.hostName + "images/EmployeesImages/";
    this.employeeDocumentArray.filter(e => {
      if (e.documentName == "Photo") {
        this.profileImage = url + e.fileName;
      }
      else if (e.documentName == "NID") {
        this.nIDImage = url + e.fileName;
      }
      else if (e.documentName == "Passport") {
        this.passportImage = url + e.fileName;
      }
      else if (e.documentName == "Birth Certificate") {
        this.bithCirtificateImage = url + e.fileName;
      }
    })
    console.log(this.profileImage)
  }
  onCardClick(id: string) {
    console.log(document.getElementById(id));
    (<HTMLElement>document.getElementById(id)).click();
  }
  profileImage;
  onProfileImageChange(event, inputId: string, messageId: string, imgId: string) {
    if (event.target.files.length > 0) {
      (<HTMLElement>document.getElementById(messageId)).style.display = 'none';
      (<HTMLElement>document.getElementById(imgId)).style.display = 'inline';
      for (let file of event.target.files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.profileImage = e.target.result;
          this.assignDataToDocumentArray(e.target.result, file.name, "Photo");
        }
        reader.readAsDataURL(file);
      }
    }
    (<HTMLInputElement>document.getElementById(inputId)).value = '';
    console.log(event.target.files);
  }
  bithCirtificateImage;
  onBithCirtificateChange(event, inputId: string, messageId: string, imgId: string) {
    if (event.target.files.length > 0) {
      (<HTMLElement>document.getElementById(messageId)).style.display = 'none';
      (<HTMLElement>document.getElementById(imgId)).style.display = 'inline';
      for (let file of event.target.files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.bithCirtificateImage = e.target.result;
          this.assignDataToDocumentArray(e.target.result, file.name, "Birth Certificate");
        }
        reader.readAsDataURL(file);
      }
    }
    (<HTMLInputElement>document.getElementById(inputId)).value = '';
    console.log(this.employeeDocumentArray);
  }
  nIDImage;
  onIDImageChange(event, inputId: string, messageId: string, imgId: string) {
    if (event.target.files.length > 0) {
      (<HTMLElement>document.getElementById(messageId)).style.display = 'none';
      (<HTMLElement>document.getElementById(imgId)).style.display = 'inline';
      for (let file of event.target.files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.nIDImage = e.target.result;
          this.assignDataToDocumentArray(e.target.result, file.name, "NID");
        }
        reader.readAsDataURL(file);
      }
    }
    (<HTMLInputElement>document.getElementById(inputId)).value = '';
    console.log(this.employeeDocumentArray);
  }
  passportImage;
  onPassportImageChange(event, inputId: string, messageId: string, imgId: string) {
    if (event.target.files.length > 0) {
      (<HTMLElement>document.getElementById(messageId)).style.display = 'none';
      (<HTMLElement>document.getElementById(imgId)).style.display = 'inline';
      for (let file of event.target.files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.passportImage = e.target.result;
          this.assignDataToDocumentArray(e.target.result, file.name, "Passport");
        }
        reader.readAsDataURL(file);
      }
    }
    (<HTMLInputElement>document.getElementById(inputId)).value = '';
    console.log(this.employeeDocumentArray);
  }
  assignDataToDocumentArray(file: string, fileName: string, documentName: string) {
    this.employeeDocument = new EmployeeDocument;
    this.employeeDocument.employeeId = this.employee.id;
    this.employeeDocument.file = file;
    this.employeeDocument.fileName = fileName;
    this.employeeDocument.documentName = documentName;
    this.employeeDocumentArray.push(this.employeeDocument);
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == ResponseStatusCodeEnum.Success) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/administration/employeeList");
    }
  }
  
  onRemove(id: string) {
    let index;
    this.employeeDocumentArray.filter((e, i) => {
      if (e.documentName == id) {
        index = i;
      }
    });
    this.employeeDocumentArray.splice(index, index + 1);
    if (id == 'Photo') {
      this.profileImage = undefined;
    }
    else if (id == 'Birth Certificate') {
      this.bithCirtificateImage = undefined;
    }
    else if (id == 'NID') {
      this.nIDImage = undefined;
    }
    else if (id == 'Passport') {
      this.passportImage = undefined;
    }
  }
}
