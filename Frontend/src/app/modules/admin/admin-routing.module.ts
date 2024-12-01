import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { UsersPageComponent } from './users-page/users-page.component';
import { NewAppListComponent } from './new-app-list/new-app-list.component';
import { RenewAppListComponent } from './renew-app-list/renew-app-list.component';
import { CustomerComplaintPageComponent } from './customer-complaint-page/customer-complaint-page.component';
import { CustomerFeedbackPageComponent } from './customer-feedback-page/customer-feedback-page.component';

const routes: Routes = [
  { path: 'dashboard', component : AdminDashboardComponent },
  { path: 'userslist', component : UsersPageComponent },
  { path: 'newapplicationlist', component : NewAppListComponent },
  { path: 'renewapplicationlist', component : RenewAppListComponent },
  { path: 'customerfeedback', component : CustomerFeedbackPageComponent },
  { path: 'customercomplaint', component : CustomerComplaintPageComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
