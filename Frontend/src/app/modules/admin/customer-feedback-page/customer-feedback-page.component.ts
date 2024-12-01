import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import Swal from 'sweetalert2';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import { AdminService } from '../../../core/services/admin.service';
import { CustomerFeedback } from '../../../core/interfaces/customerFeedback';
import { CommonModule, DatePipe } from '@angular/common';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';


@Component({
  selector: 'app-customer-feedback-page',
  standalone: true,
  imports: [FooterComponent,RouterLink,RouterOutlet,CommonModule,NavbarComponent,HeaderComponent],
  providers: [AdminService,DatePipe],
  templateUrl: './customer-feedback-page.component.html',
  styleUrl: './customer-feedback-page.component.css'
})
export class CustomerFeedbackPageComponent {
  dashName: string = '';
  feedbacks: CustomerFeedback[] = [];
  paginatedFeedbacks: CustomerFeedback[] = [];
  currentFeedbackPage: number = 1;
  totalFeedbackPages: number = 0;
  pageSize: number = 5; // Number of items per page

  constructor( private router: Router, private adminService: AdminService){}
  ngOnInit(): void {
    this.checkUser();
    this.GetAllFeedback();
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
  paginateFeedbacks() {
    const start = (this.currentFeedbackPage - 1) * this.pageSize;
    const end = this.currentFeedbackPage * this.pageSize;
    this.paginatedFeedbacks = this.feedbacks.slice(start, end);
  }

  prevFeedbackPage() {
    if (this.currentFeedbackPage > 1) {
      this.currentFeedbackPage--;
      this.paginateFeedbacks();
    }
  }

  nextFeedbackPage() {
    if (this.currentFeedbackPage < this.totalFeedbackPages) {
      this.currentFeedbackPage++;
      this.paginateFeedbacks();
    }
  }

  goToFeedbackPage(page: number) {
    this.currentFeedbackPage = page;
    this.paginateFeedbacks();
  }
  GetAllFeedback(): void {
    this.adminService.GetAllFeedback().subscribe(
      (feedbacks: CustomerFeedback[]) => {
       this.feedbacks = feedbacks;
       this.totalFeedbackPages = Math.ceil(this.feedbacks.length / this.pageSize);
       this.paginateFeedbacks();
      },
      (error) => {
        console.error('Error fetching feedbacks', error);
        Swal.fire({
          title: 'Error',
          text: 'There was an issue fetching feedbacks.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    );
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
