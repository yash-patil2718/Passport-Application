import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import {  UserService } from '../../../core/services/user.service';
import Swal from 'sweetalert2';
import { Role } from '../../../core/enums/role';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { ILoggedUser } from '../../../core/interfaces/ILoggedUser';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterOutlet, FooterComponent,NavbarComponent, RouterLink, ReactiveFormsModule, CommonModule,HeaderComponent],
  providers: [UserService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup= <FormGroup>{};

  constructor(private fb: FormBuilder, private router: Router, private authService: UserService) {
    this.initializeForm();
  }
  initializeForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  onSubmit()
  {
    if (this.loginForm.valid) {
      this.authService.Login(this.loginForm.value).subscribe(
        {
          next :(success :ILoggedUser) =>{
            if(typeof window !== "undefined" && window.localStorage){
              localStorage.setItem('loggedUser', JSON.stringify(success));
            }
            this.navigateUser(success);
          }, error(){
            Swal.fire({
              title: 'Login Failed',
              text: 'Invalid email or password. Please try again.',
              icon: 'error',
              confirmButtonText: 'OK'
            });
          }
        }
      )
    }else{
      this.loginForm.markAllAsTouched();
    } 

  }
  navigateUser(user : ILoggedUser){
    // Show SweetAlert first
    Swal.fire({
      title: 'Login Successful!',
      text: `Welcome back, ${user.firstName} ${user.lastName}!`,
      icon: 'success',
      timer: 1000,
      showConfirmButton: false
    })
     // Perform navigation after SweetAlert is closed
    if (user.role === Role.User) {
      this.router.navigate(['/user/dashboard']);
    } else {
      this.router.navigate(['/admin/dashboard']);
    }
  }

    onReset(): void {
      this.loginForm.reset();
    }

}

export interface LoggedUser {
  firstname: string;
  lastname: string;
  dob: string;
  email: string;
  username: string;
  isLoggedIn: boolean;
}