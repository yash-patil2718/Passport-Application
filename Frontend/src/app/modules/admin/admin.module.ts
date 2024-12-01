import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import {  RouterLink, RouterOutlet } from '@angular/router';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AdminRoutingModule,
    RouterLink,
    RouterOutlet
  ]
})
export class AdminModule { }
