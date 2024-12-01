import { CommonModule } from '@angular/common';
import { Component, DoCheck, OnInit } from '@angular/core';
import {  Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import Swal from 'sweetalert2';
import { ILoggedUser } from '../../interfaces/ILoggedUser';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink,RouterOutlet,CommonModule,RouterLinkActive ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit ,DoCheck {
  isHome              : boolean = false;
  isLogin             : boolean = false;
  isSignup            : boolean = false; 
  isUser              : boolean = false; 
  isAdmin             : boolean = false;
  isIndex             : boolean = false;
  dashName            :string   = '';
  constructor(private router:Router) { }
  ngOnInit(): void {
    this.checkUser();
  }
  resetFlags(): void{
    this.isHome = false;
    this.isLogin = false;
    this.isSignup = false;
    this.isUser = false;
    this.isAdmin = false;
    this.isIndex = false;
  }
  ngDoCheck(): void {
    // Reset flags
    this.resetFlags();

    // Set flags based on the current router url
    if (this.router.url === "/") {
        this.isHome = true;
    } else if (this.router.url === "/login") {
        this.isLogin = true;
    } else if (this.router.url === "/signup") {
        this.isSignup = true;
    } else if (this.router.url.startsWith("/user")) {
        this.isUser = true;
        this.isAdmin = false;
        this.isIndex = false;
    } else if (this.router.url.startsWith("/admin")) {
        this.isAdmin = true;
    } else if (this.router.url === "") {
        this.isIndex = true;
    }
  }
  checkUser() {
    if (typeof window !== 'undefined' && window.localStorage) {
      const loggedInUserString = localStorage.getItem('loggedUser');
      if (loggedInUserString) {
        const loggedInUser : ILoggedUser= JSON.parse(loggedInUserString);
        this.dashName = loggedInUser.firstName;
      }
    }else{
      this.router.navigate(['/login']);
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
