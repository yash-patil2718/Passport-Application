import { CommonModule, DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import Swal from 'sweetalert2';
import { FormDataService } from '../../../core/services/form-data.service';
import { NewApplicationData } from '../../../core/interfaces/new-form-interfaces';
import { RenewApplicationData } from '../../../core/interfaces/form-interfaces';
import { ToastrService } from 'ngx-toastr';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { ApplicationStatus, ApplicationType,PaymentStatus } from '../../../core/enums/newapplicationenums';
import { IApplicationDetails, IApplicationStatusDetails } from '../../../core/interfaces/applicationStatus';

@Component({
  selector: 'app-application-status',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,CommonModule,FooterComponent,NavbarComponent,HeaderComponent],
  providers: [DatePipe],  
  templateUrl: './application-status.component.html',
  styleUrl: './application-status.component.css'
})
export class ApplicationStatusComponent implements OnInit {
  myForm: FormGroup = <FormGroup>{};
  dashName:string='';
  applicationDetails:IApplicationDetails | undefined;


  ApplicationStatus = ApplicationStatus;
  ApplicationType = ApplicationType;
  PaymentStatus = PaymentStatus;
  constructor(private fb: FormBuilder,private router: Router, 
    private formdataservice: FormDataService,
    private toastr : ToastrService,
    private datePipe: DatePipe
  ) { }

  convertEnumToKeyValueArray<T extends { [key: string]: string | number }>(enumObj: T): { key: string; value: number }[] {
    return Object.entries(enumObj)
      .filter(([key]) => isNaN(Number(key))) // Filter out numeric keys (reverse enum mappings)
      .map(([key, value]) => ({ key, value: +value })); // Convert to array of objects with key and numeric value
  }
  applicationStatuses = this.convertEnumToKeyValueArray(ApplicationStatus);
  applicationTypes = this.convertEnumToKeyValueArray(ApplicationType);
  paymentStatuses = this.convertEnumToKeyValueArray(ApplicationStatus);
  
  // convert back enum value to its key
  reverseEnumLookup<T extends { [key: string]: string | number }>(enumObj: T, value: number): string {
    const enumKey = Object.entries(enumObj).find(([key, enumValue]) => enumValue === value)?.[0];
    return enumKey || '';
  }
  
  ngOnInit(): void {
    this.checkUser();
    this.initializeForms();
  }
  private initializeForms(): void{
    this.myForm = this.fb.group({
      applicationType: ['', Validators.required],
      applicationNo: ['', [Validators.required, Validators.pattern(/^\d{10}$/), Validators.maxLength(10),Validators.minLength(10)]],
      dob: ['', [Validators.required, this.pastDateValidator]]
    });
  }


  checkUser() {
    if (typeof window !== 'undefined' && window.localStorage) {
      const loggedInUserString = localStorage.getItem('loggedUser');
      if (loggedInUserString) {
        const loggedInUser = JSON.parse(loggedInUserString);
        this.dashName = loggedInUser.firstname;
      }
    }else{
      this.router.navigate(['/login']);
    }
  }

  pastDateValidator(control: any) {
    const today = new Date();
    const selectedDate = new Date(control.value);
    return selectedDate < today ? null : { pastDate: true };
  }

  onSubmit(): void {
    if (this.myForm.valid) {
      const appData : IApplicationStatusDetails = this.myForm.value;
      if (typeof appData.applicationType === 'string') {
        appData.applicationType = parseInt(appData.applicationType, 10) || 0;
      }
      console.log(appData)
        this.formdataservice.getApplicationByNumberApi(appData).subscribe(
        (application: IApplicationDetails) => {
          this.applicationDetails = application;
          console.log(this.applicationDetails);
          //console.log(this.applicationDetails);
          const message = application ? 'Application found successfully' : 'Application not found';
          const messageType = application ? 'success' : 'error';
          const title = application ? 'Success' : 'Error';
          this.toastr[messageType](message, title, {
            progressBar: true,
            timeOut: 2000, // 2 seconds
            progressAnimation: 'decreasing',
          });
        },
        (error) => {
          console.error('Error fetching application:', error);
          this.toastr.error('Invalid application number. Please check and try again.', 'Error', {
            progressBar: true,
            timeOut: 2000, // 2 seconds
            progressAnimation: 'decreasing',
          });
        }
      );
    } else {
      this.myForm.markAllAsTouched();
    }
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
}
