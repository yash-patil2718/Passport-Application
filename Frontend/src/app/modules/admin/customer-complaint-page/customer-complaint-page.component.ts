import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import Swal from 'sweetalert2';
import { AdminService } from '../../../core/services/admin.service';
import { CommonModule } from '@angular/common';
import { CustomerFeedback } from '../../../core/interfaces/customerFeedback';
import { ProcessStage } from '../../../core/enums/complaintProcess';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { FeedbackEnum } from '../../../core/enums/newapplicationenums';


@Component({
  selector: 'app-customer-complaint-page',
  standalone: true,
  imports: [FooterComponent,RouterLink,RouterOutlet,CommonModule,FormsModule,NavbarComponent,HeaderComponent],
  providers: [AdminService],
  templateUrl: './customer-complaint-page.component.html',
  styleUrl: './customer-complaint-page.component.css'
})
export class CustomerComplaintPageComponent {
  dashName: string = '';
  complaints: CustomerFeedback[] = [];
  processStages = Object.values(ProcessStage); // Get enum values for dropdown
  originalComplaints: { [id: number]: CustomerFeedback } = {};
  isEditing : boolean = false;
  constructor( private router: Router, private adminService: AdminService){}
  ngOnInit(): void {
    this.checkUser();
    this.GetAllComplaints();
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
  complaintEnum = FeedbackEnum;

// Converts the enum to an array of key-value pairs
convertEnumToKeyValueArray<T extends { [key: string]: string | number }>(
  enumObj: T
): { key: string; value: number }[] {
  return Object.entries(enumObj)
    .filter(([key]) => isNaN(Number(key))) // Filter out numeric keys (reverse enum mappings)
    .map(([key, value]) => ({ key, value: +value })); // Convert to array of objects with key and numeric value
}

// Prepare the data for dropdown options
complaintStatus = this.convertEnumToKeyValueArray(FeedbackEnum);

// Converts back enum value to its key
reverseEnumLookup<T extends { [key: string]: string | number }>(
  enumObj: T,
  value: number
): string {
  const enumKey = Object.entries(enumObj).find(
    ([key, enumValue]) => enumValue === value
  )?.[0];
  return enumKey || '';
}

paginatedComplaints: CustomerFeedback[] = []; // Complaints to display on the current page
  currentComplaintPage: number = 1; // Current page number
  totalComplaintPages: number = 0; // Total number of pages
  pageSize: number = 5;

  paginateComplaints() {
    const start = (this.currentComplaintPage - 1) * this.pageSize;
    const end = this.currentComplaintPage * this.pageSize;
    this.paginatedComplaints = this.complaints.slice(start, end);
  }

  prevComplaintPage() {
    if (this.currentComplaintPage > 1) {
      this.currentComplaintPage--;
      this.paginateComplaints();
    }
  }

  nextComplaintPage() {
    if (this.currentComplaintPage < this.totalComplaintPages) {
      this.currentComplaintPage++;
      this.paginateComplaints();
    }
  }

  goToComplaintPage(page: number) {
    this.currentComplaintPage = page;
    this.paginateComplaints();
  }

// Method to go to a specific page
goToPage(page: number) {
  if (page >= 1 && page <= this.totalComplaintPages) {
    this.currentComplaintPage = page;
  }
}

  GetAllComplaints(): void {
    this.adminService.GetAllComplaint().subscribe(
      (complaints: CustomerFeedback[]) => {
       this.complaints = complaints;
       this.totalComplaintPages = Math.ceil(this.complaints.length / this.pageSize);
     this.paginateComplaints();
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

  editComplaint(complaint: CustomerFeedback) {
    complaint.isEditing = true;
  }

  saveComplaint(complaint: CustomerFeedback) {
    // Remove isEditing flag before sending data to the server
    const { isEditing, ...complaintToUpdate } = complaint;
    if (typeof complaintToUpdate.status === 'string') {
      complaintToUpdate.status = parseInt(complaintToUpdate.status, 10) || 0;
    }
    this.adminService.updateComplaint(complaintToUpdate).subscribe(
      (response: any) => {
        complaint.isEditing = false;
        Swal.fire({
          title: 'Success',
          text: 'Complaint status updated successfully.',
          icon: 'success',
          confirmButtonText: 'OK'
        });
        this.GetAllComplaints();
      },
      (error) => {
        this.GetAllComplaints();
        console.error('Error updating complaint', error);
        Swal.fire({
          title: 'Error',
          text: 'There was an issue updating the complaint.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    );
  }

  cancelEdit(complaint: CustomerFeedback) {
   complaint.isEditing = false;
   this.GetAllComplaints();
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
