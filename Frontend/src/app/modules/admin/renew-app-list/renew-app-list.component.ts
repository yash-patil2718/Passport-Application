import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import Swal from 'sweetalert2';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import { AdminService } from '../../../core/services/admin.service';
import { RenewApplicationData } from '../../../core/interfaces/form-interfaces';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { IAdminApplicationData } from '../../../core/interfaces/adminApplicationData';
import { ApplicationStatus, ApplicationType, PaymentStatus } from '../../../core/enums/newapplicationenums';

@Component({
  selector: 'app-renew-app-list',
  standalone: true,
  imports: [FooterComponent,RouterLink,RouterOutlet,FormsModule,CommonModule,NavbarComponent,HeaderComponent],
  templateUrl: './renew-app-list.component.html',
  styleUrl: './renew-app-list.component.css'
})
export class RenewAppListComponent {
  dashName: string = '';
  newAppList: IAdminApplicationData[] = [];
  originalApplications: { [key: string]: RenewApplicationData } = {};
  processStages = Object.values(ApplicationStatus);

  applicationStatusEnum = ApplicationStatus;
  PaymentEnum = PaymentStatus
  ApplicationTypeEnum = ApplicationType

  paginatedApplications: IAdminApplicationData[] = []; // Applications to display on the current page
  currentApplicationPage: number = 1; // Current page number
  totalApplicationPages: number = 0; // Total number of pages
  pageSize: number = 5; // Number of applications per page

  constructor( private router: Router,private adminService : AdminService){}
  ngOnInit(): void {
    this.checkUser();
    this.GetAllRenewApplications();
  }
  paginateApplications() {
    const start = (this.currentApplicationPage - 1) * this.pageSize;
    const end = this.currentApplicationPage * this.pageSize;
    this.paginatedApplications = this.newAppList.slice(start, end);
  }

  prevApplicationPage() {
    if (this.currentApplicationPage > 1) {
      this.currentApplicationPage--;
      this.paginateApplications();
    }
  }

  nextApplicationPage() {
    if (this.currentApplicationPage < this.totalApplicationPages) {
      this.currentApplicationPage++;
      this.paginateApplications();
    }
  }

  goToApplicationPage(page: number) {
    this.currentApplicationPage = page;
    this.paginateApplications();
  }

  convertEnumToKeyValueArray<T extends { [key: string]: string | number }>(enumObj: T): { key: string; value: number }[] {
    return Object.entries(enumObj)
      .filter(([key]) => isNaN(Number(key))) // Filter out numeric keys (reverse enum mappings)
      .map(([key, value]) => ({ key, value: +value })); // Convert to array of objects with key and numeric value
  }
  applicationStatuses = this.convertEnumToKeyValueArray(ApplicationStatus);
  applicationTypes = this.convertEnumToKeyValueArray(ApplicationType);
  paymentStatus = this.convertEnumToKeyValueArray(PaymentStatus);

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
  GetAllRenewApplications(): void {
    this.adminService.getAllRenewApplication().subscribe(
      (data: IAdminApplicationData[]) => {
        this.newAppList = data;
        this.totalApplicationPages = Math.ceil(this.newAppList.length / this.pageSize);
        this.paginateApplications();
      },
      (error) => {
        console.error('Error fetching new applications', error);
        Swal.fire({
          title: 'Error',
          text: 'There was an issue fetching new applications.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      });
  }

  editApplication(application: IAdminApplicationData) {
    application.isEditing = true;
  }

  saveApplication(application: IAdminApplicationData) {
    // Remove isEditing flag before sending data to the server
    const { isEditing, ...applicationToUpdate } = application;
    console.log(applicationToUpdate)
    // if (typeof applicationToUpdate.applicationStatus === 'string' &&  
    //   typeof applicationToUpdate.applicationType === 'string' &&
    //   typeof applicationToUpdate.paymentStatus === 'string'
    // ) {
    //   applicationToUpdate.applicationType = parseInt(applicationToUpdate.applicationType, 10) || 0;
    //   applicationToUpdate.paymentStatus = parseInt(applicationToUpdate.paymentStatus, 10) || 0;
    //   applicationToUpdate.applicationStatus = parseInt(applicationToUpdate.applicationStatus, 10) || 0;
    // }
    if (applicationToUpdate.applicationNo) {
      this.adminService.updateApplicationStatus(applicationToUpdate).subscribe(
        (response) => {
          application.isEditing = false;
          Swal.fire({
            title: 'Success',
            text: 'Application status updated successfully.',
            icon: 'success',
            confirmButtonText: 'OK'
          });
          this.GetAllRenewApplications();
        },
        (error) => {
          Swal.fire({
            title: 'Error',
            text: 'There was an issue updating the application.',
            icon: 'error',
            confirmButtonText: 'OK'
          });
          this.GetAllRenewApplications();
        }
      );
    } else {
      console.error('Application ID is undefined');
      Swal.fire({
        title: 'Error',
        text: 'Unable to update application: ID is missing.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    }
  }

  cancelEdit(application: IAdminApplicationData) {
    application.isEditing = false;
    this.GetAllRenewApplications();
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
