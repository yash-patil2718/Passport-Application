import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RenewApplicationComponent } from './renew-application/renew-application.component';
import { NewApplicationComponent } from './new-application/new-application.component';
import { ApplicationStatusComponent } from './application-status/application-status.component';
import { PaymentPageComponent } from './payment-page/payment-page.component';
import { CustomerFeedbackComponent } from './customer-feedback/customer-feedback.component';


const routes: Routes = [
  { path : 'dashboard', component : DashboardComponent},
  { path : 'newapplication', component : NewApplicationComponent},
  { path : 'renewapplication', component: RenewApplicationComponent },
  { path : 'appstatus', component: ApplicationStatusComponent},
  { path : 'payment', component : PaymentPageComponent },
  { path : 'feedback', component : CustomerFeedbackComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
