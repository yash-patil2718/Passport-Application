import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import Swal from 'sweetalert2';
import { FormDataService } from '../../../core/services/form-data.service';
import { RenewApplicationData } from '../../../core/interfaces/form-interfaces';
import { NewApplicationData } from '../../../core/interfaces/new-form-interfaces';
import { ToastrService } from 'ngx-toastr';
import { Payment } from '../../../core/enums/payment';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { ApplicationStatus, ApplicationType, PaymentStatus } from '../../../core/enums/newapplicationenums';
import { IApplicationDetails, IApplicationStatusDetails } from '../../../core/interfaces/applicationStatus';
import { IPaymentUpdateDto } from '../../../core/interfaces/paymentDto';

@Component({
  selector: 'app-payment-page',
  standalone: true,
  imports: [RouterLink, RouterOutlet, ReactiveFormsModule, CommonModule, FooterComponent,NavbarComponent,HeaderComponent],
  providers: [FormDataService],
  templateUrl: './payment-page.component.html',
  styleUrl: './payment-page.component.css'
})
export class PaymentPageComponent implements OnInit {
  myForm :FormGroup = <FormGroup>{};
  paymentForm: FormGroup = <FormGroup>{};
  applicationDetails: IApplicationDetails = <IApplicationDetails>{} ;
  paymentToUpdate : IPaymentUpdateDto = <IPaymentUpdateDto>{};
  dashName: string = '';
  applicationFound: boolean = false;
  ApplicationStatus  = ApplicationStatus;
  ApplicationType    = ApplicationType;
  PaymentStatus = PaymentStatus;

  constructor(private fb: FormBuilder, private router: Router,
              private formdataservice :FormDataService,
              private toastr : ToastrService ) {}

  ngOnInit(): void {
    this.checkUser();
    this.initializeForm();
  }
  initializeForm(){
    this.myForm = this.fb.group({
      applicationType: ['', Validators.required],
      applicationNo: ['', [Validators.required, Validators.pattern(/^\d{10}$/), Validators.maxLength(10),Validators.minLength(10)]],
      dob: ['', [Validators.required, this.pastDateValidator]]
    });

    this.paymentForm = this.fb.group({
      payment_method: ['', Validators.required],
      card_number: ['', [Validators.required, Validators.pattern(/^\d{4} \d{4} \d{4} \d{4}$/)]],
      expiry_date: ['', [Validators.required, Validators.pattern(/^(0[1-9]|1[0-2])\/\d{4}$/), this.futureDateValidator]],
      cvv: ['', [Validators.required, Validators.pattern(/^\d{3}$/)]],
      cardholder_name: ['', [Validators.required, Validators.pattern(/^[a-zA-Z\s]+$/)]],
      amount: [{ value: '₹ 2500', disabled: true }]
    });
  }
  checkUser() {
    if (typeof window !== 'undefined' && window.localStorage) {
      const loggedInUserString = localStorage.getItem('loggedUser');
      if (loggedInUserString) {
        const loggedInUser = JSON.parse(loggedInUserString);
        this.dashName = loggedInUser.firstname;
      }
    } else {
      this.router.navigate(['/login']);
    }
  }

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

  CheckApplication() {
    if (this.myForm.valid) {
      const appData : IApplicationStatusDetails = this.myForm.value;
      if (typeof appData.applicationType === 'string') {
        appData.applicationType = parseInt(appData.applicationType, 10) || 0;
      }
      console.log(this.myForm.value);
      this.formdataservice.getApplicationByNumberApi(appData).subscribe(
        (application: IApplicationDetails) => {
          this.applicationDetails = application;
          this.paymentToUpdate = application;
          if (application) {
            this.applicationFound = true;
            this.toastr.success('Application found successfully', 'Success', {
              progressBar: true,
              timeOut: 2000, // 2 seconds
              progressAnimation: 'decreasing',
            });
          } else {
            this.toastr.error('Application not found', 'Error', {
              progressBar: true,
              timeOut: 2000, // 2 seconds
              progressAnimation: 'decreasing',
            });
          }
        },
        (error) => {
          console.error('Error fetching application:', error);
          this.toastr.error('An error occurred while fetching the application', 'Error', {
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

  onSubmit() {
    if (this.paymentForm.valid) {
      this.formdataservice.makePaymentProcess(this.applicationDetails).subscribe(
        (response:string ) => {
          Swal.fire({
            title: 'Payment Successful',
            text: 'Your payment has been processed successfully.',
            icon: 'success',
            timer: 2000,
            showConfirmButton: false
          }).then(()=>{ 
              this.router.navigate(['/user/dashboard'])
          })
        },
        (error : any) => {
          console.error('Error updating application:', error);
          Swal.fire({
            title: 'Payment Failed',
            text: 'There was an error processing your payment.',
            icon: 'error',
            timer: 2000,
            showConfirmButton: false
          });
        }
      );
    } else {
      this.paymentForm.markAllAsTouched();
    }
  }

  futureDateValidator(control: any) {
    if (!control.value) {
      return null;
    }
    const today = new Date();
    const [month, year] = control.value.split('/').map((val: string) => parseInt(val, 10));
    const expiryDate = new Date(year, month - 1);

    if (expiryDate < today) {
      return { futureDate: true };
    }
    return null;
  }

  pastDateValidator(control: any) {
    const today = new Date();
    const selectedDate = new Date(control.value);
    return selectedDate < today ? null : { pastDate: true };
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
