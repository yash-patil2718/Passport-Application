import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import Swal from 'sweetalert2';
import { ComplainService } from '../../../core/services/complain.service';
import { CustomerFeedback } from '../../../core/interfaces/customerFeedback';
import { ProcessStage } from '../../../core/enums/complaintProcess';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { ILoggedUser } from '../../../core/interfaces/ILoggedUser';
import { FeedbackDTO } from '../../../core/interfaces/FeedbackDTO';
import { FeedbackType } from '../../../core/enums/feedbackType';
import { error } from 'console';

@Component({
  selector: 'app-customer-feedback',
  standalone: true,
  imports: [RouterLink, RouterOutlet, ReactiveFormsModule, CommonModule, FooterComponent,NavbarComponent,HeaderComponent],
  templateUrl: './customer-feedback.component.html',
  styleUrl: './customer-feedback.component.css'
})
export class CustomerFeedbackComponent implements OnInit {
  feedbackForm: FormGroup= <FormGroup>{};
  userEmail: string = '';
  dashName: string = '';
  lastname: string = '';
  UserFullname: string = '';

  feedbackTypes = Object.entries(FeedbackType)
  .filter(([key, value]) => !isNaN(Number(value)))
  .map(([key]) => ({ key }));

  constructor(private fb: FormBuilder, private router: Router, private feedbackService: ComplainService) {}
  ngOnInit(): void {
    this.initializeForm();
    this.checkUser();
  }
  initializeForm(){
    this.feedbackForm = this.fb.group({
      username: [{ value: '' }, [Validators.required, lettersOnlyValidator()]],
      email: [{ value: '' }, [Validators.required, Validators.email]],
      feedbackType: ['', Validators.required],
      description: ['', Validators.required]
    });
  }
  checkUser() {
    if (typeof window !== 'undefined' && window.localStorage) {
      const loggedInUserString = localStorage.getItem('loggedUser');
      if (loggedInUserString) {
        const loggedInUser : ILoggedUser = JSON.parse(loggedInUserString);
        this.dashName = loggedInUser.firstName;
        this.lastname = loggedInUser.lastName;
        this.userEmail = loggedInUser.email;
        this.UserFullname = this.dashName.concat(" ").concat(this.lastname); // Construct the full name after values are set
        this.feedbackForm.patchValue({ username: this.UserFullname });
        this.feedbackForm.patchValue({ email: this.userEmail }); // Set email form control value
      }
    } else {
      this.router.navigate(['/login']);
    }
  }

  onSubmit(): void {
    if (this.feedbackForm.valid) {
      // Log form values before processing
      console.log('Form Values before submission:', this.feedbackForm.value);
  
      // Convert subject from key to its corresponding value in FeedbackType enum
      const formData: FeedbackDTO = {
        ...this.feedbackForm.value,
        feedbackType: FeedbackType[this.feedbackForm.value.feedbackType as keyof typeof FeedbackType],
      };
  
      // Log the transformed data before sending to the service
      console.log('Transformed FormData:', formData);
  
      this.feedbackService.submitFeedbackComplaint(formData).subscribe(
        (response: FeedbackDTO) => {
          this.showSuccessAlert(response);
          // Reset the form after successful submission
          this.feedbackForm.reset();
        },
        (error) => {
          console.error('Error submitting feedback/complaint:', error);
          this.showErrorAlert();
        }
      );
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

  showSuccessAlert(feedback: FeedbackDTO) {
    // Determine if the feedback is "Feedback" or "Complaint"
    const feedbackType = FeedbackType[feedback.feedbackType]; // Get the enum key from the value
  
    Swal.fire({
      title: 'Submission Successful!',
      text: `Your ${feedbackType.toLowerCase()} has been submitted successfully.`,
      icon: 'success',
      confirmButtonText: 'OK'
    }).then((result) => {
      if (result.isConfirmed) {
        this.feedbackForm.reset({
          username: this.UserFullname,  // Reset to current user's full name
          email: this.userEmail,        // Reset to current user's email
          feedbackType: '',             // Reset to default or empty state
          description: ''               // Reset to empty description
        }); // Clear the form after clicking OK
      }
    });
  }
  

  showErrorAlert() {
    Swal.fire({
      title: 'Submission Failed',
      text: 'There was an error submitting your feedback/complaint. Please try again.',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }



}
// Custom validator function should be outside the class
export function lettersOnlyValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const isValid = /^[a-zA-Z\s]+$/.test(control.value);
    return isValid ? null : { lettersOnly: true };
  };
}