import { Component, OnInit } from '@angular/core';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../../core/services/user.service';
import Swal from 'sweetalert2';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { Gender } from '../../../core/enums/gender';



@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [RouterOutlet,FooterComponent,NavbarComponent,RouterLink,ReactiveFormsModule,CommonModule,HeaderComponent],
  providers: [UserService],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup = <FormGroup>{};
  constructor(private fb: FormBuilder,private authService: UserService, private router : Router) {}
  ngOnInit(): void {
    this.signupForm = this.fb.group({
      firstname      : ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      middlename     : ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      lastname       : ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      dob            : ['', [Validators.required, this.pastDateValidator]],
      email          : ['', [Validators.required, Validators.email]],
      mobileno       : ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      username       : ['', [Validators.required, Validators.pattern('^[a-zA-Z0-9]+$')]],
      password       : ['', [Validators.required, passwordValidator]],
      confirmpassword: ['', [Validators.required]],
      isAgreed       : [false, Validators.requiredTrue],
    },{validator: this.passwordMatchValidator});
  }

  pastDateValidator(control: any) {
    const today = new Date();
    const selectedDate = new Date(control.value);
    return selectedDate < today ? null : { pastDate: true };
  }

  passwordMatchValidator(group: FormGroup): { [key: string]: boolean } | null {
    const password = group.get('password')?.value;
    const confirmPassword = group.get('confirmpassword')?.value;
    if (password !== confirmPassword) {

      return { 'mismatch': true };
    }
    return null;
  }

  get f() {
    return this.signupForm.controls;
  }

  onSubmit() {
    if (this.signupForm.valid) {
      const { confirmpassword, ...formData } = this.signupForm.value;
      console.log(formData);
      
      this.authService.Register(formData).subscribe({
        next: (success: any) => {
          console.log(success);
          if (success) {
            Swal.fire({
              title: 'Registration Successful',
              text: 'You have successfully registered.',
              icon: 'success',
              confirmButtonText: 'OK'
            }).then(() => {
              this.router.navigate(['/login']);
            });
          } else {
            Swal.fire({
              title: 'Registration Failed',
              text: 'There was an error during registration. Please try again.',
              icon: 'error',
              confirmButtonText: 'OK'
            });
          }
        },
        error: (error) => {
          console.error(error);
          Swal.fire({
            title: 'Registration Failed',
            text: 'Username already exists. Please choose a different username.',
            icon: 'info',
            confirmButtonText: 'OK'
          });
        }
      });
    }
  }
    
}

export function passwordValidator(control: AbstractControl): ValidationErrors | null {
  const value = control.value;
  
  if (!value) {
    return null;
  }
  
  const hasUpperCase = /[A-Z]/.test(value);
  const hasLowerCase = /[a-z]/.test(value);
  const hasNumber = /\d/.test(value);
  const hasSpecialChar = /[@$!%*?&]/.test(value);
  const valid = hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar;

  if (!valid) {
    return {
      passwordStrength: true
    };
  }

  return null;
}