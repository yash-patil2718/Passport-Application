import { Component, ElementRef, ViewChild } from '@angular/core';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import Swal from 'sweetalert2';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [FooterComponent,RouterLink,RouterOutlet,NavbarComponent,RouterOutlet,HeaderComponent],
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent {
  
  dashName: string = '';
  constructor( private router: Router){}
  ngOnInit(): void {
    this.checkUser();
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
