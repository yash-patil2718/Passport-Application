import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';
import Swal from 'sweetalert2';
import { FooterComponent } from '../../../core/components/footer/footer.component';
import {  UserService } from '../../../core/services/user.service';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AdminService } from '../../../core/services/admin.service';
import { NavbarComponent } from '../../../core/components/navbar/navbar.component';
import { HeaderComponent } from '../../../core/components/header/header.component';
import { IUserList } from '../../../core/interfaces/userList';

@Component({
  selector: 'app-users-page',
  standalone: true,
  imports: [FooterComponent,RouterLink,RouterOutlet,CommonModule,FormsModule,NavbarComponent,HeaderComponent],
  providers: [DatePipe,AdminService,UserService],
  templateUrl: './users-page.component.html',
  styleUrl: './users-page.component.css'
})
export class UsersPageComponent implements OnInit {
  dashName: string = '';
  users : IUserList[] = [];
  paginatedUsers: IUserList[] = []; // Users to display on the current page
  currentPage: number = 1; // Current page number
  totalPages: number = 0; // Total number of pages
  pageSize: number = 5; // Number of users per page
  constructor( private router: Router,private userService: UserService, private adminService: AdminService){}
  ngOnInit(): void {
    this.checkUser();
    this.GetAllUser();
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
  GetAllUser = () => {
    this.adminService.GetAllUser().subscribe((data: IUserList[]) => {
      this.users = data;
      this.totalPages = Math.ceil(this.users.length / this.pageSize);
    this.paginateUsers();
    });
  }
  
  paginateUsers() {
    const start = (this.currentPage - 1) * this.pageSize;
    const end = this.currentPage * this.pageSize;
    this.paginatedUsers = this.users.slice(start, end);
  }

  prevPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.paginateUsers();
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.paginateUsers();
    }
  }

  goToPage(page: number) {
    this.currentPage = page;
    this.paginateUsers();
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
