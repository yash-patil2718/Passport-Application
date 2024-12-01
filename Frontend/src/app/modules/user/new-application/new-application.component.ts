import { Component, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { FormDataService } from '../../../core/services/form-data.service';
import { ToastrService } from 'ngx-toastr';
import { ApplicationStatus } from '../../../core/enums/applicationStatus';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { ApplicationType, ChangeInAppearance, Citizenship, Country, EducationalQualification, EmployeementType, Gender, MaritalStatus, PagesRequried, PassportType, ReasonforRenewal, State, ValidityRequired } from '../../../core/enums/newapplicationenums';
import { IApplicantDetails, IDocumentDetails, IEmergencyContactDetails, IFamilyDetails, INewApplicationForm, IOtherDetails, IResidentialDetails, IServiceRequired } from '../../../core/interfaces/INewapplication';
import { error } from 'console';
import { HttpErrorResponse } from '@angular/common/http';



@Component({
  selector: 'app-new-application',
  standalone: true,
  imports: [RouterLink, RouterOutlet, FooterComponent, ReactiveFormsModule, CommonModule,NavbarComponent,HeaderComponent],
  templateUrl: './new-application.component.html',
  styleUrl: './new-application.component.css'
})
export class NewApplicationComponent implements OnInit {
  currentTab: number = 1;
  serviceRequestForm: FormGroup = <FormGroup>{};
  applicantForm: FormGroup= <FormGroup>{};
  feedbackForm: FormGroup = <FormGroup>{};
  addressForm: FormGroup = <FormGroup>{};
  emergencyForm: FormGroup = <FormGroup>{};
  questionsForm: FormGroup = <FormGroup>{};
  declarationForm: FormGroup = <FormGroup>{};
  dashName: string = '';
  userid :number = Number();

    // Generic function to convert any enum to an array of key-value pairs
  convertEnumToKeyValueArray<T extends { [key: string]: string | number }>(enumObj: T): { key: string; value: number }[] {
    return Object.entries(enumObj)
      .filter(([key]) => isNaN(Number(key))) // Filter out numeric keys (reverse enum mappings)
      .map(([key, value]) => ({ key, value: +value })); // Convert to array of objects with key and numeric value
  }
  applicationStatuses = this.convertEnumToKeyValueArray(ApplicationStatus);
  applicationTypes = this.convertEnumToKeyValueArray(ApplicationType);
  changeInAppearances = this.convertEnumToKeyValueArray(ChangeInAppearance);
  citizenships = this.convertEnumToKeyValueArray(Citizenship);
  countries = this.convertEnumToKeyValueArray(Country);
  educationalQualifications = this.convertEnumToKeyValueArray(EducationalQualification);
  employmentTypes = this.convertEnumToKeyValueArray(EmployeementType);
  maritalStatuses = this.convertEnumToKeyValueArray(MaritalStatus);
  pagesRequired = this.convertEnumToKeyValueArray(PagesRequried);
  passportTypes = this.convertEnumToKeyValueArray(PassportType);
  reasonsForRenewal = this.convertEnumToKeyValueArray(ReasonforRenewal);
  states = this.convertEnumToKeyValueArray(State);
  validitiesRequired = this.convertEnumToKeyValueArray(ValidityRequired);
  genders = this.convertEnumToKeyValueArray(Gender);

  constructor(private fb: FormBuilder,
    private router: Router, 
    private formDataService: FormDataService, 
    private toastr: ToastrService ) {}

  ngOnInit(): void {
    this.initializeForms();
    this.checkUser();
  }

  private initializeForms(): void {
    this.serviceRequestForm = this.fb.group({
      applicationType   : ['', Validators.required],
      pagesRequried     : ['', Validators.required],
      validityRequired  : ['', Validators.required],
    });

    this.applicantForm = this.fb.group({
      applicantFirstName: ['', [Validators.required]],
      applicantLastName: ['', [Validators.required]],
      isAliases: ['', Validators.required],
      aliasName: [''],  // Add alias_names form control
      isChangedName: ['', Validators.required],
      previousName: [''],  // Add previous_name form control
      dob: ['', Validators.required],
      placeOfBirth: ['', Validators.required],
      gender: ['', Validators.required],
      district: ['', Validators.required],
      state: ['', Validators.required],
      country: ['', Validators.required],
      pancardNo: ['', [Validators.required]],
      voterIdNo: ['', [Validators.required]],
      aadharcardNo: ['', Validators.required],
      employementType: ['', Validators.required],
      organizationName: [''],
      isParentOrSpouceGovermentServent: ['', Validators.required],
      educationQualification: ['', Validators.required],
      isNonEcrEligible: ['', Validators.required],
      distinguishMark: ['', Validators.required],
      maritalStatus : ['',[Validators.required]],
      citizenship : ['',[Validators.required]]
    });
     // Listen to changes on the 'changedname' field to update the 'previous_name' field validation
     this.applicantForm.get('isChangedName')?.valueChanges.subscribe(value => {
      if (value === 'Yes') {
        this.applicantForm.get('previousName')?.setValidators([Validators.required, Validators.minLength(1), Validators.maxLength(45)]);
      } else {
        this.applicantForm.get('previousName')?.clearValidators();
      }
      this.applicantForm.get('previousName')?.updateValueAndValidity();
    });

    // Listen to changes on the 'aliases' field to update the 'alias_names' field validation
    this.applicantForm.get('isAliases')?.valueChanges.subscribe(value => {
      if (value === 'Yes') {
        this.applicantForm.get('aliasName')?.setValidators([Validators.required, Validators.minLength(1), Validators.maxLength(45)]);
      } else {
        this.applicantForm.get('aliasName')?.clearValidators();
      }
      this.applicantForm.get('aliasName ')?.updateValueAndValidity();
    });


    this.feedbackForm = this.fb.group({
      fatherFirstName: ['', Validators.required],
      fatherSurname: ['', Validators.required],
      motherFirstName: ['', Validators.required],
      motherSurname: ['', Validators.required],
      leagalGuardianFirstName: ['', Validators.required],
      leagalGuardianSurname: ['', Validators.required],
      spouceFirstName: [''],
      spouceSurname: ['']
    });

    this.addressForm = this.fb.group({
      houseNoAndName: ['', Validators.required],
      addressLane1: ['', Validators.required],
      addressLane2: [''],
      villageOrCityName: ['', Validators.required],
      district: ['', Validators.required],
      state: ['', Validators.required],
      pincode: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]],
      country: ['', Validators.required],
      mobileNo: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      telephoneNo: ['']
    });

    this.emergencyForm = this.fb.group({
      emergencyContactName: ['', Validators.required],
      emergencyContactAddress: ['', Validators.required],
      emergencyContactMobileNo: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      emergencyContactEmail: ['', [Validators.required, Validators.email]],
      emergencyContactCity: ['', Validators.required],
      district: ['', Validators.required],
      pincode: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]],
      state: ['', Validators.required]
    });

    this.questionsForm = this.fb.group({
      isCriminalProceedings: ['', Validators.required],
      isWarrantSummons: ['', Validators.required],
      iArrestWarrant: ['', Validators.required],
      isDepartureOrder: ['', Validators.required],
      iConviction: ['', Validators.required],
      isPassportRefusal: ['', Validators.required],
      isPassportImpounded: ['', Validators.required],
      ispassportRevoked: ['', Validators.required],
      isForeignCitizenship: ['', Validators.required],
      isotherPassport: ['', Validators.required],
      isSurrenderedPassport: ['', Validators.required],
      isRenunciation: ['', Validators.required],
      isEmergencyCertificate: ['', Validators.required],
      isDeported: ['', Validators.required],
      isRepatriated: ['', Validators.required],
    });

    this.declarationForm = this.fb.group({
      isAcceptTermsAndCondition: [false, Validators.required],
      place: ['', Validators.required],
      dateOfAppApplied: ['', Validators.required],
    });
  }

  checkUser() {
    if (typeof window !== 'undefined' && window.localStorage) {
      const loggedInUserString = localStorage.getItem('loggedUser');
      if (loggedInUserString) {
        const loggedInUser = JSON.parse(loggedInUserString);
        this.dashName = loggedInUser.firstname;
        this.userid = loggedInUser.userId;
      }
    } else {
      this.router.navigate(['/login']);
    }
  }

  onSubmit(): void {
    if (this.serviceRequestForm.valid && this.applicantForm.valid &&
       this.feedbackForm.valid && this.addressForm.valid && 
       this.emergencyForm.valid && this.questionsForm.valid && this.declarationForm.valid) {

        const userIdNo             =  this.userid;
        const serviceRequiredDto    = this.serviceRequestForm.value as IServiceRequired;
        const applicntDetailsDto    = this.applicantForm.value as IApplicantDetails;
        const familyDetailsDto      = this.feedbackForm.value as IFamilyDetails;
        const residentialDetailsDto = this.addressForm.value as IResidentialDetails;
        const emergencyDetailsDto   = this.emergencyForm.value as IEmergencyContactDetails;
        const otherDetailsDto       = this.questionsForm.value as IOtherDetails;
        const documentsDto          = this.declarationForm.value as IDocumentDetails;
        
        if (typeof serviceRequiredDto.applicationType === 'string' && 
            typeof serviceRequiredDto.pagesRequried === 'string' &&
            typeof serviceRequiredDto.validityRequired === 'string' ) {
          serviceRequiredDto.applicationType = parseInt(serviceRequiredDto.applicationType, 10) || 0;
          serviceRequiredDto.pagesRequried = parseInt(serviceRequiredDto.pagesRequried, 10) || 0;
          serviceRequiredDto.validityRequired = parseInt(serviceRequiredDto.validityRequired, 10) || 0;
        }
  
  
        if (typeof applicntDetailsDto.gender === 'string' && 
          typeof applicntDetailsDto.state === 'string' &&
          typeof applicntDetailsDto.country === 'string'&&
          typeof applicntDetailsDto.employementType === 'string' && 
          typeof applicntDetailsDto.educationQualification === 'string' &&
          typeof applicntDetailsDto.maritalStatus === 'string'&&
          typeof applicntDetailsDto.citizenship === 'string'
          ) {
            applicntDetailsDto.gender = parseInt(applicntDetailsDto.gender, 10) || 0;
            applicntDetailsDto.state = parseInt(applicntDetailsDto.state, 10) || 0;
            applicntDetailsDto.country = parseInt(applicntDetailsDto.country, 10) || 0;
            applicntDetailsDto.employementType = parseInt(applicntDetailsDto.employementType, 10) || 0;
            applicntDetailsDto.educationQualification = parseInt(applicntDetailsDto.educationQualification, 10) || 0;
            applicntDetailsDto.maritalStatus = parseInt(applicntDetailsDto.maritalStatus, 10) || 0;
            applicntDetailsDto.citizenship = parseInt(applicntDetailsDto.citizenship, 10) || 0;
          }
        
        const isAliasesvalue =  this.applicantForm.get('isAliases')?.value;
        const isChangedNamevalue =  this.applicantForm.get('isChangedName')?.value;
        const isParentOrSpouceGovermentServentvalue =  this.applicantForm.get('isParentOrSpouceGovermentServent')?.value;
        const isNonEcrEligiblevalue =  this.applicantForm.get('isNonEcrEligible')?.value;
        applicntDetailsDto.isAliases = isAliasesvalue === 'Yes';
        applicntDetailsDto.isChangedName = isChangedNamevalue === 'Yes';
        applicntDetailsDto.isParentOrSpouceGovermentServent = isParentOrSpouceGovermentServentvalue === 'Yes';
        applicntDetailsDto.isNonEcrEligible = isNonEcrEligiblevalue === 'Yes';
  
        if (typeof residentialDetailsDto.state === 'string' && 
          typeof residentialDetailsDto.country === 'string') {
            residentialDetailsDto.state = parseInt(residentialDetailsDto.state, 10) || 0;
            residentialDetailsDto.country = parseInt(residentialDetailsDto.country, 10) || 0;
        }
        if (typeof emergencyDetailsDto.state === 'string') {
          emergencyDetailsDto.state = parseInt(emergencyDetailsDto.state, 10) || 0;
        }
  
        const isCriminalProceedings =  this.questionsForm.get('isCriminalProceedings')?.value;
        const isWarrantSummons =  this.questionsForm.get('isWarrantSummons')?.value;
        const iArrestWarrant =  this.questionsForm.get('iArrestWarrant')?.value;
        const isDepartureOrder =  this.questionsForm.get('isDepartureOrder')?.value;
        const iConviction =  this.questionsForm.get('iConviction')?.value;
        const isPassportRefusal =  this.questionsForm.get('isPassportRefusal')?.value;
        const isPassportImpounded =  this.questionsForm.get('isPassportImpounded')?.value;
        const ispassportRevoked =  this.questionsForm.get('ispassportRevoked')?.value;
        const isForeignCitizenship =  this.questionsForm.get('isForeignCitizenship')?.value;
        const isotherPassport =  this.questionsForm.get('isotherPassport')?.value;
        const isSurrenderedPassport =  this.questionsForm.get('isSurrenderedPassport')?.value;
        const isRenunciation =  this.questionsForm.get('isRenunciation')?.value;
        const isEmergencyCertificate =  this.questionsForm.get('isEmergencyCertificate')?.value;
        const isDeported =  this.questionsForm.get('isDeported')?.value;
        const isRepatriated =  this.questionsForm.get('isRepatriated')?.value;
  
  
        otherDetailsDto.isCriminalProceedings = isCriminalProceedings === 'Yes';
        otherDetailsDto.isWarrantSummons = isWarrantSummons === 'Yes';
        otherDetailsDto.iArrestWarrant = iArrestWarrant === 'Yes';
        otherDetailsDto.isDepartureOrder = isDepartureOrder === 'Yes';
        otherDetailsDto.iConviction = iConviction === 'Yes';
        otherDetailsDto.isPassportRefusal = isPassportRefusal === 'Yes';
        otherDetailsDto.isPassportImpounded = isPassportImpounded === 'Yes';
        otherDetailsDto.ispassportRevoked = ispassportRevoked === 'Yes';
        otherDetailsDto.isForeignCitizenship = isForeignCitizenship === 'Yes';
        otherDetailsDto.isotherPassport = isotherPassport === 'Yes';
        otherDetailsDto.isSurrenderedPassport = isSurrenderedPassport === 'Yes';
        otherDetailsDto.isRenunciation = isRenunciation === 'Yes';
        otherDetailsDto.isEmergencyCertificate = isEmergencyCertificate === 'Yes';
        otherDetailsDto.isDeported = isDeported === 'Yes';
        otherDetailsDto.isRepatriated = isRepatriated === 'Yes';

        const applicationNo = this.generateApplicationNumber();
      
      const applicationData: INewApplicationForm = {
        userId                :  userIdNo,
        applicationNo         : applicationNo,
        serviceRequiredDto    : serviceRequiredDto,
        applicntDetailsDto    : applicntDetailsDto,
        familyDetailsDto      : familyDetailsDto,
        residentialDetailsDto : residentialDetailsDto,
        emergencyDetailsDto   : emergencyDetailsDto,
        otherDetailsDto       : otherDetailsDto,
        documentsDto          : documentsDto
      };
      console.log(applicationData);
      this.formDataService.saveNewApplication(applicationData).subscribe(
        (response) => {
          // Log successful response
          console.log('Application submitted successfully:', response);
  
          Swal.fire({
            title: 'Success',
            text: `Your application has been submitted successfully.Your Application No: ${applicationNo}.`,
            icon: 'success',
            showConfirmButton: true
          }).then((result) => {
            if (result.isConfirmed) {
              this.router.navigate(['/user/dashboard']);
            }
          });
        },
        (error: HttpErrorResponse) => {
          // Log the error details
          console.error('Error submitting application:', error);
  
          Swal.fire({
            title: 'Error',
            text: 'There was an error submitting your application. Please try again.',
            icon: 'error'
          });
        }
      );
    } else {
      Swal.fire({
        title: 'Validation Error',
        text: 'Please fill out all required fields correctly.',
        icon: 'error'
      });
    }
  }  // Generate a unique application number (you can customize this logic as needed)
  generateApplicationNumber(): string {
    let applicationNumber = Math.floor(1000000000 + Math.random() * 9000000000);
    return applicationNumber.toString();
  }

  PreviousTab(): void {
    if (this.currentTab > 1) {
      this.currentTab--;
    }
  }
  showNextTab(nextTab: number): void {
    let currentForm: FormGroup | null;

    // Determine which form to validate based on the current tab
    switch (this.currentTab) {
      case 1:
        currentForm = this.serviceRequestForm;
        break;
      case 2:
        currentForm = this.applicantForm;
        break;
      case 3:
        currentForm = this.feedbackForm;
        break;
      case 4:
        currentForm = this.addressForm;
        break;
      case 5:
        currentForm = this.emergencyForm;
        break;
      case 6:
        currentForm = this.questionsForm;
        break;
      default:
        currentForm = null;
        break;
    }

    // Mark all controls as touched to trigger validation errors
    if (currentForm) {
      this.markAllControlsAsTouched(currentForm);
    }

    // Check if the current form is valid
    if (currentForm && currentForm.valid) {
      console.log(currentForm.value);
      this.currentTab = nextTab;
      this.toastr.success("Data is validated Successfully","Sucess",{
        progressBar: true,
        timeOut: 2000, // 2 seconds
        progressAnimation: 'decreasing',
      });
    } else {
        this.toastr.error("Please fill all mandatory fields", "Error", {
          progressBar: true,
          timeOut: 2000, // 2 seconds
          progressAnimation: 'decreasing'
        });

      console.log("Errors: " + JSON.stringify(currentForm?.errors));
    }
  }

  // Helper method to mark all form controls as touched
  private markAllControlsAsTouched(formGroup: FormGroup): void {
    Object.keys(formGroup.controls).forEach(controlName => {
      const control = formGroup.get(controlName);
      if (control instanceof FormGroup) {
        this.markAllControlsAsTouched(control);
      } else {
        control?.markAsTouched();
      }
    });
  }

  setTab(tabNumber: number): void {
    this.currentTab = tabNumber;
  }

  onLogOut() {
    localStorage.removeItem('loggedUser');

    // Perform navigation first
    this.router.navigate(['/']).then(() => {
      // Show SweetAlert after a short delay
      setTimeout(() => {
        Swal.fire({
          title: 'Logged Out',
          text: 'You have been successfully logged out.',
          icon: 'success',
          timer: 1000,
          showConfirmButton: false
        });
      }, 100); // Short delay before showing SweetAlert
    });
  }

  // Custom validator function should be outside the class
  lettersOnlyValidator(control: FormControl): { [key: string]: boolean } | null {
    const lettersOnly = /^[A-Za-z\s]+$/.test(control.value);
    return lettersOnly ? null : { 'lettersOnly': true };
  }

}
